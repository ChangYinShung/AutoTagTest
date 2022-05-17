import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Entity',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44398',
    redirectUri: baseUrl,
    clientId: 'Entity_App',
    responseType: 'code',
    scope: 'offline_access Entity role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44398',
      rootNamespace: 'FS.Entity',
    },
    Entity: {
      url: 'https://localhost:44362',
      rootNamespace: 'FS.Entity',
    },
  },
} as Environment;
