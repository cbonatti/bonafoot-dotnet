export class NextRoundModel {
    name: string;
    position: number;
    points: number;

    constructor(name: string, position: number, points: number) {
        this.name = name;
        this.position = position;
        this.points = points;
    }
}