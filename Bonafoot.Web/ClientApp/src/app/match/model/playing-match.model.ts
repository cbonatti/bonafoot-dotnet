import { TeamModel } from "src/app/game/models/team.model";
import { ChampionshipRoundModel } from "src/app/game/models/championship-round.model";
import { ScoreModel } from "src/app/game/models/score.model";

export class PlayingMatchModel {
    name: string;
    homeTeam: TeamModel;
    guestTeam: TeamModel;
    homeTeamScore = 0;
    guestTeamScore = 0;
    playerScored: string;
    scores: ScoreModel[];

    constructor(championshipRound: ChampionshipRoundModel, scores: ScoreModel[]) {
        this.homeTeam = championshipRound.homeTeam;
        this.guestTeam = championshipRound.guestTeam;
        this.scores = scores;
    }
}