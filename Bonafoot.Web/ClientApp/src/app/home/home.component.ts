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
    document.querySelectorAll("body").forEach(x => x.style.backgroundColor = '#2FAA61')
    this.loadGames();
  }

  loadGames(): void {
    this.gameService.GetAll().subscribe(x => this.games = x, e => alert(e));
  }

  newGame(): void {
    const command = new NewGameCommand(this.newGameName);
    this.gameService.New(command).subscribe(x => {
      localStorage.setItem('game', JSON.stringify(x));
      this.route.navigate(['squad']);
    }, e => alert(e));
  }

  loadGame(name: string): void {
    this.gameService.Load(name).subscribe(x => {
      localStorage.setItem('game', JSON.stringify(x));
      this.route.navigate(['squad']);
    }, e => alert(e));
  }

  deleteGame(name: string): void {
    this.gameService.Delete(name).subscribe(x => {
      localStorage.clear();
      this.loadGames();
    }, e => alert(e));
  }
}
