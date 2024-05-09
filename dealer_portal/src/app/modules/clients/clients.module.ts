import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientsContainerComponent } from './clients-container.component';
import { RouterModule, Routes } from '@angular/router';
import { QuickActionsService } from 'src/app/shared/services/global-gui/quick-actions.service';

const routes: Routes = [
  { path: '', component: ClientsContainerComponent },
];

@NgModule({
  declarations: [
    ClientsContainerComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ]
})
export class ClientsModule { }
