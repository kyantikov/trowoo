import appConfig from '../../config/okta.config';

export default {
  baseUrl: appConfig.issuer.split('/oauth2')[0],
  clientId: appConfig.clientId,
  issuer: appConfig.issuer,
  redirectUri: appConfig.redirectUri,
  logo: '',
  registration: {
    parseSchema: (schema, onSuccess, onFailure) => {
      // handle parseSchema callback
      onSuccess(schema);
    },
    preSubmit: (postData, onSuccess, onFailure) => {
      // handle preSubmit callback
      onSuccess(postData);
    },
    postSubmit: (response, onSuccess, onFailure) => {
      // handle postsubmit callback
      onSuccess(response);
    }
  },
  features: {
    registration: true,
  },
};
