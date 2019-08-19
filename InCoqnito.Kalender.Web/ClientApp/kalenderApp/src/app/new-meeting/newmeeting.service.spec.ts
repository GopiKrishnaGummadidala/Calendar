import { TestBed } from '@angular/core/testing';

import { NewmeetingService } from './newmeeting.service';

describe('NewmeetingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NewmeetingService = TestBed.get(NewmeetingService);
    expect(service).toBeTruthy();
  });
});
