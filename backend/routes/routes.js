// consider renaming below variable if creating more than one controller
const dbController = require('../controllers/controller');
const marketDataProvider = require('../services/marketData/marketDataProvider');
const marketDataService = require('../services/marketData/marketDataService');

const authMiddleware = require('../middleware/auth');

// TODO: add in authMiddleware to all routes as middleware handlers; currently using::: app.use(authMiddleware) --> index.js

module.exports = app => {
  // security endpoints
  app.route('/security/')
    .get((req,res) => {dbController.retrieveAllSecurities(req,res)})
    .post((req,res) => {dbController.createSecurity(req,res)});
  app.route('/security/:id')
    .patch((req,res) => {dbController.updateSecurity(req,res)})
    .delete((req,res) => {dbController.deleteSecurity(req,res)});

  // portfolio endpoints
  app.route('/portfolio/')
    .get((req,res) => {dbController.retrieveUserPortfolios(req,res)})
    .post((req,res) => {dbController.createPortfolio(req,res)});
  app.route('/portfolio/:id')
    .patch((req,res) => {dbController.updatePortfolio(req,res)})
    .delete((req,res) => {dbController.deletePortfolio(req,res)});

  // position endpoints
  app.post('/position/', (req,res) => {dbController.createPosition(req,res)});
  app.route('/position/:id')
    .get((req,res) => {dbController.retrievePosition(req, res)})
    .patch((req,res) => {dbController.updatePosition(req,res)})
    .delete((req,res) => {dbController.deletePosition(req,res)});

  // highPrice endpoints
  app.post('/alert/highPrice/', (req,res) => {dbController.createHighPrice(req,res)});
  app.route('/alert/highPrice/:id')
    .patch((req,res) => {dbController.updateHighPrice(req,res)})
    .delete((req,res) => {dbController.deleteHighPrice(req,res)});

  // lowPrice endpoints
  app.post('/alert/lowPrice/', (req,res) => {dbController.createLowPrice(req,res)});
  app.route('/alert/lowPrice/:id')
    .patch((req,res) => {dbController.updateLowPrice(req,res)})
    .delete((req,res) => {dbController.deleteLowPrice(req,res)});

  // trailingStop endpoints
  app.post('/alert/trailingStop/', (req,res) => {dbController.createTrailingStop(req,res)});
  app.route('/alert/trailingStop/:id')
    .patch((req,res) => {dbController.updatedTrailingStop(req,res)})
    .delete((req,res) => {dbController.deleteTrailingStop(req,res)});

  // quote endpoints
  app.route('/system/quote/')
    .get((req,res) => {
      marketDataService.retrieveMarketData()
        .then((result) => {console.log(result)})
        .catch(() => {});
    });
};

