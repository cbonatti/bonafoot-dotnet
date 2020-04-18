import { CommandBase } from "./command-base.model";

export class DeleteGameCommand extends CommandBase {
    constructor(name: string) {
        super();
        this.name = name;
    }
}