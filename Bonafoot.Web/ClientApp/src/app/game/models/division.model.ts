import { TeamModel } from "./team.model";
import { StandingModel } from "./standing.model";
import { ChampionshipRoundModel } from "./championship-round.model";

export class DivisionModel {
    standing: StandingModel[];
    teams: TeamModel[];
    rounds: ChampionshipRoundModel[];
}