import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { GameModel } from '../models/game.model';
import { NewGameCommand } from '../commands/new-game-command.model';

@Injectable({
    providedIn: 'root'
})

export class GameService {

    baseurl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseurl = baseUrl + 'api/game';
    }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    New(command: NewGameCommand): Observable<GameModel> {
        return this.http.post<GameModel>(this.baseurl, JSON.stringify(command), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    GetAll(): Observable<GameModel[]> {
        return this.http.get<GameModel[]>(this.baseurl, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    Load(name: string): Observable<GameModel> {
        return this.http.get<GameModel>(this.baseurl + '/' + name, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    Delete(name: string) {
        return this.http.delete<GameModel>(this.baseurl + '/' + name, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    errorHandl(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }

}