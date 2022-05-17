import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { EShopManagementComponent } from './components/e-shop-management.component';
import { EShopManagementRoutingModule } from './e-shop-management-routing.module';

@NgModule({
  declarations: [EShopManagementComponent],
  imports: [CoreModule, ThemeSharedModule, EShopManagementRoutingModule],
  exports: [EShopManagementComponent],
})
export class EShopManagementModule {
  static forChild(): ModuleWithProviders<EShopManagementModule> {
    return {
      ngModule: EShopManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<EShopManagementModule> {
    return new LazyModuleFactory(EShopManagementModule.forChild());
  }
}
