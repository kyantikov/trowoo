const db = require('../db/dbService');
const { getQuotes, outputSize } = require('./marketDataProvider');

const { Subject, of } = require('rxjs');
const { concatMap, delay } = require("rxjs/operators");

const retrieveMarketData = async () => {
  const queueRequest$ = new Subject();
  queueRequest$.pipe(concatMap(ticker => of(ticker).pipe(delay(12000))))
    .subscribe(ticker => {
      getQuotes(ticker, outputSize.compact)
        .then(quotes => {console.log(quotes)}); // quoteService.saveQuotes(quotes, securityId)
    });
  const queueRequest = (ticker) => queueRequest$.next(ticker);
  const securities = await db.securityService.retrieveAllSecurities();
  for(let security of securities) {
    queueRequest(security.ticker);
  }
};

exports.retrieveMarketData = retrieveMarketData;

