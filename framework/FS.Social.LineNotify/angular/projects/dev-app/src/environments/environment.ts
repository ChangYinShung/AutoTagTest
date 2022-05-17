import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'LineNotify',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44387',
    redirectUri: baseUrl,
    clientId: 'LineNotify_App',
    responseType: 'code',
    scope: 'offline_access LineNotify role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44387',
      rootNamespace: 'FS.Social.LineNotify',
    },
    LineNotify: {
      url: 'https://localhost:44386',
      rootNamespace: 'FS.Social.LineNotify',
    },
  },
} as Environment;
