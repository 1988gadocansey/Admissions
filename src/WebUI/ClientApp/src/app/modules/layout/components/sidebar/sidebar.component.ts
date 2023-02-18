import { Component, Input, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { MenuItem } from 'src/app/core/models/menu.model';
import { ThemeService } from 'src/app/core/services/theme.service';
//import packageJson from '.';
import { MenuService } from '../../services/menu.service';
import { AuthorizeService } from '../../../../../api-authorization/authorize.service';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
  public showSideBar$: Observable<boolean> = new Observable<boolean>();
  public pagesMenu$: Observable<MenuItem[]> = new Observable<MenuItem[]>();
  @Input() userName: any;
  @Input() authenticated: any;
  //public appJson: any = packageJson;

  constructor(public themeService: ThemeService, private menuService: MenuService) {
    this.showSideBar$ = this.menuService.showSideBar$;
    this.pagesMenu$ = this.menuService.pagesMenu$;
  }

  ngOnInit(): void {

  }

  public toggleSidebar() {
    this.menuService.toggleSidebar();
  }

  toggleTheme() {
    this.themeService.theme = !this.themeService.isDark ? 'dark' : 'light';
  }
}
