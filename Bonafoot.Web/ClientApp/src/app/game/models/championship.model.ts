import { DivisionModel, DivisionIndex } from "./division.model";
import { MatchModel } from "./match.model";

export class ChampionshipModel {
    year: number;
    actualRound: number;
    first: DivisionModel;
    second: DivisionModel;
    third: DivisionModel;
    fourth: DivisionModel;
    matches: MatchModel[];
    teste: any;

    public getDivision(division: DivisionIndex): DivisionModel {
        switch (division) {
            case DivisionIndex.First:
                return this.first;
            case DivisionIndex.Second:
                return this.second;
            case DivisionIndex.Third:
                return this.third;
            case DivisionIndex.Fourth:
                return this.fourth;
            default:
                break;
        }
    }
}