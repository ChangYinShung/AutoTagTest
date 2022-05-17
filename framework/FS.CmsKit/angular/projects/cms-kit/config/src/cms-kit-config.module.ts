import { ModuleWithProviders, NgModule } from '@angular/core';
import { CMS_KIT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CmsKitConfigModule {
  static forRoot(): ModuleWithProviders<CmsKitConfigModule> {
    return {
      ngModule: CmsKitConfigModule,
      providers: [CMS_KIT_ROUTE_PROVIDERS],
    };
  }
}
