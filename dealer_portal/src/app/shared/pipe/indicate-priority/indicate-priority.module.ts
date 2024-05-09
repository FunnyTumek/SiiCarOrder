import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndicatePriorityPipe } from './indicate-priority.pipe';



@NgModule({
  declarations: [
    IndicatePriorityPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [IndicatePriorityPipe]
})
export class IndicatePriorityModule { }
