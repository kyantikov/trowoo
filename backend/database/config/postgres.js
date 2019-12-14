var Sequelize = require('sequelize');
const sequelize = new Sequelize('dev_db', 'localhost', 'root', {
  host: 'localhost',
  dialect: 'postgres',
  operatorsAliases: null,

  pool: {
    max: 5,
    min: 0,
    acquire: 30000,
    idle: 10000
  },
});
