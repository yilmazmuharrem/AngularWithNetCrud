import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import {FormsModule} from '@angular/forms'
import { AddCategoryComponent } from './components/category/add-category/add-category.component';
import {HttpClientModule} from '@angular/common/http';
import { EditCategoryComponent } from './components/category/edit-category/edit-category.component';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CategoryListComponent,
    AddCategoryComponent,
    EditCategoryComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
