import { ModelBaseId } from "./base/model-base-id.model";
import { PlayerModel } from "./player.model";

export class TeamModel extends ModelBaseId {
    money: number;
    primaryColor: string;
    secondaryColor: string;
    moral: number;
    ticketPrice: number;
    stadiumCapacity: number;
    squad: PlayerModel[];
}