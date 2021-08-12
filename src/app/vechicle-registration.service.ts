import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Register } from './Models/Register';


@Injectable({
  providedIn: 'root'
})
export class VechicleRegistrationService {
  

 
  constructor(private httpClient:HttpClient) { }

  postVechicle(formData):Observable<Register>
  {
    console.log(formData);
    return this.httpClient.post<Register>("https://localhost:44347/api/Vehicles",formData)
  
  }
}