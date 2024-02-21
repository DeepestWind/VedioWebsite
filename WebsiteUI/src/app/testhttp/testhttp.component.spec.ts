import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TesthttpComponent } from './testhttp.component';

describe('TesthttpComponent', () => {
  let component: TesthttpComponent;
  let fixture: ComponentFixture<TesthttpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TesthttpComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TesthttpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
