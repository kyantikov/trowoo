'use strict';
module.exports = (sequelize, DataTypes) => {
  const trailingStop = sequelize.define('trailingStop', {
    percent: DataTypes.DECIMAL
  }, {
    freezeTableName: true,
    tableName: 'trailingStop',
  });
  trailingStop.associate = function(models) {
    // associations can be defined here
  };
  return trailingStop;
};
