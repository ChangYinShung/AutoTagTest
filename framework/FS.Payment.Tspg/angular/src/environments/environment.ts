import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Tspg',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44357',
    redirectUri: baseUrl,
    clientId: 'Tspg_App',
    responseType: 'code',
    scope: 'offline_access Tspg',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44357',
      rootNamespace: 'FS.Payment.Tspg',
    },
  },
} as Environment;
