export class ScoreModel {
    name: string;
    minute: number;
    home: boolean;

    constructor(name: string, minute: number, home: boolean) {
        this.name = name;
        this.minute = minute;
        this.home = home;
    }
}