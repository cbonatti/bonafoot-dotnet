import { CommandBase } from "src/app/game/commands/command-base.model";


export class PlayMatchCommand extends CommandBase {
    players: string[];

    constructor(name: string, players: string[]) {
        super();
        this.name = name;
        this.players = players;
    }
}