using SistemProje.Entities.I;

namespace SistemProje.Entities.Concrete
{
    public class Mesaj : IEntity
    {
        public int id { get; set; }
        public int Gonderen_id { get; set; }
        public int Gonderilen_id { get; set; }
        public string MesajMetni { get; set; }
        public DateTime Tarih { get; set; }
    }
}
