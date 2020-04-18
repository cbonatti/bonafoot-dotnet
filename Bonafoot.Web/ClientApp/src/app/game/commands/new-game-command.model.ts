import { CommandBase } from "./command-base.model";

export class NewGameCommand extends CommandBase {
    constructor(name: string) {
        super();
        this.name = name;
    }
}