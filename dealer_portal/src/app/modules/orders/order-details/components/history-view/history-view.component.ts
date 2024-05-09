import { Component, Input } from '@angular/core';
import { HistoryData } from 'src/app/shared/services/fetch/history.service';

@Component({
  selector: 'sii-history-view',
  templateUrl: './history-view.component.html',
  styleUrls: ['./history-view.component.scss']
})
export class HistoryViewComponent {

  @Input()
  dataSource: HistoryData[] = [];
  panelOpenState = false;

}
