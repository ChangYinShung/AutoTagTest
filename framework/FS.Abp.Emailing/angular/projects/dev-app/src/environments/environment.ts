import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Emailing',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44304',
    redirectUri: baseUrl,
    clientId: 'Emailing_App',
    responseType: 'code',
    scope: 'offline_access Emailing role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44304',
      rootNamespace: 'FS.Abp.Emailing',
    },
    Emailing: {
      url: 'https://localhost:44398',
      rootNamespace: 'FS.Abp.Emailing',
    },
  },
} as Environment;
