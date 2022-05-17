import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { EcPayComponent } from './components/ec-pay.component';
import { EcPayRoutingModule } from './ec-pay-routing.module';

@NgModule({
  declarations: [EcPayComponent],
  imports: [CoreModule, ThemeSharedModule, EcPayRoutingModule],
  exports: [EcPayComponent],
})
export class EcPayModule {
  static forChild(): ModuleWithProviders<EcPayModule> {
    return {
      ngModule: EcPayModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<EcPayModule> {
    return new LazyModuleFactory(EcPayModule.forChild());
  }
}
