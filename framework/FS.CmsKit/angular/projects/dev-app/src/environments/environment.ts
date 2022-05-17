import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CmsKit',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44325',
    redirectUri: baseUrl,
    clientId: 'CmsKit_App',
    responseType: 'code',
    scope: 'offline_access CmsKit role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44325',
      rootNamespace: 'FS.CmsKit',
    },
    CmsKit: {
      url: 'https://localhost:44319',
      rootNamespace: 'FS.CmsKit',
    },
  },
} as Environment;
