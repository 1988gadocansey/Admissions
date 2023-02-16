import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  isExpanded = false;
  sidebarOpen = false;
  copyrightDate: any = Date()
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
    this.sidebarOpen=!this.sidebarOpen;
  }
  constructor() { }

  ngOnInit(): void {
  }

}
