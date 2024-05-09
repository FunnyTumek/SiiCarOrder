import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DictionaryItemType } from '../../enums/dictionary-item-type';
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

@Injectable({
  providedIn: 'root'
})
export class DictionariesService {
  url = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getOptionsForType(type: DictionaryItemType, onlyActive: boolean = true): Observable<DictionaryItem[]> {
    switch (type) {
      case DictionaryItemType.Brand:
        return this.getBrands(onlyActive);
      case DictionaryItemType.Model:
        return this.getModels(onlyActive);
      case DictionaryItemType.EquipmentVersion:
        return this.getEquipmentVersions(onlyActive);
      case DictionaryItemType.Class:
        return this.getClasses(onlyActive);
      case DictionaryItemType.Engine:
        return this.getEngines(onlyActive);
      case DictionaryItemType.Gearbox:
        return this.getGearboxes(onlyActive);
      case DictionaryItemType.Color:
        return this.getColors(onlyActive);
      case DictionaryItemType.Interior:
        return this.getInteriors(onlyActive);
      case DictionaryItemType.AdditionalEquipment:
        return this.getAdditionalEquipments(onlyActive);
      default:
        throw new Error(`Unknown dictionary item type: "${type}".`);
    }
  }

  getBrands(onlyActive: boolean = true): Observable<Brand[]> {
    return this.http.get<Brand[]>(`${this.url}/api/configuration/brand`, { params: { onlyActive: onlyActive } });
  }

  getModels(onlyActive: boolean = true): Observable<Model[]> {
    return this.http.get<Model[]>(`${this.url}/api/configuration/model`, { params: { onlyActive: onlyActive } });
  }

  getEquipmentVersions(onlyActive: boolean = true): Observable<EquipmentVersion[]> {
    return this.http.get<EquipmentVersion[]>(`${this.url}/api/configuration/equipmentversion`, { params: { onlyActive: onlyActive } });
  }

  getClasses(onlyActive: boolean = true): Observable<Class[]> {
    return this.http.get<Class[]>(`${this.url}/api/configuration/class`, { params: { onlyActive: onlyActive } });
  }

  getEngines(onlyActive: boolean = true): Observable<Engine[]> {
    return this.http.get<Engine[]>(`${this.url}/api/configuration/engine`, { params: { onlyActive: onlyActive } });
  }

  getGearboxes(onlyActive: boolean = true): Observable<Gearbox[]> {
    return this.http.get<Gearbox[]>(`${this.url}/api/configuration/gearbox`, { params: { onlyActive: onlyActive } });
  }

  getColors(onlyActive: boolean = true): Observable<Color[]> {
    return this.http.get<Color[]>(`${this.url}/api/configuration/color`, { params: { onlyActive: onlyActive } });
  }

  getInteriors(onlyActive: boolean = true): Observable<Interior[]> {
    return this.http.get<Interior[]>(`${this.url}/api/configuration/interior`, { params: { onlyActive: onlyActive } });
  }

  getAdditionalEquipments(onlyActive: boolean = true): Observable<AdditionalEquipment[]> {
    return this.http.get<AdditionalEquipment[]>(`${this.url}/api/configuration/additionalequipment`, { params: { onlyActive: onlyActive } });
  }

  updateOptionForType(type: DictionaryItemType, option: DictionaryItem): Observable<void> {
    switch (type) {
      case DictionaryItemType.Brand:
        return this.updateBrand(option as Brand);
      case DictionaryItemType.Model:
        return this.updateModel(option as Model);
      case DictionaryItemType.EquipmentVersion:
        return this.updateEquipmentVersion(option as EquipmentVersion);
      case DictionaryItemType.Class:
        return this.updateClass(option as Class);
      case DictionaryItemType.Engine:
        return this.updateEngine(option as Engine);
      case DictionaryItemType.Gearbox:
        return this.updateGearbox(option as Gearbox);
      case DictionaryItemType.Color:
        return this.updateColor(option as Color);
      case DictionaryItemType.Interior:
        return this.updateInterior(option as Interior);
      case DictionaryItemType.AdditionalEquipment:
        return this.updateAdditionalEquipment(option as AdditionalEquipment);
      default:
        throw new Error(`Unknown dictionary item type: "${type}".`);
    }
  }

  updateBrand(brand: Brand): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/brand`, brand);
  }

  updateModel(model: Model): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/model`, model);
  }

  updateEquipmentVersion(equipmentVersion: EquipmentVersion): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/equipmentversion`, equipmentVersion);
  }

  updateClass(carClass: Class): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/class`, carClass);
  }

  updateEngine(engine: Engine): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/engine`, engine);
  }

  updateGearbox(gearbox: Gearbox): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/gearbox`, gearbox);
  }

  updateColor(color: Color): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/color`, color);
  }

  updateInterior(interior: Interior): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/interior`, interior);
  }

  updateAdditionalEquipment(additionalEquipment: AdditionalEquipment): Observable<void> {
    return this.http.put<void>(`${this.url}/api/configuration/additionalequipment`, additionalEquipment);
  }
}
