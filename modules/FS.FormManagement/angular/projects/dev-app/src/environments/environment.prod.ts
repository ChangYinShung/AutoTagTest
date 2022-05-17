import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'FormManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44380',
    redirectUri: baseUrl,
    clientId: 'FormManagement_App',
    responseType: 'code',
    scope: 'offline_access FormManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44380',
      rootNamespace: 'FS.FormManagement',
    },
    FormManagement: {
      url: 'https://localhost:44378',
      rootNamespace: 'FS.FormManagement',
    },
  },
} as Environment;
