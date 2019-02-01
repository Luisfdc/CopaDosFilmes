import { TestBed, inject } from '@angular/core/testing';

import { CopaDosFilmesService } from './copa-dos-filmes.service';

describe('CopaDosFilmesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CopaDosFilmesService]
    });
  });

  it('should be created', inject([CopaDosFilmesService], (service: CopaDosFilmesService) => {
    expect(service).toBeTruthy();
  }));
});
