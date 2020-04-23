import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { StandingModel } from 'src/app/game/models/standing.model';

@Component({
    selector: 'app-division-standing',
    templateUrl: './division-standing.component.html'
})
export class DivisionStandingComponent implements OnInit {
    round: number;

    @Input()
    standing: StandingModel[];

    @Input()
    title: string;

    constructor(private route: Router) {

    }

    ngOnInit(): void {
        const game = JSON.parse(localStorage.getItem('game'));
        this.round = game.championship.actualRound - 1;
    }
}