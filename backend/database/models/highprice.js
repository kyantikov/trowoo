'use strict';
module.exports = (sequelize, DataTypes) => {
  const highPrice = sequelize.define('highPrice', {
    price: DataTypes.DECIMAL
  }, {});
  highPrice.associate = function(models) {
    // associations can be defined here
  };
  return highPrice;
};