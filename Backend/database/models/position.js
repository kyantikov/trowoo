'use strict';
module.exports = (sequelize, DataTypes) => {
  const position = sequelize.define('position', {
    openedDate: DataTypes.STRING,
    cost: DataTypes.DECIMAL
  }, {});
  position.associate = function(models) {
    // associations can be defined here
  };
  return position;
};