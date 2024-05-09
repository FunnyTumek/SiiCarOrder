import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { DictionaryItem } from '../models/dictionary-item';
import { DictionaryItemType } from '../enums/dictionary-item-type';

@Injectable()
export class DictionariesViewService {

  constructor() { }

  private showOnlyActiveSubject = new BehaviorSubject<boolean>(true);

  private selectedItemSubject = new BehaviorSubject<DictionaryItem | undefined>(undefined);

  private selectedItemTypeSubject = new BehaviorSubject<DictionaryItemType | undefined>(undefined);

  public get showOnlyActive(): Observable<boolean> {
    return this.showOnlyActiveSubject.asObservable();
  }

  public setShowOnlyActive(value: boolean): void {
    this.showOnlyActiveSubject.next(value);
  }

  public get selectedItem(): Observable<DictionaryItem | undefined> {
    return this.selectedItemSubject.asObservable();
  }

  public setSelectedItem(value: DictionaryItem | undefined): void {
    this.selectedItemSubject.next(value);
  }

  public get selectedItemType(): Observable<DictionaryItemType | undefined> {
    return this.selectedItemTypeSubject.asObservable();
  }

  public setSelectedItemType(value: DictionaryItemType | undefined): void {
    this.selectedItemTypeSubject.next(value);
  }
}
