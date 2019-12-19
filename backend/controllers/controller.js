const db = require('../database/models/index');
const Sequelize = require('sequelize');

const helper = require('./helper');

// TODO: [validation] -- when creating a trailing stop for a position, check if that position has an opening date and cost
// ^^^^ also for high/lowPrice

module.exports = {
  // security logic

  // creates a new security if the security does not already exist
  createSecurity: (req,res) => {
    db.security.findOrCreate({
      where: {ticker: req.body.ticker},
      defaults: {
        name: req.body.name,
        ticker: req.body.ticker
      }
    }).then(data => {
      if(data[1] === false){
        res.status(200).json({msg:'success-found: security', res: data})
      }
      res.status(201).json({msg:'success-created: security', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: security not created', res: err});
    });
  },

  // regular users will likely be unable to access updating/deleting securities
  // should update,delete be done with ticker instead?
  updateSecurity: (req, res) => {
    db.security.update(req.body, {
      where: {
        id: req.params.id,
      },
      returning: true,
    }).then(data => {
      // console.log(data);
      res.status(200).json({msg:'success-updated: security', res: data[1]});
    }).catch(err => {
      res.status(400).json({msg: 'error: security not updated', res: err});
    });
  },

  deleteSecurity: (req, res) => {
    db.security.destroy({
      where: {
        id: req.params.id,
      }
    }).then(data => {
      res.status(200).json({msg: 'success-deleted: security', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error: security not deleted', res: err});
    });
  },

  // portfolio logic
  // creates a portfolio for a user -- userId located in body
  createPortfolio: (req, res) => {
    db.portfolio.create({
      name: req.body.name,
      userId: req.params.userId,
    }).then(data => {
      res.status(201).json({msg:'success-created: portfolio', res: data});
    }).catch(err => {
      console.error(err);
      res.status(400).json({msg: 'error: portfolio not created', res: err});
    });
  },

  // retrieves a users portfolios
  retrieveUserPortfolios: (req, res) => {
    db.portfolio.findAll({
      where: {userId: req.params.userId},
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
  // creates position within a portfolio if that position doesnt already exist elsewhere
  createPosition: (req, res) => {
    db.position.create({
      openedDate: req.body.openedDate,
      cost: req.body.cost,
      portfolioId: req.params.portfolioId,
      securityId: req.params.securityId,
    }).then(data => {
        res.status(201).json({msg:'success-created: position', res: data});
      }).catch(err => {
        res.status(400).json({msg:'error: position not created', res: err});
    });
  },

  deletePosition: (req, res) => {
    db.position.destroy({
      where: {id: req.params.id}
    }).then(data => {
      res.status(200).json({msg:'success-deleted: position', res: data});
    }).catch(err => {
      res.status(400).json({msg:'error: position not deleted', res: err});
    });
  },
};
