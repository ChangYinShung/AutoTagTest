import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'PaymentService',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44345',
    redirectUri: baseUrl,
    clientId: 'PaymentService_App',
    responseType: 'code',
    scope: 'offline_access PaymentService',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44345',
      rootNamespace: 'FS.PaymentService',
    },
    PaymentService: {
      url: 'https://localhost:44389',
      rootNamespace: 'FS.PaymentService',
    },
  },
} as Environment;
