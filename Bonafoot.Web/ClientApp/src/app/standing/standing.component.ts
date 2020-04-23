import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GameModel } from '../game/models/game.model';
import { ChampionshipModel } from '../game/models/championship.model';
import { UtilService } from '../game/services/util.service';
import { StandingModel } from '../game/models/standing.model';

@Component({
    selector: 'app-standing',
    templateUrl: './standing.component.html'
})
export class StandingComponent implements OnInit {
    game: GameModel;
    championship: ChampionshipModel;
    round: number;

    first: StandingModel[];
    second: StandingModel[];
    third: StandingModel[];
    fourth: StandingModel[];

    constructor(private route: Router, private util: UtilService) {

    }

    ngOnInit(): void {
        document.querySelectorAll("body").forEach(x => x.style.backgroundColor = '#2FAA61')
        this.game = JSON.parse(localStorage.getItem('game'));
        this.championship = this.game.championship;
        this.round = this.championship.actualRound - 1; // -1 because when play the first round, the actual round is 2

        this.first = this.util.sortOrder(this.championship.first.standing, 'points').reverse();
        this.second = this.util.sortOrder(this.championship.second.standing, 'points').reverse();
        this.third = this.util.sortOrder(this.championship.third.standing, 'points').reverse();
        this.fourth = this.util.sortOrder(this.championship.fourth.standing, 'points').reverse();
    }

    next(): void {
        this.route.navigate(['squad']);
    }
}