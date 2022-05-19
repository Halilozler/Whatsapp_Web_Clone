using System.Security.Cryptography;
using System.Text;
using SistemProje.Entities.Concrete;

namespace SistemProje.Core
{
    public static class AESsifreleme
    {
        private const string AES_IV = @"!&+QWSDF!123126+";

        public static string AESsifrele(string metin, int gonderilenId)
        {
            AesCryptoServiceProvider aesSaglayici = new AesCryptoServiceProvider();
            aesSaglayici.BlockSize = 128;  //blok blok şifreleme yapıldığı için(128 byte)
            aesSaglayici.KeySize = 256;    // ne kadarlık bloklar halinde şifreleneceği tanımlanıyor

            aesSaglayici.IV = Encoding.UTF8.GetBytes(AES_IV);


            //string metın = "QQsaw!257()%%ert";
            string metın = EF.Get<Kullanici>(x => x.id == gonderilenId).Anahtar;

            string anahtar = $@"{metın}";

            aesSaglayici.Key = Encoding.UTF8.GetBytes(anahtar);  //key to byte
            aesSaglayici.Mode = CipherMode.CBC; //Şifreleme modu ( cbc )
            //Böylece evrensel olarak bütün dosya, resim, metin vs
            //bytelara çevrilerek şifreleme yapılabilir.
            aesSaglayici.Padding = PaddingMode.PKCS7;

            byte[] kaynak = Encoding.Unicode.GetBytes(metin);   //metin de bytelara çevrilir
            using (ICryptoTransform sifrele = aesSaglayici.CreateEncryptor())
            {   // şifreleme burda gerçekleşiyor
                byte[] hedef = sifrele.TransformFinalBlock(kaynak, 0, kaynak.Length);
                return Convert.ToBase64String(hedef);
            }
        }
        public static string AESsifre_Coz(string sifreliMetin, int id)
        {
            AesCryptoServiceProvider aesSaglayici = new AesCryptoServiceProvider();
            aesSaglayici.BlockSize = 128;   // Standart
            aesSaglayici.KeySize = 256;

            aesSaglayici.IV = Encoding.UTF8.GetBytes(AES_IV);

            //string metın = "QQsaw!257()%%ert";
            string metın = EF.Get<Kullanici>(x => x.id == id).Anahtar;

            string anahtar = $@"{metın}";

            aesSaglayici.Key = Encoding.UTF8.GetBytes(anahtar);
            aesSaglayici.Mode = CipherMode.CBC;
            aesSaglayici.Padding = PaddingMode.PKCS7;

            try
            {
                byte[] kaynak = System.Convert.FromBase64String(sifreliMetin);
                using (ICryptoTransform decrypt = aesSaglayici.CreateDecryptor())
                {
                    byte[] hedef = decrypt.TransformFinalBlock(kaynak, 0, kaynak.Length);
                    return Encoding.Unicode.GetString(hedef);
                }
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                return "HATA   :" + hata;

            }
        }
    }
}
