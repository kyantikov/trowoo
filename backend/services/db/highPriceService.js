const models = require('../../database/models');

module.exports = {
  createHighPrice: (price, positionId) => {
    return models.highPrice.create({
      price: price,
      positionId: positionId,
    });
  },
  updateHighPrice: (body, highPriceId) => {
    return models.highPrice.update(body, {
      where: {id: highPriceId},
      returning: true,
    });
  },
  deleteHighPrice: (highPriceId) => {
    return models.highPrice.destroy({
      where: {id: highPriceId}
    });
  }
};
