using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.Logging;
using Trowoo.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Trowoo.Services.MarketData
{
  public class MarketDataProviderBackgroundService : BackgroundService 
  {
    private const int MAX_SEMAPHORE_COUNT = 1;

    private static SemaphoreSlim ProcessingSemaphore = new SemaphoreSlim(0, MAX_SEMAPHORE_COUNT);
    private static ILogger Logger { get; set; }
    private IServiceProvider ServiceProvider { get; }

    public MarketDataProviderBackgroundService(ILogger<MarketDataProviderBackgroundService> logger, IServiceProvider serviceProvider)
    {
      Logger = logger;
      ServiceProvider = serviceProvider;
    }

    protected async override Task ExecuteAsync(CancellationToken cancellationToken)
    {
      while (!cancellationToken.IsCancellationRequested)
      {
        await ProcessingSemaphore.WaitAsync();

        try 
        {
          Logger.LogInformation("Processing Market Data Started ");

          using (var scope = ServiceProvider.CreateScope())
          {
            var marketDataService = scope.ServiceProvider.GetRequiredService<MarketDataService>();
            await marketDataService.RetrieveMarketDataAsync();
          }
        } 
        catch(Exception exception) 
        {
          Logger.LogError(exception.Message, exception);
        }
        finally
        {
          Logger.LogInformation("Processing Market Data Finished");
        }
      }
    }

    public static void StartProcessing() {
      //Logger.LogInformation($"ProcessingSemaphore.CurrentCount = {ProcessingSemaphore.CurrentCount}");

      if (ProcessingSemaphore.CurrentCount < MAX_SEMAPHORE_COUNT)
      {
        ProcessingSemaphore.Release();
      }
    }
  }
}