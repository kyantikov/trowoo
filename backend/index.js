const express = require('express');
const bodyParser = require('body-parser');
const db = require('./database/models');

const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));
app.use(express.static(__dirname + '../client/dist/client'));

require('./database/config/config');
require('./routes/routes')(app, db);
require('./database/config/postgres');

db.sequelize.sync().then(() => {
  app.listen(8000, () => {
    console.log("Listening on port 8000");
  })
});
