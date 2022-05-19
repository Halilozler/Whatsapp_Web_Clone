using SistemProje.Entities.I;

namespace SistemProje.Entities.Concrete
{
    public class Kullanici : IEntity
    {
        public int id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Kullanici_Adi { get; set; }
        public string Sifre { get; set; }
        public string Anahtar { get; set; }
    }
}
