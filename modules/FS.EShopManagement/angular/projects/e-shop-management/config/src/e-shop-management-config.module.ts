import { ModuleWithProviders, NgModule } from '@angular/core';
import { E_SHOP_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class EShopManagementConfigModule {
  static forRoot(): ModuleWithProviders<EShopManagementConfigModule> {
    return {
      ngModule: EShopManagementConfigModule,
      providers: [E_SHOP_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
