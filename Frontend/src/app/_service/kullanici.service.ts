import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { kullanici, MesajGonderDto, MesajlarDto, SolMenuDto } from '../_model/model';

@Injectable({
  providedIn: 'root'
})
export class KullaniciService {

  baseUrl: string = "https://localhost:7122/api/Kullanici/";

  constructor(private http: HttpClient) { 

  }

  getSolKisi(id: number): Observable<SolMenuDto[]>{
    return this.http.get<SolMenuDto[]>(this.baseUrl + "Konusulan/" + id);
  }

  giris?(k_adi: string, sifre: string): Observable<kullanici>{
    return this.http.get<kullanici>(this.baseUrl + "Giris/" + k_adi + "/" + sifre);
  }

  getKullanici(id: number): Observable<kullanici>{
    return this.http.get<kullanici>(this.baseUrl + "kullanici/" + id);
  }

  getMesajlar(id: number, Gonderilen_id: number): Observable<MesajlarDto[]>{
    return this.http.get<MesajlarDto[]>(this.baseUrl + "mesajlar/" + id + "/" + Gonderilen_id);
  }


  MesajGonder(mesaj: MesajGonderDto){
    return this.http.post(this.baseUrl + "mesajGonder",mesaj);
  }
}
