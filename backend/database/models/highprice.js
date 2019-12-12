'use strict';
module.exports = (sequelize, DataTypes) => {
  const highPrice = sequelize.define('highPrice', {
    price: DataTypes.DECIMAL
  }, {
    freezeTableName: true,
    tableName: 'highPrice',
  });
  highPrice.associate = function(models) {
    // associations can be defined here
  };
  return highPrice;
};
