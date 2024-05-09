import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DictionariesContainerComponent } from './dictionaries-container.component';
import { DictionaryListComponent } from './components/dictionary-list/dictionary-list.component';
import { DictionaryItemType } from './enums/dictionary-item-type';

const routes: Routes = [
  {
    path: '',
    component: DictionariesContainerComponent,
    children: [
      {
        path: '',
        redirectTo: 'brands',
        pathMatch: 'full',
      },
      {
        path: 'brands',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.Brand },
      },
      {
        path: 'models',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.Model },
      },
      {
        path: 'equipment-versions',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.EquipmentVersion },
      },
      {
        path: 'classes',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.Class },
      },
      {
        path: 'engines',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.Engine },
      },
      {
        path: 'gearboxes',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.Gearbox },
      },
      {
        path: 'colors',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.Color },
      },
      {
        path: 'interiors',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.Interior },
      },
      {
        path: 'additional-equipments',
        component: DictionaryListComponent,
        data: { selectedType: DictionaryItemType.AdditionalEquipment },
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DictionariesRoutingModule { }
