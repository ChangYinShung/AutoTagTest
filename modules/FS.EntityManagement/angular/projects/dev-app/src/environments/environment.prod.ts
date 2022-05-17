import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'EntityManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44356',
    redirectUri: baseUrl,
    clientId: 'EntityManagement_App',
    responseType: 'code',
    scope: 'offline_access EntityManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44356',
      rootNamespace: 'FS.EntityManagement',
    },
    EntityManagement: {
      url: 'https://localhost:44372',
      rootNamespace: 'FS.EntityManagement',
    },
  },
} as Environment;
