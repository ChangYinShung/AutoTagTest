import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'ContentDefinitions',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44309',
    redirectUri: baseUrl,
    clientId: 'ContentDefinitions_App',
    responseType: 'code',
    scope: 'offline_access ContentDefinitions role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44309',
      rootNamespace: 'FS.CmsKit.ContentDefinitions',
    },
    ContentDefinitions: {
      url: 'https://localhost:44346',
      rootNamespace: 'FS.CmsKit.ContentDefinitions',
    },
  },
} as Environment;
