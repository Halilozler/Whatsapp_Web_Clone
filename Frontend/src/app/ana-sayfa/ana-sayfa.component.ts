import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'ana-sayfa',
  templateUrl: './ana-sayfa.component.html',
  styleUrls: ['./ana-sayfa.component.css']
})
export class AnaSayfaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  cik(){
    const id = prompt("id girin:");

    sessionStorage.setItem("id",id!);
    location.reload();
  }

}
