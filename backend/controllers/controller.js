const db = require('../database/models/index');
const Sequelize = require('sequelize');

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
        res.status(200).json({msg:'success-found', res: data})
      }
      res.status(201).json({msg:'success-created', res: data});
    }).catch(err => {
      res.status(400).json({msg: 'error', res: err});
    });
  },

  // updates an existing security -- regular users will likely be unable to access this feature
  updateSecurity: (req, res) => {
    db.security.update(req.body, {
      where: {
        id: req.params.id,
      },
      returning: true,
    }).then(data => {
      // console.log(data);
      res.json({msg:'success-updated: security', res: data[1]});
    }).catch(err => {
      res.json({msg: 'error: security not updated', res: err});
    });
  },

  deleteSecurity: (req, res) => {
    db.security.destroy({
      where: {
        id: req.params.id,
      }
    }).then(data => {
      res.json({res:data});
    })
  },
};
