import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatAutocompleteModule, MatButtonModule, MatButtonToggleModule, MatCardModule, MatDatepickerModule, MatDialogModule, MatExpansionModule, MatFormFieldModule, MatIconModule, MatInputModule, MatNativeDateModule, MatPaginatorModule, MatProgressBarModule, MatProgressSpinnerModule, MatSelectModule, MatSlideToggleModule, MatTableModule, MatTooltipModule } from '@angular/material';
import { ModalAdicionarComponent } from './home/modal-adicionar/modal-adicionar.component';
import { ModalAtualizarComponent } from './home/modal-atualizar/modal-atualizar.component';
import { EscolaridadeComponent } from './Components/escolaridade/escolaridade.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ModalAdicionarComponent,
    ModalAtualizarComponent,
    EscolaridadeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
   
    // Material
    MatCardModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatAutocompleteModule,
    MatExpansionModule,
    MatDatepickerModule,
    MatPaginatorModule,
    MatButtonToggleModule,
    MatTooltipModule,
    MatSlideToggleModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ]),
    BrowserAnimationsModule
  ],
  // exports:[Usuario],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents:[ModalAdicionarComponent, ModalAtualizarComponent]
})
export class AppModule { }
