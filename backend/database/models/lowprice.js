'use strict';
module.exports = (sequelize, DataTypes) => {
  const lowPrice = sequelize.define('lowPrice', {
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
    tableName: 'lowPrice',
  });
  lowPrice.associate = function(models) {
    lowPrice.belongsTo(models.position, {foreignKey: 'positionId'});
  };
  return lowPrice;
};
