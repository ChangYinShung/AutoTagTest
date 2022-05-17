import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { EntityManagementComponent } from './components/entity-management.component';
import { EntityManagementRoutingModule } from './entity-management-routing.module';

@NgModule({
  declarations: [EntityManagementComponent],
  imports: [CoreModule, ThemeSharedModule, EntityManagementRoutingModule],
  exports: [EntityManagementComponent],
})
export class EntityManagementModule {
  static forChild(): ModuleWithProviders<EntityManagementModule> {
    return {
      ngModule: EntityManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<EntityManagementModule> {
    return new LazyModuleFactory(EntityManagementModule.forChild());
  }
}
