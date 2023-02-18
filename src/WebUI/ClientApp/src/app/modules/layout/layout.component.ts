import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
})
export class LayoutComponent implements OnInit {
  public isAuthenticated?: Observable<boolean>;
  public userName?: Observable<string | null | undefined>;


  constructor(private authorizeService: AuthorizeService) { }

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }
}
