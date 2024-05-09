import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
@Component({
  selector: 'sii-modules-navigation',
  templateUrl: './modules-navigation.component.html',
  styleUrls: ['./modules-navigation.component.scss']
})
export class ModulesNavigationComponent implements OnInit {
  @Output() navigate = new EventEmitter<string>();

  selectedIndex = 0;

  private readonly modulesTabIndex = {
    'orders': 0,
    'clients': 1,
    'payments': 2,
    'production': 3,
    'dictionaries': 4
  }

  constructor(private router: Router, private activeRoot: ActivatedRoute) { }

  ngOnInit() {
    this.router.events.pipe(filter((e): e is NavigationEnd => e instanceof NavigationEnd))
      .subscribe(_ => this.updateActiveTab(this.router.url.toString()));
  }

  onNavigationClick(direction: string) {
    this.navigate.emit(direction);
  }

  onOrderClick(e: MouseEvent, node: string) {
    this.onNavigationClick(node)
  }

  onMatTabChange($event: MatTabChangeEvent) {

    switch ($event.index) {
      case 0: {
        this.onNavigationClick('orders');
        break;
      }
      case 1: {
        this.onNavigationClick('clients');
        break;
      }
      case 2: {
        this.onNavigationClick('payments');
        break;
      }
      case 3: {
        this.onNavigationClick('production');
        break;
      }
      case 4: {
        this.onNavigationClick('dictionaries');
        break;
      }
    }
  }

  private updateActiveTab(url: string): void {
    if (url.indexOf('orders') > -1) { this.selectedIndex = this.modulesTabIndex['orders']; }
    if (url.indexOf('clients') > -1) { this.selectedIndex = this.modulesTabIndex['clients']; }
    if (url.indexOf('payments') > -1) { this.selectedIndex = this.modulesTabIndex['payments']; }
    if (url.indexOf('production') > -1) { this.selectedIndex = this.modulesTabIndex['production']; }
    if (url.indexOf('dictionaries') > -1) { this.selectedIndex = this.modulesTabIndex['dictionaries']; }
  }
}
