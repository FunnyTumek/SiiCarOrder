import { Component } from '@angular/core';
import { QuickActionsService } from 'src/app/shared/services/global-gui/quick-actions.service';

@Component({
  selector: 'sii-clients-container',
  templateUrl: './clients-container.component.html',
  styleUrls: ['./clients-container.component.scss']
})
export class ClientsContainerComponent {

  constructor(private quickActions: QuickActionsService,) { }

}
