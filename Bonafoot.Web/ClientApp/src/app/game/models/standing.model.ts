import { TeamModel } from "./team.model";

export class StandingModel {
    team: TeamModel;
    victory: number;
    draw: number;
    loss: number;
    scoresPro: number;
    scoresCon: number;
}