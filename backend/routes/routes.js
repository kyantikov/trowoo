// consider renaming below variable if creating more than one controller
const trowoo = require('../controllers/controller');
const authMiddleware = require('../middleware/auth');

module.exports = app => {
  // security related endpoints
  app.route('/security/')
    .get((req,res) => {trowoo.retrieveAllSecurities(req,res)})
    .post((req,res) => {trowoo.createSecurity(req,res)});
  app.route('/security/:id')
    .patch(authMiddleware, (req,res) => {trowoo.updateSecurity(req,res)})
    .delete(authMiddleware, (req,res) => {trowoo.deleteSecurity(req,res)});

  // portfolio related endpoints
  app.route('/portfolio/')
    .get(authMiddleware, (req,res) => {trowoo.retrieveUserPortfolios(req,res)})
    .post(authMiddleware, (req,res) => {trowoo.createPortfolio(req,res)});
  app.route('/portfolio/:id')
    .patch(authMiddleware, (req,res) => {trowoo.updatePortfolio(req,res)})
    .delete(authMiddleware, (req,res) => {trowoo.deletePortfolio(req,res)});

  // position related endpoints
  app.post('/position/', authMiddleware,(req,res) => {trowoo.createPosition(req,res)});
  app.route('/position/:id')
    .get(authMiddleware, (req,res) => {trowoo.retrievePosition(req, res)})
    .patch(authMiddleware, (req,res) => {trowoo.updatePosition(req,res)})
    .delete(authMiddleware, (req,res) => {trowoo.deletePosition(req,res)});

  // highPrice related endpoints
  app.post('/alert/highPrice/',authMiddleware, (req,res) => {trowoo.createHighPrice(req,res)});
  app.route('/alert/highPrice/:id')
    .patch(authMiddleware, (req,res) => {trowoo.updateHighPrice(req,res)})
    .delete(authMiddleware, (req,res) => {trowoo.deleteHighPrice(req,res)});

  // lowPrice related endpoints
  app.post('/alert/lowPrice/', authMiddleware, (req,res) => {trowoo.createLowPrice(req,res)});
  app.route('/alert/lowPrice/:id')
    .patch(authMiddleware, (req,res) => {trowoo.updateLowPrice(req,res)})
    .delete(authMiddleware, (req,res) => {trowoo.deleteLowPrice(req,res)});

  // trailingStop related endpoints
  app.post('/alert/trailingStop/', authMiddleware, (req,res) => {trowoo.createTrailingStop(req,res)});
  app.route('/alert/trailingStop/:id')
    .patch(authMiddleware,(req,res) => {trowoo.updatedTrailingStop(req,res)})
    .delete(authMiddleware,(req,res) => {trowoo.deleteTrailingStop(req,res)});
};
