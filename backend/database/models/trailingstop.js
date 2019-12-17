'use strict';
module.exports = (sequelize, DataTypes) => {
  const trailingStop = sequelize.define('trailingStop', {
    percent: {
      type: DataTypes.DECIMAL,
      allowNull: false,
      validate: {
        max: {
          args: 1,
          msg: 'Value of trailing stop may not be greater than 1.'
        },
        notNull: {
          msg: 'Value can not be null.'
        },
        isDecimal: {
          args: true,
          msg: 'Trailing stop must be a decimal.',
        },
      }
    }
  }, {
    freezeTableName: true,
    tableName: 'trailingStop',
  });
  trailingStop.associate = function(models) {
    trailingStop.belongsTo(models.position, {foreignKey: 'positionId'});
  };
  return trailingStop;
};
