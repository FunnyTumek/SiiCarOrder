import { Component, Input } from '@angular/core';
import { ConfigurationItem } from 'src/app/shared/models/configuration-item';

@Component({
  selector: 'sii-car-configuration-view',
  templateUrl: './car-configuration-view.component.html',
  styleUrls: ['./car-configuration-view.component.scss']
})
export class CarConfigurationViewComponent {

  @Input() configuration: ConfigurationItem[] | undefined = [];

}
