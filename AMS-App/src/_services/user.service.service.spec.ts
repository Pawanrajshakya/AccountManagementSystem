/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { User.serviceService } from './user.service.service';

describe('Service: User.service', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [User.serviceService]
    });
  });

  it('should ...', inject([User.serviceService], (service: User.serviceService) => {
    expect(service).toBeTruthy();
  }));
});
