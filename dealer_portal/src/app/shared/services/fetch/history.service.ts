import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  constructor() { }

  getHistory(orderId: number) {
    return of(HISTORY_DATA)
  }

}

interface DealerWorker {
  id: number,
  firstName: string,
  lastName: string,
}

export interface HistoryData {
  title: string,
  date: Date,
  responsibleWorker: DealerWorker,
  message: string
}
const HISTORY_DATA: HistoryData[] =
  [
    {
      title: 'Configuration created (Mocked)',
      date: new Date(2019, 1, 16),
      responsibleWorker: {
        id: 1,
        firstName: 'John',
        lastName: 'Doe',
      },
      message: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Molestias aut, repellat ipsum facere voluptate dicta obcaecati deserunt nobis suscipit eaque',
    },
    {
      title: 'Configuration confirmed (Mocked)',
      date: new Date(2019, 1, 31),
      responsibleWorker: {
        id: 2,
        firstName: 'John',
        lastName: 'Doe',
      },
      message: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Molestias aut, repellat ipsum facere voluptate dicta obcaecati deserunt nobis suscipit eaque',
    },
    {
      title: 'Advance paid (Mocked)',
      date: new Date(2019, 2, 16),
      responsibleWorker: {
        id: 3,
        firstName: 'John',
        lastName: 'Doe',
      },
      message: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Molestias aut, repellat ipsum facere voluptate dicta obcaecati deserunt nobis suscipit eaque',
    },
    {
      title: 'Ordered in fabric (Mocked)',
      responsibleWorker: {
        id: 4,
        firstName: 'John',
        lastName: 'Doe',
      },
      date: new Date(2019, 2, 31),
      message: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Molestias aut, repellat ipsum facere voluptate dicta obcaecati deserunt nobis suscipit eaque',

    },

  ]


