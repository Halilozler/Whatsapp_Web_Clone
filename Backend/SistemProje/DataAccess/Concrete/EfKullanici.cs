using Microsoft.EntityFrameworkCore;
using SistemProje.Core;
using SistemProje.DataAccess.I;
using SistemProje.Entities.Concrete;
using SistemProje.Entities.DTO;
using EF = SistemProje.Core.EF;

namespace SistemProje.DataAccess.Concrete
{
    public class EfKullanici : IKullanici
    {
        public Kullanici getKullanici(string kullaniciAdi, string sifre)
        {
            Kullanici hesap = EF.Get<Kullanici>(x => x.Kullanici_Adi == kullaniciAdi && x.Sifre == sifre);
            if (hesap == null)
            {
                return null;
            }
            return hesap;
        }

        public Kullanici getKullanici_id(int id)
        {
            return EF.Get<Kullanici>(x => x.id == id);
        }

        public List<SolMenuDto> getKonusulan(int userId)
        {
            List<SolMenuDto> list = new List<SolMenuDto>();
            List<SonKonusulan> konusulanlar = EF.GetAll<SonKonusulan>(x => x.Gonderici_id == userId || x.Alici_id == userId);
            if (konusulanlar.Count == 0)
                return null;

            foreach (var item in konusulanlar)
            {
                Kullanici user;
                SolMenuDto menu = new SolMenuDto();
                if (item.Gonderici_id == userId)
                {
                    menu.Kisi_id = item.Alici_id;
                    user = EF.Get<Kullanici>(x => x.id == menu.Kisi_id);
                    menu.Gonderdinmi = true;
                }
                else
                {
                    menu.Kisi_id = item.Gonderici_id;
                    user = EF.Get<Kullanici>(x => x.id == menu.Kisi_id);
                    menu.Gonderdinmi = false;
                }
                menu.Ad = user.Ad;
                menu.Soyad = user.Soyad;

                Mesaj mes = EF.Get<Mesaj>(x => x.id == item.Mesaj_id);
                menu.SonMesaj = AESsifreleme.AESsifre_Coz(mes.MesajMetni, mes.Gonderilen_id);
                list.Add(menu);
            }
            return list;
        }

        public List<MesajlarDto> getMesajlar(int Gonderen_id, int Gonderilen_id)
        {
            List<MesajlarDto> mesajDto = new List<MesajlarDto>();
            List<Mesaj> mesajlar = EF.GetAll<Mesaj>(x => (x.Gonderen_id == Gonderen_id && x.Gonderilen_id == Gonderilen_id) || (x.Gonderen_id == Gonderilen_id && x.Gonderilen_id == Gonderen_id))
                .OrderBy(x => x.Tarih).ToList();
            //Tarih küçükten büyüğe sıraladık

            if (mesajlar.Count == 0)
                return null;

            foreach (var item in mesajlar)
            {
                MesajlarDto mesaj = new MesajlarDto();

                mesaj.Saat = item.Tarih.ToString().Split(" ")[1];
                if (item.Gonderen_id == Gonderen_id)
                {
                    mesaj.Gonderdi = true;
                }
                else
                {
                    mesaj.Gonderdi = false;
                }
                mesaj.Mesaj = AESsifreleme.AESsifre_Coz(item.MesajMetni, item.Gonderilen_id);    

                mesajDto.Add(mesaj);
            }

            return mesajDto;
        }

        public void setMesaj(int Gonderici_id, int Alici_id, string Mesaj_Metni)
        {
            Mesaj mesaj = new Mesaj();
            mesaj.Gonderen_id = Gonderici_id;
            mesaj.Gonderilen_id = Alici_id;

            mesaj.MesajMetni = AESsifreleme.AESsifrele(Mesaj_Metni,Alici_id);

            mesaj.Tarih = DateTime.Now;

            mesaj = EF.Add<Mesaj>(mesaj);

            //int id = mesaj.id;
            EF.Update(mesaj.Gonderen_id, mesaj.Gonderilen_id,mesaj.id);
        }
    }
}
