const Sequelize = require('sequelize');
const db = require('../services/dbService');

const helper = require('./helper');

// TODO: [validation] -- when creating a trailing stop for a position, check if that position has an opening date and cost
// ^^^^ also for high/lowPrice
// TODO: place db querying logic into singular service file in order to decouple that logic from requests
// TODO: price-to-book ratios?

module.exports = {
  // security logic
  createSecurity: (req,res) => {
    let body = req.body;
    db.createSecurity(body.name, body.ticker).then(data => {
      if(data[1] === false){
        res.status(200).json({msg:'success-found: security', res: data})
      }
      res.status(201).json({msg:'success-created: security', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: security not created', res: err});
    });
  },
  retrieveAllSecurities: (req,res) => {
     db.retrieveAllSecurities().then(data => {
      res.status(200).json({msg: 'success-found: all securities', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: securities not found', res: err});
    });
  },
  // regular users will likely be unable to access updating/deleting securities
  // should update,delete be done with ticker instead?
  updateSecurity: (req, res) => {
    let body = req.body;
    let params = req.params;
    db.updateSecurity(body, params.id).then(data => {
      res.status(200).json({msg:'success-updated: security', res: data[1]});
    }).catch(err => {
      res.status(400).json({msg: 'error: security not updated', res: err});
    });
  },
  // security cannot be deleted if a position is open on that security
  deleteSecurity: (req, res) => {
    let params = req.params;
    db.deleteSecurity(params.id).then(data => {
      res.status(200).json({msg: 'success-deleted: security', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: security not deleted', res: err});
    });
  },

  // portfolio logic
  createPortfolio: (req, res) => {
    db.portfolio.create({
      name: req.body.name,
      userId: req.body.userId,
    }).then(data => {
      res.status(201).json({msg:'success-created: portfolio', res: data});
    }).catch(err => {
      console.error(err);
      res.status(400).json({msg: 'error: portfolio not created', res: err});
    });
  },
  retrieveUserPortfolios: (req, res) => {
    db.portfolio.findAll({
      where: {userId: req.body.userId},
      include: [{
        model: db.position,
        include: [
          {model: db.security},
          {model: db.lowPrice},
          {model: db.highPrice},
          {model: db.trailingStop},
        ],
      }],
    }).then(data => {
      res.status(200).json({
        msg:`success-found: ${data.length} portfolio(s)`, res: data});
    }).catch(err => {
      res.status(400).json({msg:'error: portfolios not found', res: err});
    });
  },
  updatePortfolio: (req,res) => {
    if(req.body.userId){
      return res.status(400).json({msg:'error: userId cannot be changed'});
    }
    db.portfolio.update(req.body, {
      where: {id: req.params.id,}, // userId: req.userContext.userinfo.id
      returning: true,
    }).then(data => {
      res.status(200).json({msg: 'success-updated: portfolio', res: data[1]});
    }).catch(err => {
      res.status(400).json({msg: 'error: portfolio not updated', res: err});
    });
  },
  // deletes portfolio only if the portfolio is empty
  deletePortfolio: (req, res) => {
    db.portfolio.destroy({
      where: {id: req.params.id},
    }).then(data => {
      res.status(200).json({msg: 'success-deleted: portfolio', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: portfolio not deleted', res: err});
    });
  },

  // position logic
  createPosition: (req, res) => {
    db.position.create({
      openedDate: req.body.openedDate,
      cost: req.body.cost,
      portfolioId: req.body.portfolioId,
      securityId: req.body.securityId,
    }).then(data => {
        res.status(201).json({msg:'success-created: position', res: data});
      }).catch(err => {
        res.status(400).json({msg:'error: position not created', res: err});
    });
  },
  retrievePosition: (req,res) => {
    db.position.findByPk(
      req.body.id,
      {include:[
          {model: db.security},
          {model: db.lowPrice},
          {model: db.highPrice},
          {model: db.trailingStop}
        ]
      }
    ).then(data => {
      res.status(200).json({msg: 'success-found: position', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: position not found', res: err});
    });
  },
  // will update only cost or openedDate or both depending on input
  updatePosition: (req, res) => {
    db.position.update(req.body,{
      where: {id: req.params.id},
      returning: true,
    }).then(data => {
      res.status(200).json({msg:'success-updated: position', res: data[1]});
    }).catch(err => {
      res.status(400).json({msg:'error: position not updated', res: err});
    });
  },
  // TODO: find out if deleting a position will also delete rows in low/highPrice and trailingStop with that positions ID
  deletePosition: (req, res) => {
    db.position.destroy({
      where: {id: req.params.id}
    }).then(data => {
      res.status(200).json({msg:'success-deleted: position', res: data});
    }).catch(err => {
      res.status(400).json({msg:'error: position not deleted', res: err});
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
