const db = require('../database/models/index');

module.exports = {
  createSecurity: (name, ticker) => {
    return db.security.findOrCreate({
      where: {ticker: ticker},
      defaults: {
        name: name,
        ticker: ticker,
      }
    });
  },
  retrieveAllSecurities: () => {
    return db.security.findAll()
  },
  updateSecurity: (body, securityId) => {
    return db.security.update(body, {
      where: {id: securityId},
      returning: true,
    });
  },
  deleteSecurity: (securityId) => {
    return db.security.destroy({
      where: {id: securityId},
    })
  },
};
