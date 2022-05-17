import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { PaymentServiceComponent } from './components/payment-service.component';
import { PaymentServiceRoutingModule } from './payment-service-routing.module';

@NgModule({
  declarations: [PaymentServiceComponent],
  imports: [CoreModule, ThemeSharedModule, PaymentServiceRoutingModule],
  exports: [PaymentServiceComponent],
})
export class PaymentServiceModule {
  static forChild(): ModuleWithProviders<PaymentServiceModule> {
    return {
      ngModule: PaymentServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<PaymentServiceModule> {
    return new LazyModuleFactory(PaymentServiceModule.forChild());
  }
}
