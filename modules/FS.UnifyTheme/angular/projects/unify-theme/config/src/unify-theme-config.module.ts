import { ModuleWithProviders, NgModule } from '@angular/core';
import { UNIFY_THEME_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class UnifyThemeConfigModule {
  static forRoot(): ModuleWithProviders<UnifyThemeConfigModule> {
    return {
      ngModule: UnifyThemeConfigModule,
      providers: [UNIFY_THEME_ROUTE_PROVIDERS],
    };
  }
}
