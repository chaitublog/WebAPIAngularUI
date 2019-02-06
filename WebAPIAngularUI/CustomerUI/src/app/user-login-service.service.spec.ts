import { TestBed, inject } from '@angular/core/testing';

import { UserLoginServiceService } from './user-login-service.service';

describe('UserLoginServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserLoginServiceService]
    });
  });

  it('should be created', inject([UserLoginServiceService], (service: UserLoginServiceService) => {
    expect(service).toBeTruthy();
  }));
});
