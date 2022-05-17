import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { EmailingManagementComponent } from './components/emailing-management.component';
import { EmailingManagementRoutingModule } from './emailing-management-routing.module';

@NgModule({
  declarations: [EmailingManagementComponent],
  imports: [CoreModule, ThemeSharedModule, EmailingManagementRoutingModule],
  exports: [EmailingManagementComponent],
})
export class EmailingManagementModule {
  static forChild(): ModuleWithProviders<EmailingManagementModule> {
    return {
      ngModule: EmailingManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<EmailingManagementModule> {
    return new LazyModuleFactory(EmailingManagementModule.forChild());
  }
}
