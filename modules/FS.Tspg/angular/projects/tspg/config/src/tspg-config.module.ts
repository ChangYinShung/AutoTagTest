import { ModuleWithProviders, NgModule } from '@angular/core';
import { TSPG_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class TspgConfigModule {
  static forRoot(): ModuleWithProviders<TspgConfigModule> {
    return {
      ngModule: TspgConfigModule,
      providers: [TSPG_ROUTE_PROVIDERS],
    };
  }
}
