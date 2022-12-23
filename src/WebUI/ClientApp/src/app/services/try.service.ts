import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from '@angular/router';
import {Observable} from "rxjs";

/* An interface that represents your data model */
export interface Crisis {
  id: number;
  name: string;
}

export class TryService implements Resolve<Crisis> {
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Crisis> {
    // your logic goes here
    return null
  }
}
