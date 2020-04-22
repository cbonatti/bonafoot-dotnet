import { TeamModel } from "./team.model";
import { StandingModel } from "./standing.model";
import { ChampionshipRoundModel } from "./championship-round.model";

export enum DivisionIndex {
    First,
    Second,
    Third,
    Fourth
}

export class DivisionModel {
    standing: StandingModel[];
    teams: TeamModel[];
    rounds: ChampionshipRoundModel[];

    getNextRound(teamId: string, round: number): StandingModel[] {
        const nextRound = this.rounds.find(x => (x.homeTeam.id == teamId || x.guestTeam.id == teamId) && x.round == round);
        return this.standing.filter(x => x.team.id == nextRound.homeTeam.id || x.team.id == nextRound.guestTeam.id).sort(x => x.points);
    }
}