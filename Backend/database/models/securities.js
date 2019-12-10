'use strict';
module.exports = (sequelize, DataTypes) => {
  const Securities = sequelize.define('Securities', {
    ticker: DataTypes.STRING,
    name: DataTypes.STRING
  }, {});
  Securities.associate = function(models) {
    // associations can be defined here
  };
  return Securities;
};