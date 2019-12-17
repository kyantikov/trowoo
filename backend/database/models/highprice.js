'use strict';
module.exports = (sequelize, DataTypes) => {
  const highPrice = sequelize.define('highPrice', {
    price: {
      type: DataTypes.DECIMAL,
      allowNull: false,
      validate: {
        notNull: {
          msg: 'Value can not be null.'
        },
        isDecimal: {
          args: true,
          msg: 'Price must be a decimal.',
        },
      }
    }
  }, {
    freezeTableName: true,
    tableName: 'highPrice',
  });
  highPrice.associate = function(models) {
    highPrice.belongsTo(models.position, {foreignKey: 'positionId'});
  };
  return highPrice;
};
