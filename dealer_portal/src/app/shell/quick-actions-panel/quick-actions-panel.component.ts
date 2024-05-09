import { animate, animateChild, query, state, style, transition, trigger } from '@angular/animations';
import { Component, HostBinding, HostListener } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Subject } from 'rxjs/internal/Subject';
import { QuickActionGroup, QuickActionModel } from 'src/app/shared/services/global-gui/quick-action.model';

@Component({
  selector: 'sii-quick-actions-panel',
  templateUrl: './quick-actions-panel.component.html',
  styleUrls: ['./quick-actions-panel.component.scss'],
  animations: [
    trigger('openClosePanel', [
      state('hide', style({ width: '0px' })),
      state('open', style({ width: '200px' })),
      transition('hide => open', [
        animate('400ms ease-out'),
        query('@*', animateChild())]),
      transition('open => hide', [
        query('@*', animateChild()),
        animate('400ms ease-out'),
      ]),
    ]),
    trigger('enterExitRight', [
      transition(':enter', [
        style({ opacity: 0 }),
        animate(
          '100ms ease-in',
          style({ opacity: 1 })
        ),
      ]),
      transition(':leave', [
        animate(
          '100ms ease-in',
          style({ opacity: 0, })
        ),
      ]),
    ]),
  ]
})
export class QuickActionsPanelComponent {

  @HostBinding('@openClosePanel') get getOpenClosePanel() {
    return this.hidden ? 'hide' : 'open';
  }

  @HostListener('@openClosePanel.start', ['$event']) startDrawerHandler(event: any): void {
    this.animationOpenDone.next(true);
  }

  @HostListener('@openClosePanel.done', ['$event']) doneDrawerHandler(event: any): void {
    this.animationCloseDone.next(true);
  }

  panelActions: QuickActionGroup[] = [];
  hidden = true;

  private animationCloseDone = new Subject<boolean>();
  private animationOpenDone = new Subject<boolean>();

  openPanel(actions: QuickActionGroup[]) {
    if (this.hidden === false || !actions) {
      return new BehaviorSubject<boolean>(true);
    }

    this.panelActions = actions;
    this.hidden = false;
    return this.animationOpenDone;
  }

  onActionClick(item: QuickActionModel) {
    item.handler();
  }

  closePanel() {
    if (this.hidden = true) {
      return new BehaviorSubject<boolean>(true);
    }

    this.panelActions = [];
    this.hidden = true;
    return this.animationCloseDone;
  }
}
