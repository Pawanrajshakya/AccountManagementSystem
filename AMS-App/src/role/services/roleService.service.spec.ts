/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RoleServiceService } from './roleService.service';

describe('Service: RoleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RoleServiceService]
    });
  });

  it('should ...', inject([RoleServiceService], (service: RoleServiceService) => {
    expect(service).toBeTruthy();
  }));
});
