/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { Alert.service.tsService } from './alert.service';

describe('Service: Alert.service.ts', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Alert.service.tsService]
    });
  });

  it('should ...', inject([Alert.service.tsService], (service: Alert.service.tsService) => {
    expect(service).toBeTruthy();
  }));
});
