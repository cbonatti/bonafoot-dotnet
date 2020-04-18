import { DivisionModel } from "./division.model";
import { MatchModel } from "./match.model";

export class ChampionshipModel {
    year: number;
    first: DivisionModel;
    second: DivisionModel;
    third: DivisionModel;
    fourth: DivisionModel;
    matches: MatchModel[];
}