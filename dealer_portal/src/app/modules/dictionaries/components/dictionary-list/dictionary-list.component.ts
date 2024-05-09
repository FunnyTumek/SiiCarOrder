import { Component, EventEmitter, OnChanges, OnDestroy, OnInit, Output, SimpleChange, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { DictionaryItemType } from '../../enums/dictionary-item-type';
import { DictionaryItem } from '../../models/dictionary-item';
import { optionColumns } from './option-columns';
import { DictionariesViewService } from '../../services/dictionaries-view.service';
import { DictionariesService } from '../../services/fetch/dictionaries.service';

@Component({
  selector: 'sii-dictionary-list',
  templateUrl: './dictionary-list.component.html',
  styleUrls: ['./dictionary-list.component.scss']
})
export class DictionaryListComponent implements OnInit, OnChanges, OnDestroy {

  private subscriptions: Subscription;
  private showOnlyActive: boolean = true;

  @Output() itemSelected = new EventEmitter<DictionaryItem>();

  type?: DictionaryItemType = undefined;
  options: DictionaryItem[] = [];
  selectedItem?: DictionaryItem = undefined;
  columns: string[] = [
    'active',
    'code',
  ];

  constructor(private route: ActivatedRoute, private viewService: DictionariesViewService, private fetchService: DictionariesService) {
    this.subscriptions = this.viewService.showOnlyActive.subscribe(value => {
      if (this.showOnlyActive === value) return;
      this.showOnlyActive = value;
      this.fetchData();
    });
    this.subscriptions.add(
      this.viewService.selectedItem.subscribe(item => {
        if (this.selectedItem === undefined && item === undefined) return;
        if (this.selectedItem !== undefined && item === undefined) {
          this.selectedItem = undefined;
          return;
        }
        if (item?.code === this.selectedItem?.code) {
          this.selectedItem = item;
          this.options = this.options
            .map(option => option.code === item?.code ? item : option)
            .filter(option => this.showOnlyActive ? option.availability : true);
          return;
        }
      }));
  }

  ngOnInit(): void {
    this.subscriptions.add(
      this.route.data.subscribe(data => {
        if (data.hasOwnProperty('selectedType')) {
          this.type = data['selectedType'];
          if (this.type) this.columns = optionColumns[this.type];
          this.viewService.setSelectedItemType(this.type);
          this.fetchData();
        }
      }));
  }

  ngOnChanges(changes: SimpleChanges): void {
    const change: SimpleChange | undefined = changes["showOnlyActive"];
    if (!change || change.currentValue === change.previousValue) return;
    this.fetchData();
  }

  ngOnDestroy(): void {
    if (!this.subscriptions.closed) this.subscriptions.unsubscribe();
  }

  fetchData(): void {
    if (this.type === undefined) {
      console.error('Requested data for undefined type');
      return;
    }
    this.fetchService.getOptionsForType(this.type, this.showOnlyActive).subscribe({
      next: value => this.options = value,
      error: err => console.error(err),
    })
  }

  onRowSelected(row: DictionaryItem): void {
    this.selectedItem = row;
    this.viewService.setSelectedItem(row);
  }

}
