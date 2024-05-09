import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DictionaryItemType } from '../../enums/dictionary-item-type';
import { EngineType } from '../../enums/engine-type';
import { AdditionalEquipment } from '../../models/additional-equipment';
import { Brand } from '../../models/brand';
import { Class } from '../../models/class';
import { Color } from '../../models/color';
import { DictionaryItem } from '../../models/dictionary-item';
import { Engine } from '../../models/engine';
import { EquipmentVersion } from '../../models/equipment-version';
import { Gearbox } from '../../models/gearbox';
import { Interior } from '../../models/interior';
import { Model } from '../../models/model';

export interface DialogData {
  type: DictionaryItemType;
  option: DictionaryItem;
}

@Component({
  selector: 'sii-edit-option-dialog',
  templateUrl: './edit-option-dialog.component.html',
  styleUrls: ['./edit-option-dialog.component.scss']
})
export class EditOptionDialogComponent {
  types = DictionaryItemType;
  engineTypes = Object.keys(EngineType);

  brand?: Brand;
  model?: Model;
  equipmentVersion?: EquipmentVersion;
  class?: Class;
  engine?: Engine;
  gearbox?: Gearbox;
  color?: Color;
  interior?: Interior;
  additionalEquipment?: AdditionalEquipment;

  type: DictionaryItemType;
  option: DictionaryItem;

  constructor(
    public dialogRef: MatDialogRef<EditOptionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
  ) {
    this.type = data.type;
    this.option = { ...data.option };
    switch (this.type) {
      case DictionaryItemType.Brand:
        this.brand = this.option as Brand;
        break;
      case DictionaryItemType.Model:
        this.model = this.option as Model;
        break;
      case DictionaryItemType.EquipmentVersion:
        this.equipmentVersion = this.option as EquipmentVersion;
        break;
      case DictionaryItemType.Class:
        this.class = this.option as Class;
        break;
      case DictionaryItemType.Engine:
        this.engine = this.option as Engine;
        break;
      case DictionaryItemType.Gearbox:
        this.gearbox = this.option as Gearbox;
        break;
      case DictionaryItemType.Color:
        this.color = this.option as Color;
        break;
      case DictionaryItemType.Interior:
        this.interior = this.option as Interior;
        break;
      case DictionaryItemType.AdditionalEquipment:
        this.additionalEquipment = this.option as AdditionalEquipment;
        break;
    }
  }

  onDiscardClick(): void {
    this.dialogRef.close();
  }

  onClose(): void {
    this.dialogRef.close(this.option);
  }

}
