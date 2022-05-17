import { ModuleWithProviders, NgModule } from '@angular/core';
import { CONTENT_DEFINITIONS_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ContentDefinitionsConfigModule {
  static forRoot(): ModuleWithProviders<ContentDefinitionsConfigModule> {
    return {
      ngModule: ContentDefinitionsConfigModule,
      providers: [CONTENT_DEFINITIONS_ROUTE_PROVIDERS],
    };
  }
}
