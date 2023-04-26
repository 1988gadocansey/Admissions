import { ChangeDetectorRef, Pipe, PipeTransform } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import { PreviewClient, ProgrammeDto } from 'src/app/web-api-client';
import { AsyncPipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';

@Pipe({
  name: 'programmePipe',

})
export class ProgrammePipePipe implements PipeTransform {
  public data: any

  private valueSubject = new Subject();
  // private value$ = this.valueSubject.asObservable().distinctUntilChanged()
  constructor(cdRef: ChangeDetectorRef, private previewClient: PreviewClient) {

  }

  transform(id: number): Promise<any> {

    return new Promise((resolve, reject) => {
      this.previewClient.getProgrammeById(id).subscribe(d => {

        resolve(d.name)
      },
        (err: HttpErrorResponse) => {

          reject(err.error);

        });
    });

  }



}



