import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'EShopManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44367',
    redirectUri: baseUrl,
    clientId: 'EShopManagement_App',
    responseType: 'code',
    scope: 'offline_access EShopManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44367',
      rootNamespace: 'FS.EShopManagement',
    },
    EShopManagement: {
      url: 'https://localhost:44340',
      rootNamespace: 'FS.EShopManagement',
    },
  },
} as Environment;
