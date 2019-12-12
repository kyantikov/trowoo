'use strict';

module.exports = (sequelize, DataTypes) => {
  const security = sequelize.define('security', {
    ticker: {
      type: DataTypes.STRING,
      validate: {
        isUppercase: true,
        isNull: {
          args: false,
          msg: 'Security ticker can not be blank.'
        }
      }
    },
    name: {
      type: DataTypes.STRING,
      validate: {
        isNull: {
          args: false,
          msg: 'Security name can not be blank.'
        }
      },
    }
  }, {});
  security.associate = function(models) {
    // associations can be defined here
  };
  return security;
};
