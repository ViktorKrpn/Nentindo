import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactCreateCsvFileComponent } from './contact-create-csv-file.component';

describe('ContactCreateCsvFileComponent', () => {
  let component: ContactCreateCsvFileComponent;
  let fixture: ComponentFixture<ContactCreateCsvFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ContactCreateCsvFileComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContactCreateCsvFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
