using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemProje.DataAccess.Concrete;
using SistemProje.DataAccess.I;
using SistemProje.Entities.DTO;

namespace SistemProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullanici _kullanici;

        public KullaniciController()
        {
            _kullanici = new EfKullanici();
        }

        //girişte kullanıcı almak için
        //https://localhost:7122/api/...
        [HttpGet("Giris/{kullaniciAdi}/{Sifre}")]
        public IActionResult Giris(string kullaniciAdi, string Sifre)
        {
            var user = _kullanici.getKullanici(kullaniciAdi, Sifre);
            if (user == null)
                return BadRequest(404);
            return Ok(user);
        }

        [HttpGet("kullanici/{id}")]
        public IActionResult Kullanici(int id)
        {
            return Ok(_kullanici.getKullanici_id(id));
        }

        //solda bulununan son konuşulan sekmesini görmek için
        [HttpGet("Konusulan/{id}")]
        public IActionResult Konusulan(int id)
        {
            var users = _kullanici.getKonusulan(id);
            return Ok(users);
        }

        //mesaj sekmesinden konuştuğun kişi ile mesajlara bakmak için
        [HttpGet("mesajlar/{userId}/{Gonderilen_id}")]
        public IActionResult MesajlarGetir(int userId, int Gonderilen_id)
        {
            var mesaj = _kullanici.getMesajlar(userId, Gonderilen_id);
            return Ok(mesaj);
        }

        [HttpPost("mesajGonder")]
        public IActionResult MesajGonder(MesajGonderDto mesaj)
        {
            _kullanici.setMesaj(mesaj.Gonderici, mesaj.Alici, mesaj.Mesaj);
            return Ok();
        }
    }
}
