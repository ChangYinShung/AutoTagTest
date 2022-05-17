import { ModuleWithProviders, NgModule } from '@angular/core';
import { EC_PAY_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class EcPayConfigModule {
  static forRoot(): ModuleWithProviders<EcPayConfigModule> {
    return {
      ngModule: EcPayConfigModule,
      providers: [EC_PAY_ROUTE_PROVIDERS],
    };
  }
}
