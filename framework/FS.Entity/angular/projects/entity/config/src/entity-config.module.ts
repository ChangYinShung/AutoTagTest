import { ModuleWithProviders, NgModule } from '@angular/core';
import { ENTITY_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class EntityConfigModule {
  static forRoot(): ModuleWithProviders<EntityConfigModule> {
    return {
      ngModule: EntityConfigModule,
      providers: [ENTITY_ROUTE_PROVIDERS],
    };
  }
}
