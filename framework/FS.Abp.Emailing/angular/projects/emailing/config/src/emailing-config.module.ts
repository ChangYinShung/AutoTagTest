import { ModuleWithProviders, NgModule } from '@angular/core';
import { EMAILING_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class EmailingConfigModule {
  static forRoot(): ModuleWithProviders<EmailingConfigModule> {
    return {
      ngModule: EmailingConfigModule,
      providers: [EMAILING_ROUTE_PROVIDERS],
    };
  }
}
