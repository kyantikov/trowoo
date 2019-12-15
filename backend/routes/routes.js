const path = require('path');
// consider renaming below variable if creating more than one controller
const trowoo = require('../controllers/controller');

module.exports = app => {
  app.get('/user',(req,res) => {
    res.send("USER!!!!");
  });

};
