'use strict';

module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.changeColumn('quote', 'quoteDate', {type: Sequelize.DATEONLY})
    /*
      Example:
      return queryInterface.createTable('users', { id: Sequelize.INTEGER });
    */
  },

  down: (queryInterface, Sequelize) => {
    return queryInterface.changeColumn('quote', 'quoteDate', {type: Sequelize.DATE})
    /*
      Example:
      return queryInterface.dropTable('users');
    */
  }
};
