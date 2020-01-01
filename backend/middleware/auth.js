const OktaJwtVerifier = require('@okta/jwt-verifier');

const oktaJwtVerifier = new OktaJwtVerifier({
  issuer: process.env.ISSUER,
  clientId: process.env.CLIENT_ID
});

module.exports = async (req, res, next) => {
  try {
    const { authorization } = req.headers;
    if (!authorization) {
      throw new Error('You must send an Authorization header');
    }
    const [authType, token] = authorization.trim().split(' ');
    if (authType !== 'Bearer') {
      throw new Error('Expected a Bearer token');
    }
    const authResult = await oktaJwtVerifier.verifyAccessToken(token, 'api://default');
    req.userContex = authResult; // console.log(authResult);
    next()
  } catch (error){
    // res.status(400).json({data:error});
    next(error.message);
  }
};
