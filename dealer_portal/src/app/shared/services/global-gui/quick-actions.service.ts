import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { QuickActionsPanelComponent } from 'src/app/shell/quick-actions-panel/quick-actions-panel.component';
import { QuickActionGroup } from './quick-action.model';

@Injectable({
  providedIn: 'root'
})
export class QuickActionsService {
  elementRef!: QuickActionsPanelComponent;

  constructor() { }

  boundPanel(elementRef: QuickActionsPanelComponent) {
    this.elementRef = elementRef;
  }

  closePanel() {
    if (this.elementRef !== undefined) {
      return this.elementRef?.closePanel();
    }
    return of(true);
  }

  showModuleActionPanel(actions: QuickActionGroup[]) {
    if (this.elementRef !== undefined) {
      return this.elementRef.openPanel(actions);
    }
    return of(true);
  }
}
