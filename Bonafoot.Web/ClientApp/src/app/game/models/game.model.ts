import { TeamModel } from "./team.model";
import { ChampionshipModel } from "./championship.model";

export class GameModel {
    name: string;
    team: TeamModel;
    championship: ChampionshipModel;
}