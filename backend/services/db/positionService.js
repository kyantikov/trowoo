const models = require('../../database/models');

module.exports = {
  retrieveAllPositions: () => {
    return models.position.findAll();
  },
  createPosition: (openedDate, cost, portfolioId, securityId) => {
    return models.position.create({
      openedDate: openedDate,
      cost: cost,
      portfolioId: portfolioId,
      securityId: securityId,
    });
  },
  updatePosition: (body, positionId) => {
    return models.position.update(body,
      {where: {id: positionId},
      returning: true
    });
  },
  retrievePosition: (positionId) => {
    return models.position.findByPk(
      positionId,
      {
        include:[
          {model: models.security},
          {model: models.lowPrice},
          {model: models.highPrice},
          {model: models.trailingStop}
        ]
      }
    )
  },
  deletePosition: (positionId) => {
    return models.position.destroy({
      where: {id: positionId}
    });
  },
};
