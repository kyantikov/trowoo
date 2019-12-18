// consider renaming below variable if creating more than one controller
const trowoo = require('../controllers/controller');

module.exports = app => {
  app.post('/security', (req, res) => {
    trowoo.createSecurity(req,res);
  });
  app.route('/security/:id')
    .patch((req,res) => {
      trowoo.updateSecurity(req,res);
    })
    .delete((req,res) => {
      trowoo.deleteSecurity(req,res);
    });



};
