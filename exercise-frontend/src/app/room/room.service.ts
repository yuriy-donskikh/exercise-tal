import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from "../../environments/environment";
import { AddRoom } from "./Models/addRoom";
import { IRoom } from './Models/room';
import { IRoomTime } from "./Models/room-time";

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  private roomUrl = environment.backendUrl + 'api/room';
  private updateRoomsTimeUrl = environment.backendUrl + '/api/room/{id}/time';

  constructor(private http: HttpClient) { }

  getAllRooms():Observable<IRoom[]> {
    return this.http.get<IRoom[]>(this.roomUrl).pipe(
      catchError(this.handleError)
    );
  }

  deleteRoom(id:number):Observable<any>{
    return this.http.delete(`${this.roomUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  updateTime(id:number, time:IRoomTime):Observable<any> {
      var prefix = time.available ? '': 'un';
      return this.http.put(`${this.roomUrl}/${id}/${prefix}available/${time.time}`, null).pipe(
        catchError(this.handleError)
      );
  }

  addRoom(room:AddRoom): Observable<IRoom>{
    return this.http.post<IRoom>(this.roomUrl, room).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse): Observable<never> {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }

}
