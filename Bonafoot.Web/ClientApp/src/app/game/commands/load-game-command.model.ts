import { CommandBase } from "./command-base.model";

export class LoadGameCommand extends CommandBase {
    constructor(name: string) {
        super();
        this.name = name;
    }
}