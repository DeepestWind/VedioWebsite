import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//添加模板内组件
import { LogoComponent } from './logo/logo.component';
import { SearchComponent } from './search/search.component';
import { ThemeSwitcherComponent } from './theme-switcher/theme-switcher.component';


@NgModule({
  declarations: [
    LogoComponent,SearchComponent,ThemeSwitcherComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LogoComponent,SearchComponent,ThemeSwitcherComponent
  ]
})
export class HeaderModule { }
