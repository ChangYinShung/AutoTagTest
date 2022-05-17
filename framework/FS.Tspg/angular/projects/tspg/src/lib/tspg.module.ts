import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { TspgComponent } from './components/tspg.component';
import { TspgRoutingModule } from './tspg-routing.module';

@NgModule({
  declarations: [TspgComponent],
  imports: [CoreModule, ThemeSharedModule, TspgRoutingModule],
  exports: [TspgComponent],
})
export class TspgModule {
  static forChild(): ModuleWithProviders<TspgModule> {
    return {
      ngModule: TspgModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<TspgModule> {
    return new LazyModuleFactory(TspgModule.forChild());
  }
}
