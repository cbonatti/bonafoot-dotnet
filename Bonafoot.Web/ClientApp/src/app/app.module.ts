import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GameService } from './game/services/game.service';
import { SquadComponent } from './squad/squad.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SquadComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'bonafoot' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'squad', component: SquadComponent },
    ])
  ],
  providers: [GameService],
  bootstrap: [AppComponent]
})
export class AppModule { }
