import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Tspg',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44346',
    redirectUri: baseUrl,
    clientId: 'Tspg_App',
    responseType: 'code',
    scope: 'offline_access Tspg role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44346',
      rootNamespace: 'FS.Tspg',
    },
    Tspg: {
      url: 'https://localhost:44350',
      rootNamespace: 'FS.Tspg',
    },
  },
} as Environment;
