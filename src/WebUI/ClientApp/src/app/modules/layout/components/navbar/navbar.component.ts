import { Component, Input, OnInit } from '@angular/core';
import { MenuService } from '../../services/menu.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  @Input() userName: any;
  @Input() authenticated: any;
  constructor(private menuService: MenuService) { }

  ngOnInit(): void { }

  public toggleMobileMenu(): void {
    this.menuService.showMobileMenu = true;
  }
}
