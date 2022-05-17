import { ModuleWithProviders, NgModule } from '@angular/core';
import { CONTENT_COMPOSITES_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ContentCompositesConfigModule {
  static forRoot(): ModuleWithProviders<ContentCompositesConfigModule> {
    return {
      ngModule: ContentCompositesConfigModule,
      providers: [CONTENT_COMPOSITES_ROUTE_PROVIDERS],
    };
  }
}
