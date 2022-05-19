using SistemProje.Entities.I;

namespace SistemProje.Entities.DTO
{
    public class SolMenuDto : IDto
    {
        public int Kisi_id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string SonMesaj { get; set; }
        public bool Gonderdinmi { get; set; }
    }
}
