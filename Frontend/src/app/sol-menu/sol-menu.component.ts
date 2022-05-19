import { Component, OnInit } from '@angular/core';
import { SolMenuDto } from '../_model/model';
import { CommonService } from '../_service/common.service';
import { KullaniciService } from '../_service/kullanici.service';

@Component({
  selector: 'sol-menu',
  templateUrl: './sol-menu.component.html',
  styleUrls: ['./sol-menu.component.css']
})
export class SolMenuComponent implements OnInit {

  kisiler: SolMenuDto[] = []; 

  constructor(private service: KullaniciService, private CommonService: CommonService) { 
    this.getKisiler();
  }

  ngOnInit(): void {
  }

  getKisiler(){
    var id = sessionStorage.getItem("id");
    if(id == null){
      id = "1";
    }
    this.service.getSolKisi(parseInt(id)).subscribe(x => {
      for(let i= 0; i < x.length; i++){
        this.kisiler.push(x[i]);
      }
    });
  }

  getir(id: number ){
    sessionStorage.setItem("karsi_id",id.toString());
    this.CommonService.sendUpdate(id.toString());
  }

}
