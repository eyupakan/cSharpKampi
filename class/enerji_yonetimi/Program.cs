using System;
namespace EnerjiYonetimSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Enerji yönetim sisteminin statik adını yazdırma.
            Console.WriteLine($"Sistem Adı: {EnerjiKaynagi.SistemAdi}");
            
            // İlk enerji kaynağı: Güneş enerjisi nesnesi oluşturma.
            GunesEnerjisi gunes = new GunesEnerjisi("Güneş Paneli", 120, 85.5);

            // Güneş enerjisi nesnesinin bilgilerini yazdırma.
            Console.WriteLine("\nGüneş Enerjisi Bilgileri:");
            gunes.BilgiYazdir(); // Kaynak adı, kapasite ve kullanım oranı bilgilerini yazdırır.

            // Güneş enerjisinin enerji üretim metotlarını çağırma.
            Console.WriteLine("\nEnerji Üretim Detayları:");
            gunes.EnerjiUret(); // Standart enerji üretimi.
            gunes.EnerjiUret(50); // Ek yük ile enerji üretimi (overload).
            gunes.VerimlilikHesapla(); // Verimlilik hesaplama.

            // Sistem genelinde kaç enerji kaynağı olduğunu yazdırma.
            Console.WriteLine($"\nToplam Enerji Kaynağı Sayısı: {EnerjiKaynagi.KaynakSayisi}");
        }

        public abstract class EnerjiKaynagi
    {
        // Enerji kaynağının adı.
        public string KaynakAdi { get; set; }

        // Enerji yönetim sisteminin adı (statik üye).
        public static string SistemAdi = "Enerji Yönetim Sistemi";

        // Statik sayaç: Kaç enerji kaynağı oluşturulduğunu takip eder.
        public static int KaynakSayisi = 0;

        // Abstract metod: Alt sınıflar bu metodu kendi ihtiyaçlarına göre tanımlamalıdır.
        public abstract void EnerjiUret();

        // Virtual metod: Alt sınıflar isterse bu metodu değiştirebilir.
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Kaynak Adı: {KaynakAdi}");
        }

        // Constructor: Her enerji kaynağı oluşturulduğunda sayaç artırılır.
        public EnerjiKaynagi()
        {
            KaynakSayisi++;
        }
    }

    // Alt sınıf: Güneş enerjisi için bir temsil.
    public class GunesEnerjisi : EnerjiKaynagi
    {
        // Güneş enerjisinin üretim kapasitesi (kWh cinsinden).
        public int UretimKapasitesi { get; set; }

        // Güneş panellerinin kullanım oranı (0-100% arasında).
        public double KullanimOrani { get; set; }

        // Parametreli yapıcı fonksiyon (this ile kullanım).
        public GunesEnerjisi(string kaynakAdi, int uretimKapasitesi, double kullanimOrani)
        {
            this.KaynakAdi = kaynakAdi; // Abstract sınıftan gelen özellik.
            this.UretimKapasitesi = uretimKapasitesi; // Güneş enerjisinin kapasitesi.
            this.KullanimOrani = kullanimOrani; // Güneş panellerinin kullanım oranı.
        }

        // Abstract metodu override ederek güneş enerjisi üretimini tanımlar.
        public override void EnerjiUret()
        {
            Console.WriteLine($"{KaynakAdi} enerji üretiyor. Kapasite: {UretimKapasitesi} kWh, Kullanım Oranı: {KullanimOrani}%");
        }

        // Overload edilmiş enerji üretim metodu: Ek yük parametresi ile.
        public void EnerjiUret(double ekYuk)
        {
            double toplamKapasite = UretimKapasitesi + ekYuk;
            Console.WriteLine($"{KaynakAdi} enerji üretiyor. Ek yük: {ekYuk} kWh ile toplam kapasite: {toplamKapasite} kWh");
        }

        // Verimlilik hesaplayan yeni bir metot.
        public void VerimlilikHesapla()
        {
            double verimlilik = UretimKapasitesi * (KullanimOrani / 100);
            Console.WriteLine($"Güneş panelinin verimliliği: {verimlilik} kWh");
        }

        // Override edilen BilgiYazdir metodu.
        public override void BilgiYazdir()
        {
            base.BilgiYazdir(); // Abstract sınıftaki temel bilgiyi yazdırır.
            Console.WriteLine($"Üretim Kapasitesi: {UretimKapasitesi} kWh");
            Console.WriteLine($"Kullanım Oranı: {KullanimOrani}%");
        }
    }
    }
}

