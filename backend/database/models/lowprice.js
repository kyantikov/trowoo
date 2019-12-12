'use strict';
module.exports = (sequelize, DataTypes) => {
  const lowPrice = sequelize.define('lowPrice', {
    price: DataTypes.DECIMAL
  }, {
    freezeTableName: true,
    tableName: 'lowPrice',
  });
  lowPrice.associate = function(models) {
    // associations can be defined here
  };
  return lowPrice;
};
