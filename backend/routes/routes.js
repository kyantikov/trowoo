// consider renaming below variable if creating more than one controller
const trowoo = require('../controllers/controller');

module.exports = app => {
  // security related endpoints
  app.route('/security')
    .get((req,res) => {trowoo.retrieveAllSecurities(req,res)})
    .post((req,res) => {trowoo.createSecurity(req,res)});
  app.route('/security/:id')
    .patch((req,res) => {trowoo.updateSecurity(req,res)})
    .delete((req,res) => {trowoo.deleteSecurity(req,res)});

  // portfolio related endpoints
  app.route('/portfolio/:userId')
    .post((req,res) => {trowoo.createPortfolio(req,res)})
    .get((req,res) => {trowoo.retrieveUserPortfolios(req,res)});
  app.route('/portfolio/:id')
    .patch((req,res) => {trowoo.updatePortfolio(req,res)})
    .delete((req,res) => {trowoo.deletePortfolio(req, res)});

  // position related endpoints
  app.post('/position/:securityId/:portfolioId',(req,res) => {trowoo.createPosition(req,res)});
  app.route('/position/:id')
    .get((req,res) => {trowoo.retrievePosition(req, res)})
    .patch((req,res) => {trowoo.updatePosition(req,res)})
    .delete((req,res) => {trowoo.deletePosition(req,res)});

  // highPrice related endpoints
  app.post('/alert/highPrice/:positionId',(req,res) => {trowoo.createHighPrice(req,res)});
  app.route('/alert/highPrice/:id')
    .patch((req,res) => {trowoo.updateHighPrice(req,res)})
    .delete((req,res) => {trowoo.deleteHighPrice(req,res)});

  // lowPrice related endpoints
  app.post('/alert/lowPrice/:positionId', (req,res) => {trowoo.createLowPrice(req,res)});
  app.route('/alert/lowPrice/:id')
    .patch((req,res) => {trowoo.updateLowPrice(req,res)})
    .delete((req,res) => {trowoo.deleteLowPrice(req,res)});

  // trailingStop related endpoints
  app.post('/alert/trailingStop/:positionId', (req,res) => {trowoo.createTrailingStop(req,res)});
  app.route('/alert/trailingStop/:id')
    .patch((req,res) => {trowoo.updatedTrailingStop(req,res)})
    .delete((req,res) => {trowoo.deleteTrailingStop(req,res)});
};
