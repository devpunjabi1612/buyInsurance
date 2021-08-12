import { TestBed } from '@angular/core/testing';

import { VechicleRegistrationService } from './vechicle-registration.service';

describe('VechicleRegistrationService', () => {
  let service: VechicleRegistrationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VechicleRegistrationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
