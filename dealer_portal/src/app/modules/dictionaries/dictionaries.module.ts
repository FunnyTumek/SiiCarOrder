import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DictionariesContainerComponent } from './dictionaries-container.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { DictionaryListComponent } from './components/dictionary-list/dictionary-list.component';
import { MatButtonModule } from '@angular/material/button';
import { DictionariesViewService } from './services/dictionaries-view.service';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { DictionariesRoutingModule } from './dictionaries-routing.module';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { EditOptionDialogComponent } from './components/edit-option-dialog/edit-option-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    DictionariesContainerComponent,
    DictionaryListComponent,
    EditOptionDialogComponent,
  ],
  imports: [
    CommonModule,
    DictionariesRoutingModule,
    MatTabsModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatCheckboxModule,
    MatButtonToggleModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    MatSelectModule,
  ],
  exports: [
    DictionariesContainerComponent,
  ],
  providers: [
    DictionariesViewService,
  ]
})
export class DictionariesModule { }
