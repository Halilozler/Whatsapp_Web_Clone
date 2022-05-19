using SistemProje.Entities.Concrete;
using SistemProje.Entities.DTO;

namespace SistemProje.DataAccess.I
{
    public interface IKullanici
    {
        Kullanici getKullanici(string kullaniciAdi, string sifre);
        Kullanici getKullanici_id(int id);
        List<SolMenuDto> getKonusulan(int userId);
        List<MesajlarDto> getMesajlar(int Gonderen_id, int Gonderilen_id);
        void setMesaj(int Gonderici_id, int Alici_id, string Mesaj);
    }
}
