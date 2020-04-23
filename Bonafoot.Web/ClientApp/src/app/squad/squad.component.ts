import { Component, OnInit } from '@angular/core';
import { GameService } from '../game/services/game.service';
import { Router } from '@angular/router';
import { GameModel } from '../game/models/game.model';
import { PlayerPosition, PlayerModel } from '../game/models/player.model';
import { DivisionIndex, DivisionModel } from '../game/models/division.model';
import { TeamModel } from '../game/models/team.model';
import { ChampionshipModel } from '../game/models/championship.model';
import { NextRoundModel } from './models/next-round.model';
import { MatchService } from '../match/services/match.service';
import { PlayMatchCommand } from '../match/commands/play-match-command.model';
import { UtilService } from '../game/services/util.service';

@Component({
    selector: 'app-squad',
    templateUrl: './squad.component.html',
})
export class SquadComponent implements OnInit {
    game: GameModel;
    nextRound: NextRoundModel[];
    team: TeamModel;
    championship: ChampionshipModel;
    division: DivisionModel;

    constructor(private gameService: GameService, private matchService: MatchService, private util: UtilService, private route: Router) {

    }

    ngOnInit(): void {
        this.game = JSON.parse(localStorage.getItem('game'));
        this.team = this.game.team;
        document.querySelectorAll("body").forEach(x => x.style.backgroundColor = this.team.primaryColor)
        this.championship = this.game.championship;
        this.division = this.getDivision(this.game.team.division);
        this.nextRound = this.getNextRound(this.game.team.id, this.championship.actualRound);
        this.clearTeamSelect();
    }

    clearTeamSelect() {
        this.team.squad.map(x => x.select = false);
    }

    formation(positions: number[]): void {
        this.team.squad.forEach(x => x.select = false);

        const gks = this.util.sortOrder(this.team.squad.filter(x => x.position === PlayerPosition.Goalkeeper), 'strength').reverse();
        gks[0].select = true;

        const dfs = this.util.sortOrder(this.team.squad.filter(x => x.position === PlayerPosition.Defender), 'strength').reverse();
        for (let i = 0; i < positions[0]; i++) {
            dfs[i].select = true;
        }

        const mfs = this.util.sortOrder(this.team.squad.filter(x => x.position === PlayerPosition.Midfielder), 'strength').reverse();
        for (let i = 0; i < positions[1]; i++) {
            mfs[i].select = true;
        }

        const sts = this.util.sortOrder(this.team.squad.filter(x => x.position === PlayerPosition.Striker), 'strength').reverse();
        for (let i = 0; i < positions[2]; i++) {
            sts[i].select = true;
        }
    }

    selectPlayer(player: PlayerModel): void {
        const p = this.team.squad.find(x => x.id === player.id);
        p.select = !p.select;
    }

    canPlay(): boolean {
        if (this.team.squad.filter(x => x.position === PlayerPosition.Goalkeeper && x.select).length !== 1)
            return false;
        return this.team.squad.filter(x => x.select).length === 11;
    }

    play() {
        const players = this.team.squad.filter(x => x.select).map(x => x.id);
        const command = new PlayMatchCommand(this.game.name, players);
        this.matchService.Play(command).subscribe(x => {
            this.game.championship = x;
            this.championship = x;
            localStorage.setItem('game', JSON.stringify(this.game));
            this.route.navigate(['match']);
        }, x => alert(x));
    }

    checkFormation(positions: number[]): boolean {
        const dfCount = this.team.squad.filter(x => x.position === PlayerPosition.Defender).length;
        const mfCount = this.team.squad.filter(x => x.position === PlayerPosition.Midfielder).length;
        const stCount = this.team.squad.filter(x => x.position === PlayerPosition.Striker).length;
        return dfCount >= positions[0] && mfCount >= positions[1] && stCount >= positions[2];
    }

    getDivision(division: DivisionIndex): DivisionModel {
        switch (division) {
            case DivisionIndex.First:
                return this.game.championship.first;
            case DivisionIndex.Second:
                return this.game.championship.second;
            case DivisionIndex.Third:
                return this.game.championship.third;
            case DivisionIndex.Fourth:
                return this.game.championship.fourth;
            default:
                break;
        }
    }

    getNextRound(teamId: string, round: number): NextRoundModel[] {
        const sortedStanding = this.util.sortOrder(this.division.standing, 'points').reverse();
        const nextRound = this.division.rounds.find(x => (x.homeTeam.id == teamId || x.guestTeam.id == teamId) && x.round == round);
        const teamAgainstId = nextRound.homeTeam.id === teamId ? nextRound.guestTeam.id : nextRound.homeTeam.id;

        let playerTeamStanding = sortedStanding.find(x => x.team.id == teamId);
        let teamAgainstStanding = sortedStanding.find(x => x.team.id == teamAgainstId);

        const playerTeamNextRound = new NextRoundModel(playerTeamStanding.team.name, sortedStanding.findIndex(x => x.team.id == teamId) + 1, playerTeamStanding.points);
        const teamAgainstNextRound = new NextRoundModel(teamAgainstStanding.team.name, sortedStanding.findIndex(x => x.team.id == teamAgainstId) + 1, teamAgainstStanding.points);

        return this.util.sortOrder(new Array<NextRoundModel>(playerTeamNextRound, teamAgainstNextRound), 'position');
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

    toStandig() {
        this.route.navigate(['standing']);
    }
}
