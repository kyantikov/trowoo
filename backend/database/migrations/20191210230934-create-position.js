'use strict';
module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.createTable('position', {
      id: {
        allowNull: false,
        autoIncrement: true,
        primaryKey: true,
        type: Sequelize.INTEGER
      },
      openedDate: {
        type: Sequelize.STRING
      },
      cost: {
        type: Sequelize.DECIMAL
      },
      portfolioId: {
        type: Sequelize.INTEGER,
        references: {
            model: {
              tableName: 'portfolio',
            },
            key: 'id'
          },
          allowNull: false,
      },
      securityId: {
        type: Sequelize.INTEGER,
        references: {
          model: {
            tableName: 'security'
          },
          key: 'id'
        },
        allowNull: false,
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
    return queryInterface.dropTable('position');
  }
};
