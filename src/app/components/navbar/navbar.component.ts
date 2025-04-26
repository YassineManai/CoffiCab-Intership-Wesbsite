import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  standalone: true,
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  constructor() { }
  

  ngOnInit(): void {
    const menuBar = document.querySelector('#content nav .bx.bx-menu');
    const sidebar = document.getElementById('sidebar');
    
    if (menuBar && sidebar) {
      menuBar.addEventListener('click', function () {
        sidebar.classList.toggle('hide');
      });
    }

    const searchButton = document.querySelector('#content nav form .form-input button');
    const searchButtonIcon = document.querySelector('#content nav form .form-input button .bx');
    const searchForm = document.querySelector('#content nav form');

    if (searchButton && searchButtonIcon && searchForm) {
      searchButton.addEventListener('click', function (e) {
        if (window.innerWidth < 576) {
          e.preventDefault();
          searchForm.classList.toggle('show');
          if (searchForm.classList.contains('show')) {
            searchButtonIcon.classList.replace('bx-search', 'bx-x');
          } else {
            searchButtonIcon.classList.replace('bx-x', 'bx-search');
          }
        }
      });
    }

    if (sidebar && searchButtonIcon && searchForm) {
      if (window.innerWidth < 768) {
        sidebar.classList.add('hide');
      } else if (window.innerWidth > 576) {
        searchButtonIcon.classList.replace('bx-x', 'bx-search');
        searchForm.classList.remove('show');
      }
    }

    window.addEventListener('resize', function () {
      if (searchButtonIcon && searchForm) {
        if (this.innerWidth > 576) {
          searchButtonIcon.classList.replace('bx-x', 'bx-search');
          searchForm.classList.remove('show');
        }
      }
    });

    const switchMode = document.getElementById('switch-mode');

    if (switchMode) {
      switchMode.addEventListener('change', function () {
        if ((this as HTMLInputElement).checked) {
          document.body.classList.add('dark');
        } else {
          document.body.classList.remove('dark');
        }
      });
    }


    
  }
}
