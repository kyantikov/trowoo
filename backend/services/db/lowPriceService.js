const models = require('../../database/models');

module.exports = {
  createLowPrice: (price, positionId) => {
    return models.lowPrice.create({
      price: price,
      positionId: positionId,
    });
  },
  updateLowPrice: (body, lowPriceId) => {
    return models.lowPrice.update(body, {
      where: {id: lowPriceId},
      returning: true,
    });
  },
  deleteLowPrice: (lowPriceId) => {
    return models.lowPrice.destroy({
      where: {id: lowPriceId}
    });
  }
};
