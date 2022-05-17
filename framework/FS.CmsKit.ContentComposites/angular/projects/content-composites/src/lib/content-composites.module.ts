import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ContentCompositesComponent } from './components/content-composites.component';
import { ContentCompositesRoutingModule } from './content-composites-routing.module';

@NgModule({
  declarations: [ContentCompositesComponent],
  imports: [CoreModule, ThemeSharedModule, ContentCompositesRoutingModule],
  exports: [ContentCompositesComponent],
})
export class ContentCompositesModule {
  static forChild(): ModuleWithProviders<ContentCompositesModule> {
    return {
      ngModule: ContentCompositesModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ContentCompositesModule> {
    return new LazyModuleFactory(ContentCompositesModule.forChild());
  }
}
