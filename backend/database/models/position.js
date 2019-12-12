'use strict';
module.exports = (sequelize, DataTypes) => {
  const position = sequelize.define('position', {
    openedDate: DataTypes.DATE,
    cost: DataTypes.DECIMAL
  }, {
    freezeTableName: true,
    tableName: 'position',
  });
  position.associate = function(models) {
    // associations can be defined here
  };
  return position;
};
