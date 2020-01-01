require('dotenv').config();

const express = require('express');
const bodyParser = require('body-parser');
const db = require('./database/models');
const authMiddleware = require('./middleware/auth');

const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));
// app.use(authMiddleware);


require('./routes/routes')(app, db);
db.sequelize.sync().then(() => {
  app.listen(8000, () => {
    console.log("Listening on port 8000");
  })
});
