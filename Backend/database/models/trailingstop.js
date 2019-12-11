'use strict';
module.exports = (sequelize, DataTypes) => {
  const trailingStop = sequelize.define('trailingStop', {
    percent: DataTypes.DECIMAL
  }, {});
  trailingStop.associate = function(models) {
    // associations can be defined here
  };
  return trailingStop;
};