using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;


namespace Trowoo.Services
{
    public class SecurityService
    {
        private TrowooDbContext TrowooDbContext;
        public SecurityService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }
        public Security FindOrCreate(Security security)
        {
            var existingSecurity = GetByTicker(security.Ticker);
            if (existingSecurity != null)
            {
                return existingSecurity;
            }
            //
            TrowooDbContext.Add(security);
            TrowooDbContext.SaveChanges();
            return security;
        }
        public List<Security> GetAll()
        {
            return TrowooDbContext.Securities.ToList();
        }
        public Security Update(Security security)
        {
            var existingSecurity = GetById(security.Id);
            if(existingSecurity == null)
            {
                return null;
            }
            if(GetByTicker(security.Ticker) != null)
            {
                throw new EntityExistsException($"Security with ticker: '{security.Ticker}' already exists");
            }
            TrowooDbContext.Entry(existingSecurity).CurrentValues.SetValues(security);
            TrowooDbContext.SaveChanges();
            return security;
        }
        
        public void Delete(int id)
        {
            try
            {
                TrowooDbContext.Securities.Remove(new Security{Id = id});
                TrowooDbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new EntityDoesNotExistException($"Security with id: '{id}' does not exist", exception);
            }
        }
        public Security GetById(int id)
        {
            return TrowooDbContext.Securities.Find(id);
        }
        public Security GetByTicker(string ticker)
        {
            return TrowooDbContext.Securities.Where(s => s.Ticker == ticker).FirstOrDefault();
        }
    }
}