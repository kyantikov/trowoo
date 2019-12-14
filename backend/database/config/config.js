require('dotenv').config();

module.exports = {
  // development: {
  //   url: process.env.DEV_DATABASE_URL,
  //   dialect: 'postgres'
  // },
  "development": {
    "username": "root",
    "password": "root",
    "database": "dev_db",
    "host": "127.0.0.1",
    "dialect": "postgres"
  },
  test: {
    url: process.env.TEST_DATABASE_URL,
    dialect: 'postgres'
  },
  // 'production': {
  //   url: process.env.DATABASE_URL,
  //   dialect: 'postgres'
  // }
};
