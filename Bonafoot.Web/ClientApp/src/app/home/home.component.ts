import { Component, OnInit } from '@angular/core';
import { GameModel } from '../game/models/game.model';
import { GameService } from '../game/services/game.service';
import { NewGameCommand } from '../game/commands/new-game-command.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  newGameName: string;
  loadGameName: string;

  games: GameModel[];

  constructor(private gameService: GameService, private route: Router) {
    
  }

  ngOnInit(): void {
    this.gameService.GetAll().subscribe(x => this.games = x, e => alert(e));
  }

  newGame(): void {
    const command = new NewGameCommand(this.newGameName);
    this.gameService.New(command).subscribe(x => {
      localStorage.setItem('game', JSON.stringify(x));
      this.route.navigate(['squad']);
    }, e => alert(e));
  }

  loadGame(id): void {
    this.gameService.Load(id).subscribe(x => {
      localStorage.setItem('game', JSON.stringify(x));
      this.route.navigate(['squad']);
    }, e => alert(e));
  }
}
