import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';

import { ConfirmOrderDialogComponent } from './confirm-order-dialog.component';

describe('ConfirmOrderDialogComponent', () => {
  let component: ConfirmOrderDialogComponent;
  let fixture: ComponentFixture<ConfirmOrderDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ConfirmOrderDialogComponent],
      providers: [

        {
          provide: MAT_DIALOG_DATA, useValue: {
            order: {
              price: 0
            }
          }
        },
        { provide: MatDialogRef, useValue: {} }
      ],
      imports: [

        MatDialogModule,
        HttpClientTestingModule
      ],
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmOrderDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
