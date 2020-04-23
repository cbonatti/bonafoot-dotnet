import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GameModel } from '../game/models/game.model';
import { ChampionshipModel } from '../game/models/championship.model';
import { PlayingMatchModel } from './model/playing-match.model';
import { MatchModel } from '../game/models/match.model';
import { ChampionshipRoundModel } from '../game/models/championship-round.model';
import { ScoreModel } from '../game/models/score.model';

@Component({
    selector: 'app-match',
    templateUrl: './match.component.html'
})
export class MatchComponent implements OnInit {
    game: GameModel;
    championship: ChampionshipModel;
    first: PlayingMatchModel[];
    second: PlayingMatchModel[];
    third: PlayingMatchModel[];
    fourth: PlayingMatchModel[];
    matches: MatchModel[];
    minute = 0;
    round: number;

    constructor(private route: Router) {

    }

    ngOnInit(): void {
        document.querySelectorAll("body").forEach(x => x.style.backgroundColor = '#2FAA61')
        this.game = JSON.parse(localStorage.getItem('game'));
        this.championship = this.game.championship;
        this.round = this.championship.actualRound - 1; // -1 because when play the first round, the actual round is 2
        this.matches = this.championship.matches.filter(x => x.round === this.round);

        this.first = this.championship.first.rounds.filter(x => x.round === this.round).map(x => new PlayingMatchModel(x, this.getScores(x)));
        this.second = this.championship.second.rounds.filter(x => x.round === this.round).map(x => new PlayingMatchModel(x, this.getScores(x)));
        this.third = this.championship.third.rounds.filter(x => x.round === this.round).map(x => new PlayingMatchModel(x, this.getScores(x)));
        this.fourth = this.championship.fourth.rounds.filter(x => x.round === this.round).map(x => new PlayingMatchModel(x, this.getScores(x)));

        this.gameFlowControl();
    }

    getScores(championshipRound: ChampionshipRoundModel): ScoreModel[] {
        let scores = new Array<ScoreModel>();
        this.matches.filter(x => x.home.id == championshipRound.homeTeam.id && x.guest.id == championshipRound.guestTeam.id).map(x => {
            x.scores.map(y => {
                scores.push(new ScoreModel(y.name, y.minute, y.home));
            })
        });
        return scores;
    }

    gameFlowControl() {
        this.minuteChange();

        if (this.minute === 90)
            return;
            
        setTimeout(() => {
            this.gameFlowControl();
        }, 250);
    }

    minuteChange() {
        this.minute++;

        this.gameChange(this.first);
        this.gameChange(this.second);
        this.gameChange(this.third);
        this.gameChange(this.fourth);
    }

    gameChange(matches: PlayingMatchModel[]) {
        matches.forEach(x => {
            const minute = x.scores.find(x => x.minute == this.minute);
            if (minute) {
                minute.home ? x.homeTeamScore++ : x.guestTeamScore++;
                x.playerScored = this.minute + '" ' + minute.name;
            }
        });
    }
}