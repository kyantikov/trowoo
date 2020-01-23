const models = require('../../database/models');

module.exports = {
  createSecurity: (name, ticker) => {
    return models.security.findOrCreate({
      where: {ticker: ticker},
      defaults: {
        name: name,
        ticker: ticker,
      },
    });
  },
  updateSecurity: (body, securityId) => {
    return models.security.update(body, {
      where: {id: securityId},
      returning: true,
    });
  },
  retrieveAllSecurities: () => {
    return models.security.findAll()
  },
  deleteSecurity: (securityId) => {
    return models.security.destroy({
      where: {id: securityId},
    })
  },
};
