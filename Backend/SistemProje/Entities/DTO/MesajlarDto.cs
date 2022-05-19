using SistemProje.Entities.I;

namespace SistemProje.Entities.DTO
{
    public class MesajlarDto : IDto
    {
        public string Mesaj { get; set; }
        public string Saat { get; set; }
        public bool Gonderdi { get; set; }
    }
}
