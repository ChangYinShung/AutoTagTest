import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'EcPay',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44368',
    redirectUri: baseUrl,
    clientId: 'EcPay_App',
    responseType: 'code',
    scope: 'offline_access EcPay',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44368',
      rootNamespace: 'FS.Payment.EcPay',
    },
    EcPay: {
      url: 'https://localhost:44312',
      rootNamespace: 'FS.Payment.EcPay',
    },
  },
} as Environment;
