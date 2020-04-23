import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class UtilService {
    getOrderSign(order: number): string {
        switch (order) {
            case 1:
                return 'st';
            case 2:
                return 'nd';
            case 3:
                return 'rd'
            default:
                return 'th'
        }
    }

    sortOrder(players: any[], prop: string): any[] {
        return players.sort(function(a, b) {
            if (a[prop] < b[prop]) return -1;
            if (b[prop] > a[prop]) return 1;
            return 0;
          });
    }
}