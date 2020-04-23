import { Component, Input, SimpleChanges } from '@angular/core';
import { PlayingMatchModel } from '../model/playing-match.model';

@Component({
    selector: 'app-division-match',
    templateUrl: './division-match.component.html'
})
export class DivisionMatchComponent {
    @Input()
    title: string;
    
    @Input()
    playingMatch: PlayingMatchModel[];
    
    @Input()
    minute = 0;

    ngOnChanges(changes: SimpleChanges) {
        this.gameChange(changes.minute.currentValue);
    }

    gameChange(minute: number) {
        this.playingMatch.forEach(x => {
            const score = x.scores.find(x => x.minute == minute);
            if (score) {
                score.home ? x.homeTeamScore++ : x.guestTeamScore++;
                x.playerScored = minute + '" ' + score.name;
            }
        });
    }
}