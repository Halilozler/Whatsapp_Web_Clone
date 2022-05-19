import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { kullanici, MesajGonderDto, MesajlarDto } from '../_model/model';
import { CommonService } from '../_service/common.service';
import { KullaniciService } from '../_service/kullanici.service';

@Component({
  selector: 'sag-menu',
  templateUrl: './sag-menu.component.html',
  styleUrls: ['./sag-menu.component.css']
})
export class SagMenuComponent implements OnInit {
  karsi_id!: number;
  id!: number;
  varmi: boolean = false;
  Karsi_kisi!: kullanici;
  Mesajlar: MesajlarDto[] = [];
  mesaj!:string;

  message: any;
  private subscriptionName!: Subscription;

  constructor(private CommonService: CommonService, private service: KullaniciService) { 
    

    this.id = Number(sessionStorage.getItem("id"));

    this.subscriptionName= this.CommonService.getUpdate().subscribe
            (message => { 
              this.karsi_id = parseInt(message.text);
              if(this.karsi_id){
                this.varmi = true;
                service.getKullanici(this.karsi_id).subscribe(x => {
                  this.Karsi_kisi = x;
                });
                service.getMesajlar(this.id,this.karsi_id).subscribe(x => {
                  this.Mesajlar = x;
                });
                var obj = document.getElementById("gorunursohbet");
                obj!.scrollTop = obj!.scrollHeight;
              }
            });         
  }

  ngOnInit(): void {
  }

  ngOnDestroy() { // It's a good practice to unsubscribe to ensure no memory leaks
    this.subscriptionName.unsubscribe();
  }
  yaz(){
    if(this.mesaj.length > 0){
      const mesaj = new MesajGonderDto(this.id,this.karsi_id,this.mesaj);
      const now = new Date();
      this.service.MesajGonder(mesaj).subscribe(() => {});

      const list = document.querySelector("#gorunursohbet");
      
      const div = document.createElement("div");
      div.className = "giden_mesaj mesaj";

      const div_yazi = document.createElement("div");
      div_yazi.className = "yazi";
      const p = document.createElement("p");
      p.innerHTML = mesaj.mesaj;
      div_yazi.appendChild(p);

      const div_saat = document.createElement("div");
      div_saat.className = "saat";
      div_saat.innerHTML = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();

      div.appendChild(div_yazi);
      div.appendChild(div_saat);
      
      list?.appendChild(div);
    }
  }

}
