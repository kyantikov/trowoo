'use strict';
module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.createTable('quote', {
      id: {
        allowNull: false,
        autoIncrement: true,
        primaryKey: true,
        type: Sequelize.INTEGER
      },
      securityId: {
        type: Sequelize.INTEGER,
        references: {
          model: {
            tableName: 'security'
          },
          key: 'id'
        },
        allowNull: false
      },
      quoteDate: {
        type: Sequelize.DATE
      },
      open: {
        type: Sequelize.DECIMAL
      },
      high: {
        type: Sequelize.DECIMAL
      },
      low: {
        type: Sequelize.DECIMAL
      },
      close: {
        type: Sequelize.DECIMAL
      },
      adjustedClose: {
        type: Sequelize.DECIMAL
      },
      volume: {
        type: Sequelize.INTEGER
      },
      dividendAmount: {
        type: Sequelize.DECIMAL
      },
      splitCoefficient: {
        type: Sequelize.DECIMAL
      },
      createdAt: {
        allowNull: false,
        type: Sequelize.DATE
      },
      updatedAt: {
        allowNull: false,
        type: Sequelize.DATE
      }
    });
  },
  down: (queryInterface, Sequelize) => {
    return queryInterface.dropTable('quote');
  }
};
