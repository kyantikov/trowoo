'use strict';

const noUpdateAttributes = require('sequelize-noupdate-attributes');

module.exports = (sequelize, DataTypes) => {
  noUpdateAttributes(sequelize);
  const portfolio = sequelize.define('portfolio', {
    name: {
      type: DataTypes.STRING,
      allowNull: false,
      validate: {
        notNull: {
          msg: 'Value can not be null.'
        },
        notEmpty: {
          args: true,
          msg: 'Portfolio must have a name.'
        }
      }
    },
    userId: {
      type: DataTypes.STRING,
      allowNull: false,
      noUpdate: true,
      validate: {
        notNull: {
          msg: 'Value may not be null.'
        },
        notEmpty: {
          args: true,
          msg: 'Value may not be an empty string.'
        }
      }
    }
  }, {
    freezeTableName: true,
    tableName: 'portfolio',
  });
  portfolio.associate = function(models) {
    portfolio.hasMany(models.position, {
      foreignKey: 'portfolioId',
      onDelete: 'CASCADE',
    });
  };
  return portfolio;
};
