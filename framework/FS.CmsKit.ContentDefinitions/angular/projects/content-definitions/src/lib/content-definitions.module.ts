import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ContentDefinitionsComponent } from './components/content-definitions.component';
import { ContentDefinitionsRoutingModule } from './content-definitions-routing.module';

@NgModule({
  declarations: [ContentDefinitionsComponent],
  imports: [CoreModule, ThemeSharedModule, ContentDefinitionsRoutingModule],
  exports: [ContentDefinitionsComponent],
})
export class ContentDefinitionsModule {
  static forChild(): ModuleWithProviders<ContentDefinitionsModule> {
    return {
      ngModule: ContentDefinitionsModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ContentDefinitionsModule> {
    return new LazyModuleFactory(ContentDefinitionsModule.forChild());
  }
}
