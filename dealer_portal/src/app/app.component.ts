import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { QuickActionsService } from './shared/services/global-gui/quick-actions.service';
import { QuickActionsPanelComponent } from './shell/quick-actions-panel/quick-actions-panel.component';
import { SignalrService } from './shared/signalr/notification/notification.service';


@Component({
  selector: 'sii-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {

  activeModule = '';


  ngOnInit() {
    this.signalRService.startConnection();
      this.signalRService.addNotificationDataListener();   
  }

  @ViewChild(QuickActionsPanelComponent)
  set quickActionsPanelComponent(v: QuickActionsPanelComponent) {
    this.quickActions.boundPanel(v);
  }
  constructor(
    public signalRService: SignalrService,
    private router: Router,
    private quickActions: QuickActionsService,
  ) { }

  onNavigate(dir: string) {
    this.quickActions.closePanel().pipe(take(1)).subscribe(() =>
      this.router.navigate([dir], { queryParamsHandling: 'merge' }));
  }
}
