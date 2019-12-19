'use strict';
module.exports = (sequelize, DataTypes) => {
  const position = sequelize.define('position', {
    openedDate: {
      type: DataTypes.DATE,
      allowNull: true,
      validate: {
        isDate: {
          args: true,
          msg: 'Must be a valid date.'
        },
        // custom validator to confirm that date is not in the future
        notFutureDate(value) {
          if(value > new Date()){
            throw new Error("Open date must be prior to today.")
          }
        },
      }
    },
    cost: {
      type:DataTypes.DECIMAL,
      allowNull: true,
      validate: {
        isDecimal: {
          args: true,
          msg: 'Entered value must be a decimal.'
        }
      }
    },
  }, {
    freezeTableName: true,
    tableName: 'position',
  });
  position.associate = function(models) {
    // associations can be defined here
    position.belongsTo(models.security, {
      foreignKey: 'securityId',
      onDelete: 'CASCADE',
    });
    position.hasOne(models.lowPrice, {
      foreignKey: 'positionId',
      onDelete: 'CASCADE',
    });
    position.hasOne(models.highPrice, {
      foreignKey: 'positionId',
      onDelete: 'CASCADE',
    });
    position.hasOne(models.trailingStop, {
      foreignKey: 'positionId',
      onDelete: 'CASCADE',
    });
  };
  return position;
};
