import { TestBed } from '@angular/core/testing';

import { PrizesService } from './prizes.service';

describe('PrizesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PrizesService = TestBed.get(PrizesService);
    expect(service).toBeTruthy();
  });
});
