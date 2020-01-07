const db = require('../db/dbService');
const { Subject, of } = require('rxjs');
const { concatMap, delay } = require("rxjs/operators");

const retrieveMarketData = async () => {
  const queueRequest$ = new Subject();
  queueRequest$.pipe(concatMap(ticker => of(ticker).pipe(delay(12000))))
    .subscribe(ticker => {
      console.log(ticker);
    });
  const queueRequest = (ticker) => queueRequest$.next(ticker);
  const securities = await db.retrieveAllSecurities();
  for(let security of securities) {
    queueRequest(security.ticker);
  }
};

exports.retrieveMarketData = retrieveMarketData;

