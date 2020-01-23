const models = require('../../database/models');

module.exports = {
  createPortfolio: (name, userId) => {
    return models.portfolio.create({
      name: name,
      userId: userId,
    });
  },
  updatePortfolio: (body, portfolioId) => {
    return models.portfolio.update(body, {
      where: {id: portfolioId,}, // userId: req.userContext.userinfo.id
      returning: true,
    });
  },
  retrieveUserPortfolios: (userId) => {
    console.log(userId);
    return models.portfolio.findAll({
      where: {userId: userId},
      include: [{
        model: models.position,
        include: [
          {model: models.security},
          {model: models.lowPrice},
          {model: models.highPrice},
          {model: models.trailingStop},
        ],
      }],
    });
  },
  deletePortfolio: (portfolioId) => {
    return models.position.destroy({
      where: {id: portfolioId}
    })
  },
};
