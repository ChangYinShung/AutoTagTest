import { ModuleWithProviders, NgModule } from '@angular/core';
import { ENTITY_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class EntityManagementConfigModule {
  static forRoot(): ModuleWithProviders<EntityManagementConfigModule> {
    return {
      ngModule: EntityManagementConfigModule,
      providers: [ENTITY_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
