// consider renaming below variable if creating more than one controller
const trowoo = require('../controllers/controller');

module.exports = app => {

  // security related endpoints
  app.post('/security', (req,res) => {
    trowoo.createSecurity(req,res);
  });
  app.route('/security/:id')
    .patch((req,res) => {
      trowoo.updateSecurity(req,res);
    })
    .delete((req,res) => {
      trowoo.deleteSecurity(req,res);
    });


  // portfolio related endpoints
  app.route('/portfolio/:userId')
    .post((req,res) => {
      trowoo.createPortfolio(req,res)
    })
    .get((req,res) => {
      trowoo.retrieveUserPortfolios(req,res);
    });
  // conditional deletion of portfolio
  app.delete('/portfolio/:id', (req,res) => {
    trowoo.deletePortfolio(req, res);
  });


  // position related endpoints
  app.post('/position/:securityId/:portfolioId', (req,res) => {
    trowoo.createPosition(req,res);
  });
  app.delete('/position/:id', (req,res) => {
    trowoo.deletePosition(req, res);
  });
};
