// consider renaming below variable if creating more than one controller
const path = require('path');
const trowoo = require('../controllers/controller');

const allowedExt = [
  '.js',
  '.ico',
  '.css',
  '.png',
  '.jpg',
  '.woff2',
  '.woff',
  '.ttf',
  '.svg',
];


module.exports = app => {
  app.get('/user',(req,res) => {
    res.send("USER!!!!");
  });

  // app.get("*", (req, res, next) => {
  //   res.sendFile(path.resolve('../client/dist/client/index.html'));
  // });

  app.all('*', (req, res) => {
    if (allowedExt.filter(ext => req.url.indexOf(ext) > 0).length > 0) {
      res.sendFile(path.resolve(`../client/dist/client/${req.url}`));
    } else {
      res.sendFile(path.resolve('../client/dist/client/index.html'));
    }
  });
};
