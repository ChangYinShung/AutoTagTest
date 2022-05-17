import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
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
    scope: 'offline_access ContentDefinitions',
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
