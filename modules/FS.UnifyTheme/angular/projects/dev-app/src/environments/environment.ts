import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'UnifyTheme',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44373',
    redirectUri: baseUrl,
    clientId: 'UnifyTheme_App',
    responseType: 'code',
    scope: 'offline_access UnifyTheme role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44373',
      rootNamespace: 'FS.UnifyTheme',
    },
    UnifyTheme: {
      url: 'https://localhost:44331',
      rootNamespace: 'FS.UnifyTheme',
    },
  },
} as Environment;
