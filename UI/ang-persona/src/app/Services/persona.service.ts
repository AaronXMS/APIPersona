import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PersonaVM, Personas } from '../Models/Persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  constructor(private http:HttpClient) { }
  private url = environment.BaseUrl + 'api/Personas';

  get(filter:any): Observable<Personas[]> {
    let query = filter != null ? `?filter=${filter}` : '';
    return this.http.get<Personas[]>(`${this.url}${query}`);
  }

  post(model: PersonaVM): Observable<any> {
    return this.http.post<any>(this.url, model);
  }

  put(model: Personas): Observable<any> {
    return this.http.put<any>(this.url, model);
  }

  delete(id: string | undefined): Observable<any> {
    return this.http.delete<any>(`${this.url}?id=${id}`);
  }
}
