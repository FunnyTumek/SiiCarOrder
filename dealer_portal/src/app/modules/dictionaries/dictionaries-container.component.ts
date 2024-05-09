import { ChangeDetectorRef, Component, OnDestroy } from '@angular/core';
import { MatButtonToggleChange } from '@angular/material/button-toggle';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { Subscription, switchMap, tap } from 'rxjs';
import { QuickActionGroup } from 'src/app/shared/services/global-gui/quick-action.model';
import { QuickActionsService } from 'src/app/shared/services/global-gui/quick-actions.service';
import { EditOptionDialogComponent } from './components/edit-option-dialog/edit-option-dialog.component';
import { dictionaryItemTypePaths } from './dictionary-item-type-paths';
import { DictionaryItemType } from './enums/dictionary-item-type';
import { DictionaryItem } from './models/dictionary-item';
import { DictionariesViewService } from './services/dictionaries-view.service';
import { DictionariesService } from './services/fetch/dictionaries.service';

@Component({
  selector: 'sii-dictionaries-container',
  templateUrl: './dictionaries-container.component.html',
  styleUrls: ['./dictionaries-container.component.scss']
})
export class DictionariesContainerComponent implements OnDestroy {

  private showOnlyActive: boolean = true;
  private subscriptions: Subscription;
  private selectedItem: DictionaryItem | undefined;
  private moduleActions: QuickActionGroup[] = [];

  types: DictionaryItemType[] = Object.keys(DictionaryItemType).map(key => DictionaryItemType[key as keyof typeof DictionaryItemType]);
  selectedType?: DictionaryItemType;

  constructor(
    private cd: ChangeDetectorRef,
    private quickActions: QuickActionsService,
    private dictionariesViewService: DictionariesViewService,
    private dictionariesFetchService: DictionariesService,
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog,
  ) {
    this.subscriptions =
      this.route.data
        .pipe(
          tap(data => this.onActiveTypeChanged(data)),
          switchMap(() => this.dictionariesViewService.showOnlyActive),
          tap(showOnlyActive => this.refreshActions(showOnlyActive))
        ).subscribe();
    this.subscriptions.add(
      this.dictionariesViewService.selectedItem
        .subscribe(item => {
          if (this.selectedItem !== item) {
            this.selectedItem = item;
            this.refreshActions();
          }
        }));
    this.subscriptions.add(
      this.dictionariesViewService.selectedItemType
        .subscribe(type => {
          if (type) {
            this.selectedType = type;
            this.cd.detectChanges();
          }
        }));
  }

  ngOnDestroy(): void {
    if (!this.subscriptions.closed) this.subscriptions.unsubscribe();
  }

  onSelectedDictionaryChanged(event: MatButtonToggleChange): void {
    this.dictionariesViewService.setSelectedItem(undefined);
    this.dictionariesViewService.setSelectedItemType(event.value);
    if (this.selectedType === undefined) return;
    const newSubpath: string = dictionaryItemTypePaths[this.selectedType];
    this.router.navigate([newSubpath], { relativeTo: this.route, queryParamsHandling: 'preserve' });
    this.refreshActions();
  }

  private onActiveTypeChanged(data: Data): void {
    if (data.hasOwnProperty('selectedType')) {
      this.selectedType = data['selectedType'];
    }
  }

  private refreshActions(showOnlyActive: boolean | undefined = undefined): void {
    if (showOnlyActive !== undefined) {
      this.showOnlyActive = showOnlyActive;
    }
    this.moduleActions = this.createModuleActions();
    this.quickActions.elementRef.panelActions = this.moduleActions;
    this.quickActions.showModuleActionPanel(this.moduleActions);
  }

  private createModuleActions(): QuickActionGroup[] {
    return [{
      label: 'View',
      actions: [
        {
          enabled: true,
          label: this.showOnlyActive ? 'Show ALL' : 'Show only ACTIVE',
          handler: () => {
            this.dictionariesViewService.setShowOnlyActive(!this.showOnlyActive);
            this.dictionariesViewService.setSelectedItem(undefined);
          }
        }
      ],
    },
    {
      label: 'Actions',
      actions: [
        {
          enabled: !!this.selectedItem,
          label: 'Edit',
          handler: () => {
            this.openEditDialog();
          }
        },
        {
          enabled: !!this.selectedItem,
          label: this.selectedItem?.availability ?? true ? 'Mark as inactive' : 'Mark as active',
          handler: () => {
            this.toggleSelectedItemActive();
          }
        }
      ]
    }];
  }

  openEditDialog(): void {
    const dialogRef = this.dialog.open(EditOptionDialogComponent, {
      width: '300px',
      data: { type: this.selectedType, option: this.selectedItem },
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (!this.selectedType) return;
        this.dictionariesFetchService.updateOptionForType(this.selectedType, result)
          .subscribe({
            next: () => {
              this.selectedItem = result;
              this.dictionariesViewService.setSelectedItem(this.selectedItem);
            },
            error: err => { console.log('Could not update option', this.selectedType, result, err) }
          })
      }
    });
  }

  toggleSelectedItemActive(): void {
    if (!this.selectedType || !this.selectedItem) return;
    this.selectedItem.availability = !this.selectedItem.availability;
    this.dictionariesFetchService.updateOptionForType(this.selectedType, this.selectedItem)
      .subscribe({
        next: () => {
          this.dictionariesViewService.setSelectedItem(this.selectedItem);
          this.refreshActions();
        },
        error: err => { console.log('Could not update option', this.selectedType, this.selectedItem, err) }
      })
  }

}
