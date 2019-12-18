'use strict';

module.exports = (sequelize, DataTypes) => {
  const security = sequelize.define('security', {
    ticker: {
      type: DataTypes.STRING,
      allowNull: false,
      validate: {
        isUppercase: {
          args: true,
          msg: 'Ticker must be all uppercase',
        },
        notNull: {
          msg: 'Value can not be null.'
        },
        notEmpty: {
          args: true,
          msg: 'Security ticker is required.'
        },
        // custom validator which prevents against duplicate securities in the database (WIP)
        // isUnique:
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
