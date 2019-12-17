'use strict';

module.exports = (sequelize, DataTypes) => {
  const security = sequelize.define('security', {
    ticker: {
      type: DataTypes.STRING,
      allowNull: false,
      validate: {
        isUppercase: true,
        notNull: {
          msg: 'Value can not be null.'
        },
        notEmpty: {
          args: true,
          msg: 'Security ticker is required.'
        }
      }
    },
    name: {
      type: DataTypes.STRING,
      allowNull: false,
      validate: {
        notNull: {
          msg: 'Value can not be null.'
        },
        notEmpty: {
          args: true,
          msg: 'Security name is required.'
        }
      },
    }
  }, {
    freezeTableName: true,
    tableName: 'security',
  });
  security.associate = function(models) {
    security.hasOne(models.position, {foreignKey: 'securityId'});
    security.hasMany(models.quote, {foreignKey: 'securityId'});
  };
  return security;
};
