'use strict';
module.exports = (sequelize, DataTypes) => {
  const securities = sequelize.define('securities', {
    ticker: DataTypes.STRING,
    name: DataTypes.STRING
  }, {});
  securities.associate = function(models) {
    // associations can be defined here
  };
  return securities;
};