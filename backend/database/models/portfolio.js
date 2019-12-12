'use strict';
module.exports = (sequelize, DataTypes) => {
  const portfolio = sequelize.define('portfolio', {
    name: DataTypes.STRING
  }, {});
  portfolio.associate = function(models) {
    // associations can be defined here
  };
  return portfolio;
};