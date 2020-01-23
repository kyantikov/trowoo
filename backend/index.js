require('dotenv').config();

const express = require('express');
const bodyParser = require('body-parser');
const schedule = require('node-schedule');
const db = require('./database/models');

// const authMiddleware = require('./middleware/auth');
const marketDataService = require('./services/marketData/marketDataService');

const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));
// app.use(authMiddleware); // use this for development

require('./routes/routes')(app);

db.sequelize.sync().then(() => {
  app.listen(8000, () => {
    console.log("Listening on port 8000");
  })
});

// schedule.scheduleJob('* * * * *', function(){
//   // console.log('The answer to life, the universe, and everything!');
//   marketDataService.retrieveMarketData();
// });
