import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { EntityComponent } from './components/entity.component';
import { EntityRoutingModule } from './entity-routing.module';

@NgModule({
  declarations: [EntityComponent],
  imports: [CoreModule, ThemeSharedModule, EntityRoutingModule],
  exports: [EntityComponent],
})
export class EntityModule {
  static forChild(): ModuleWithProviders<EntityModule> {
    return {
      ngModule: EntityModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<EntityModule> {
    return new LazyModuleFactory(EntityModule.forChild());
  }
}
