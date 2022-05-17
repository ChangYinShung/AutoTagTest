import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'EmailingManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44395',
    redirectUri: baseUrl,
    clientId: 'EmailingManagement_App',
    responseType: 'code',
    scope: 'offline_access EmailingManagement role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44395',
      rootNamespace: 'FS.Abp.EmailingManagement',
    },
    EmailingManagement: {
      url: 'https://localhost:44381',
      rootNamespace: 'FS.Abp.EmailingManagement',
    },
  },
} as Environment;
