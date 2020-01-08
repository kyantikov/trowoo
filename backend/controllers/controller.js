const Sequelize = require('sequelize');
const db = require('../services/db/dbService');

const helper = require('./helper');

// TODO: [validation] -- when creating a trailing stop for a position, check if that position has an opening date and cost
// ^^^^ also for high/lowPrice
// TODO: place models querying logic into singular service file in order to decouple that logic from requests
// TODO: price-to-book ratios?

module.exports = {
  // security logic
  createSecurity: (req,res) => {
    db.securityService.createSecurity(req.body.name, req.body.ticker)
      .then(data => {
        if(data[1] === false){
          res.status(200).json(data)
        }
        res.status(201).json(data);
      }).catch(error => {
        res.status(400).json(error);
    });
  },
  retrieveAllSecurities: (req,res) => {
     db.securityService.retrieveAllSecurities()
      .then(data => {
      res.status(200).json(data);
    }).catch(error => {
      res.status(400).json(error);
    });
  },
  // regular users will likely be unable to access updating/deleting securities
  // should update,delete be done with ticker instead?
  updateSecurity: (req, res) => {
    db.securityService.updateSecurity(req.body, req.params.id)
      .then(data => {
      res.status(200).json(data[1]);
    }).catch(error => {
      res.status(400).json(error);
    });
  },
  // security cannot be deleted if a position is open on that security
  deleteSecurity: (req, res) => {
    db.securityService.deleteSecurity(req.params.id)
      .then(data => {
      res.status(200).json(data);
    }).catch(error => {
      res.status(400).json(error);
    });
  },

  // portfolio logic
  createPortfolio: (req, res) => {
    db.portfolioService.createPortfolio(req.body.name, req.body.userId)
      .then(data => {
        res.status(201).json(data);
      }).catch(error => {
        res.status(400).json(error);
    });
  },
  retrieveUserPortfolios: (req, res) => {
    db.portfolioService.retrieveUserPortfolios(req.body.userId)
      .then(data => {
        res.status(200).json(data);
      }).catch(error => {
        res.status(400).json(error);
    });
  },
  updatePortfolio: (req,res) => {
    if(req.body.userId){
      return res.status(400).json({msg:'error: userId cannot be changed'});
    }
    db.portfolioService.updatePortfolio(req.params.id)
      .then(data => {
        res.status(200).json(data[1]);
      }).catch(error => {
        res.status(400).json(error);
    });
  },
  // deletes portfolio only if the portfolio is empty
  deletePortfolio: (req, res) => {
    db.portfolioService.deletePortfolio(req.params.id)
      .then(data => {
        res.status(200).json(data);
      }).catch(error => {
        res.status(400).json(error);
    });
  },

  // position logic
  createPosition: (req, res) => {
    db.positionService.createPosition(
      req.body.openedDate,
      req.body.cost,
      req.body.portfolioId,
      req.body.securityId
    ).then(data => {
        res.status(201).json(data);
      }).catch(error => {
        res.status(400).json(error);
    });
  },
  retrievePosition: (req,res) => {
    db.positionService.retrievePosition(req.body.id)
      .then(data => {
      res.status(200).json(data);
    }).catch(error => {
      res.status(400).json(error);
    });
  },
  // will update only cost or openedDate or both depending on input
  updatePosition: (req, res) => {
    db.positionService.updatePosition(req.body, req.params.id)
      .then(data => {
      res.status(200).json(data[1]);
    }).catch(error => {
      res.status(400).json(error);
    });
  },
  // TODO: find out if deleting a position will also delete rows in low/highPrice and trailingStop with that positions ID
  deletePosition: (req, res) => {
    db.positionService.deleteSecurity(req.params.id)
      .then(data => {
      res.status(200).json(data);
    }).catch(error => {
      res.status(400).json(error);
    });
  },

  // highPrice logic
  createHighPrice: (req,res) => {
    db.highPrice.create({
      price: req.body.price,
      positionId: req.body.positionId,
    }).then(data => {
      res.status(200).json({msg:`success-created: highPrice for portfolio with ID: ${data.positionId}`, res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: highPrice not created', res: err});
    });
  },
  updateHighPrice: (req,res) => {
    db.highPrice.update(req.body, {
      where: {id: req.params.id},
      returning: true,
    }).then(data => {
      res.status(200).json({msg: 'success-updated: highPrice', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: highPrice not updated', res: err});
    });
  },
  deleteHighPrice: (req, res) => {
    db.highPrice.destroy({
      where: {id: req.params.id}
    }).then(data => {
      res.status(200).json({msg:'success-deleted: highPrice', res: data});
    }).catch(err => {
      res.status(400).json({msg:'error: highPrice not deleted', res: err});
    });
  },

  // lowPrice logic
  createLowPrice: (req, res) => {
    db.lowPrice.create({
      price: req.body.price,
      positionId: req.body.positionId,
    }).then(data => {
      res.status(200).json({msg: 'success-created: lowPrice', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: lowPrice not created', res: err});
    });
  },
  updateLowPrice: (req, res) => {
    db.lowPrice.update(req.body, {
      where: {id: req.params.id},
      returning: true,
    }).then(data => {
      res.status(200).json({msg: 'success-updated: lowPrice', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: lowPrice not updated', res: err});
    })
  },
  deleteLowPrice: (req, res) => {
    db.lowPrice.destroy({
      where: {id: req.params.id}
    }).then(data => {
      res.status(200).json({msg: 'success-deleted: lowPrice', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: lowPrice not deleted', res: err});
    })
  },

  // trailingStop logic
  createTrailingStop: (req, res) => {
    db.trailingStop.create({
      percent: req.body.percent,
      positionId: req.body.positionId,
    }).then(data => {
      res.status(200).json({msg: 'success-created: trailingStop', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: trailingStop not created', res: err});
    });
  },
  updatedTrailingStop: (req, res) => {
    db.trailingStop.update(req.body, {
      where: {id: req.params.id},
      returning: true,
    }).then(data => {
      res.status(200).json({msg: 'success-updated: trailingStop', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: trailingStop not updated', res: err});
    });
  },
  deleteTrailingStop: (req, res) => {
    db.trailingStop.destroy({
      where: {id: req.params.id}
    }).then(data => {
      res.status(200).json({msg: 'success-deleted: trailingStop', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: trailingStop not deleted', res: err});
    })
  },
};
