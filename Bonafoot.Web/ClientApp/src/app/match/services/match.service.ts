import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { PlayMatchCommand } from '../commands/play-match-command.model';
import { ChampionshipModel } from 'src/app/game/models/championship.model';

@Injectable({
    providedIn: 'root'
})

export class MatchService {

    baseurl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseurl = baseUrl + 'api/match';
    }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    Play(command: PlayMatchCommand): Observable<ChampionshipModel> {
        return this.http.post<ChampionshipModel>(this.baseurl, JSON.stringify(command), this.httpOptions)
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

/*


criar pagina com os jogos "em tempo real"
depois exibir pagina com a classificacao
depois voltar para a tela do time 


*/