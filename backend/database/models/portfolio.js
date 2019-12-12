'use strict';
module.exports = (sequelize, DataTypes) => {
  const portfolio = sequelize.define('portfolio', {
    name: {
      type: DataTypes.STRING,
      validate: {
        isNull: {
          args: false,
          msg: 'Portfolio must have a name.'
        }
      }
    }
  }, {
    freezeTableName: true,
    tableName: 'portfolio',
  });
  portfolio.associate = function(models) {
    // associations can be defined here
  };
  return portfolio;
};
