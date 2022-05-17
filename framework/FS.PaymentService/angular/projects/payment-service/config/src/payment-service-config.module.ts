import { ModuleWithProviders, NgModule } from '@angular/core';
import { PAYMENT_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class PaymentServiceConfigModule {
  static forRoot(): ModuleWithProviders<PaymentServiceConfigModule> {
    return {
      ngModule: PaymentServiceConfigModule,
      providers: [PAYMENT_SERVICE_ROUTE_PROVIDERS],
    };
  }
}
