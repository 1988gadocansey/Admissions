import { Router } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile-menu',
  templateUrl: './profile-menu.component.html',
  styleUrls: ['./profile-menu.component.scss'],
})
export class ProfileMenuComponent implements OnInit {
  public isMenuOpen = false;
  @Input() userName: string | any
  @Input() isUserAuthenticated: boolean | any = false;
  /*  constructor(private authService: AuthenticationService, private router: Router) {
     this.authService.authChanged
       .subscribe(res => {
         this.isUserAuthenticated = res;
       })
   } */
  constructor(private router: Router) {


  }

  ngOnInit(): void {

  }



  public toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }
  public logout = () => {


    this.router.navigate(["/authentication/logout"]);
  }
}
