import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'ContentComposites',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44395',
    redirectUri: baseUrl,
    clientId: 'ContentComposites_App',
    responseType: 'code',
    scope: 'offline_access ContentComposites role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44395',
      rootNamespace: 'FS.CmsKit.ContentComposites',
    },
    ContentComposites: {
      url: 'https://localhost:44328',
      rootNamespace: 'FS.CmsKit.ContentComposites',
    },
  },
} as Environment;
