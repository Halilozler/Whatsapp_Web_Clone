export class kullanici{
    id!: number;
    ad!: string;
    soyad!: string;
    kullanici_Adi!: string;
    sifre!: string;
}

export class SolMenuDto{
    kisi_id!: number;
    ad!: string;
    soyad!: string;
    sonMesaj!: string;
    gonderdinmi!: boolean;
}

export class MesajlarDto{
    mesaj!: string;
    saat!: string;
    gonderdi!: boolean;
}

export class MesajGonderDto{
    constructor(gonderen: number,alan: number, mesaj: string) {
        this.gonderici = gonderen;
        this.alici = alan;
        this.mesaj = mesaj;
    }

    gonderici!: number;
    alici!: number;
    mesaj!: string;
}