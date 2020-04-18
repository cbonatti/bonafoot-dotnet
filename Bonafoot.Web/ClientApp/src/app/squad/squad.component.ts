import { Component, OnInit } from '@angular/core';
import { GameService } from '../game/services/game.service';
import { Router } from '@angular/router';
import { GameModel } from '../game/models/game.model';
import { PlayerPosition } from '../game/models/player.model';

@Component({
  selector: 'app-squad',
  templateUrl: './squad.component.html',
})
export class SquadComponent implements OnInit {
    game: GameModel;

    constructor(private gameService: GameService, private route: Router) {
        
    }

    ngOnInit(): void {
        this.game = JSON.parse(localStorage.getItem('game'));
    }

    getPosition(pos: PlayerPosition): string {
        switch (pos) {
            case PlayerPosition.Goalkeeper:
                return 'GK';
            case PlayerPosition.Defender:
                return 'DF';
            case PlayerPosition.Midfielder:
                return 'MD'
            case PlayerPosition.Striker:
                return 'ST'
            default:
                return '';
        }
    }
}
