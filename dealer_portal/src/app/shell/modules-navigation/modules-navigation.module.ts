import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModulesNavigationComponent } from './modules-navigation.component';
import { MatTabsModule } from '@angular/material/tabs';

const MATERIAL = [MatTabsModule];

@NgModule({
  declarations: [
    ModulesNavigationComponent
  ],
  imports: [
    CommonModule,
    ...MATERIAL
  ],
  exports: [ModulesNavigationComponent]
})
export class ModulesNavigationModule { }
