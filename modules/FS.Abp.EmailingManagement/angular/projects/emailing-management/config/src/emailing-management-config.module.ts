import { ModuleWithProviders, NgModule } from '@angular/core';
import { EMAILING_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class EmailingManagementConfigModule {
  static forRoot(): ModuleWithProviders<EmailingManagementConfigModule> {
    return {
      ngModule: EmailingManagementConfigModule,
      providers: [EMAILING_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
