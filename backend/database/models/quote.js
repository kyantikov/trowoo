'use strict';
module.exports = (sequelize, DataTypes) => {
  const quote = sequelize.define('quote', {
    quoteDate: DataTypes.DATE,
    open: DataTypes.DECIMAL,
    high: DataTypes.DECIMAL,
    low: DataTypes.DECIMAL,
    close: DataTypes.DECIMAL,
    adjustedClose: DataTypes.DECIMAL,
    volume: DataTypes.INTEGER,
    dividendAmount: DataTypes.DECIMAL,
    splitCoefficient: DataTypes.DECIMAL,
  }, {
    freezeTableName: true,
    tableName: 'quote',
  });
  quote.associate = function(models) {
    // associations can be defined here
  };
  return quote;
};
