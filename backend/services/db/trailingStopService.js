const models = require('../../database/models');

module.exports = {
  createTrailingStop: (percent, positionId) => {
    return models.trailingStop.create({
      percent: percent,
      positionId: positionId,
    });
  },
  updateTrailingStop: (body, trailingStopId) => {
    return models.trailingStop.update(body, {
      where: {id: trailingStopId},
      returning: true,
    })
  },
  deleteTrailingStop: (trailingStopId) => {
    return models.trailingStop.destroy({
      where: {id: trailingStopId}
    })
  },
};
