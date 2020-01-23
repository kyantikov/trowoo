const axios = require('axios');
const url = 'https://www.alphavantage.co/query?';

const parseQuotesResponse = (quotesResponse) => {
  const timeSeries = quotesResponse['Time Series (Daily)'];
  const quotes = [];
  for(let quoteDate in timeSeries){
    const quoteValues = timeSeries[quoteDate];
    const quote = {};
    quote.quoteDate = quoteDate;
    quote.open = quoteValues['1. open'];
    quote.high = quoteValues['2. high'];
    quote.low = quoteValues['3. low'];
    quote.close = quoteValues['4. close'];
    quote.adjustedClose = quoteValues['5. adjusted close'];
    quote.volume = quoteValues['6. volume'];
    quote.dividendAmount = quoteValues['7. dividend amount'];
    quote.splitCoefficient = quoteValues['8. split coefficient'];
    quotes.push(quote);
  }
  return quotes;
};

module.exports = {
  outputSize: {
    full: 'full',
    compact: 'compact',
  },
  getQuotes: (ticker, outputSize) => {
    console.log('//////////////////////');
    console.log(ticker);
    console.log('//////////////////////');
    return axios.get(`${url}function=TIME_SERIES_DAILY_ADJUSTED&symbol=${ticker}&outputsize=${outputSize}&apikey=${process.env.ALPHA_VANTAGE_APIKEY}`)
      .then(res => {
        return parseQuotesResponse(res.data);
      }).catch(error => {
        console.log(error);
    });
  },
};
