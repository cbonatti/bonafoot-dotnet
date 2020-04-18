import { TeamModel } from "./team.model";
import { ScoreModel } from "./score.model";

export class MatchModel {
    round: number;
    home: TeamModel;
    guest: TeamModel;
    scores: ScoreModel[];
}