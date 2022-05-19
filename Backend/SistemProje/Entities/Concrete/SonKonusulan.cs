using SistemProje.Entities.I;

namespace SistemProje.Entities.Concrete
{
    public class SonKonusulan : IEntity
    {
        public int id { get; set; }
        public int Mesaj_id { get; set; }
        public int Gonderici_id { get; set; }
        public int Alici_id { get; set; }
    }
}
