'use strict';
module.exports = (sequelize, DataTypes) => {
  const lowPrice = sequelize.define('lowPrice', {
    price: DataTypes.DECIMAL
  }, {});
  lowPrice.associate = function(models) {
    // associations can be defined here
  };
  return lowPrice;
};