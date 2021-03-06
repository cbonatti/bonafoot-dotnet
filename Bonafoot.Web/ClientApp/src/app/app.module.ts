import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GameService } from './game/services/game.service';
import { SquadComponent } from './squad/squad.component';
import { MatchService } from './match/services/match.service';
import { MatchComponent } from './match/match.component';
import { UtilService } from './game/services/util.service';
import { DivisionMatchComponent } from './match/division-match/division-match.component';
import { StandingComponent } from './standing/standing.component';
import { DivisionStandingComponent } from './standing/division-standing/division-standing.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SquadComponent,
    MatchComponent,
    DivisionMatchComponent,
    StandingComponent,
    DivisionStandingComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'bonafoot' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'squad', component: SquadComponent },
      { path: 'match', component: MatchComponent },
      { path: 'standing', component: StandingComponent },
    ])
  ],
  providers: [GameService, MatchService, UtilService],
  bootstrap: [AppComponent]
})
export class AppModule { }
