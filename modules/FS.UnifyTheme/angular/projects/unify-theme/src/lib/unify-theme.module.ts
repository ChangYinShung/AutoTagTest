import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { UnifyThemeComponent } from './components/unify-theme.component';
import { UnifyThemeRoutingModule } from './unify-theme-routing.module';

@NgModule({
  declarations: [UnifyThemeComponent],
  imports: [CoreModule, ThemeSharedModule, UnifyThemeRoutingModule],
  exports: [UnifyThemeComponent],
})
export class UnifyThemeModule {
  static forChild(): ModuleWithProviders<UnifyThemeModule> {
    return {
      ngModule: UnifyThemeModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<UnifyThemeModule> {
    return new LazyModuleFactory(UnifyThemeModule.forChild());
  }
}
