import { ModelBaseId } from "./base/model-base-id.model";

export enum PlayerPosition {
    Goalkeeper = 0,
    Defender = 1,
    Midfielder = 2,
    Striker = 3
}

export class PlayerModel extends ModelBaseId {
    strength: number;
    position: PlayerPosition;
    salary: number;
    select: boolean;
}