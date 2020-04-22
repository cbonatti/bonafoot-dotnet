import { ModelBaseId } from "./base/model-base-id.model";
import { PlayerModel } from "./player.model";
import { DivisionIndex } from "./division.model";

export class TeamModel extends ModelBaseId {
    money: number;
    primaryColor: string;
    secondaryColor: string;
    moral: number;
    ticketPrice: number;
    stadiumCapacity: number;
    division: DivisionIndex;
    squad: PlayerModel[];
}