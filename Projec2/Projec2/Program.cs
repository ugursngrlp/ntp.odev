using Ev.Libs;
namespace Projec2
{
    internal class Program
    {
        #region Değişkenler
        static string menu_msg = "Lütfen işlem yapmak istediğiniz numarayı ya da ilgili kelimeleri giriniz " +
            "\n1:Satılık Ev\n2:Kiralık Ev\nCevabınız: ";
        static string secim_msg = "Hangi türde işlem yapmak istiyorsunuz?" +
            "\n1:Tüm Evleri Görüntüle\n2:Yeni Ev Girişi\nCevabınız: ";
        static string secim2_msg = "İşlemlere devam etmek istiyor musunu?\n1:Evet\n2:Hayır";
        static Boolean kontrol = true;
        static List<SatilikEv> satilik_ev_list = new List<SatilikEv>();
        static List<KiralikEv> kiralik_ev_list = new List<KiralikEv>();

        #endregion
        static void Main(string[] args)
        {
            do
            {
                Menu();
            } while (kontrol == true);
            KiralikEvKayit();
            SatilikEvKayit();
            Console.WriteLine("Hoşçakalın!..");
            Console.ReadLine();
        }
        static void Menu()
        {
            Console.Write(menu_msg);
            string secim = Console.ReadLine();
            if (secim == "1" || secim == "satılık ev")
            {
                Console.Write(secim_msg);
                string secim2 = Console.ReadLine();
                if (secim2 == "1" || secim2 == "tüm evleri görüntüle")
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    SatilikEvBilgileriYazdir();
                    Console.WriteLine("----------------------------------------------------------------------");
                }
                else if (secim2 == "2" || secim2 == "yeni ev girişi")
                {
                    SatilikEvGirisi();
                }
            }
            else if (secim == "2" || secim == "kiralık ev")
            {
                Console.Write(secim_msg);
                string secim2 = Console.ReadLine();
                if (secim2 == "1" || secim2 == "tüm evleri görüntüle")
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    KiralikEvBilgileriYazdir();
                    Console.WriteLine("----------------------------------------------------------------------");
                }
                else if (secim2 == "2" || secim2 == "yeni ev girişi")
                {
                    KiralikEvGirisi();
                }
            }

            Console.WriteLine(secim2_msg);
            string secim3 = Console.ReadLine().ToLower();
            if (secim3 == "hayir" || secim3 == "2")
            {
                kontrol = false;
            }

        }

        public static void SatilikEvGirisi()
        {
            SatilikEv satilikEv = new SatilikEv();
            Console.WriteLine("Evin Oda Sayısı:");
            satilikEv.oda_sayisi = byte.Parse(Console.ReadLine());
            Console.WriteLine("Evin Kat Sayısı:");
            satilikEv.kat_sayisi = byte.Parse(Console.ReadLine());
            Console.WriteLine("Evin Semti:");
            satilikEv.semt = Console.ReadLine();
            Console.WriteLine("Evin Tuvalet Sayısı:");
            satilikEv.tuvalet_sayisi = byte.Parse(Console.ReadLine());
            Console.WriteLine("Depozito:");
            satilikEv.depozito = float.Parse(Console.ReadLine());
            Console.WriteLine("Evin Fiyatı:");
            satilikEv.ev_fiyati = int.Parse(Console.ReadLine());
            satilik_ev_list.Add(satilikEv);
        }
        public static void KiralikEvGirisi()
        {
            KiralikEv kiralikEv = new KiralikEv();
            Console.WriteLine("Evin Oda Sayısı:");
            kiralikEv.oda_sayisi = byte.Parse(Console.ReadLine());
            Console.WriteLine("Evin Kat Sayısı:");
            kiralikEv.kat_sayisi = byte.Parse(Console.ReadLine());
            Console.WriteLine("Evin Semti:");
            kiralikEv.semt = Console.ReadLine();
            Console.WriteLine("Evin Tuvalet Sayısı:");
            kiralikEv.tuvalet_sayisi = byte.Parse(Console.ReadLine());
            Console.WriteLine("Depozito:");
            kiralikEv.depozito = float.Parse(Console.ReadLine());
            Console.WriteLine("Evin Fiyatı:");
            kiralikEv.kira = int.Parse(Console.ReadLine());
            kiralik_ev_list.Add(kiralikEv);
        }
        public static void SatilikEvKayit()
        {
            string logsFolderPath = @"C:\Logs";
            string filePath = Path.Combine(logsFolderPath, "SatilikEv.txt");

            foreach (var satilikEv in satilik_ev_list)
            {
                File.AppendAllText(filePath, satilikEv.EvBilgileriGetir() + Environment.NewLine);
            }
        }

        public static void KiralikEvKayit()
        {
            string logsFolderPath = @"C:\Logs";
            string filePath = Path.Combine(logsFolderPath, "KiralikEv.txt");

            foreach (var kiralikEv in kiralik_ev_list)
            {
                File.AppendAllText(filePath, kiralikEv.EvBilgileriGetir() + Environment.NewLine);
            }
        }
        static void SatilikEvBilgileriYazdir()
        {
            string satilikEvDosyaYolu = @"C:\Logs\SatilikEv.txt";
            string satilikEvIcerik = File.ReadAllText(satilikEvDosyaYolu);
            Console.WriteLine("Satılık Evlerin Bilgileri:");
            Console.WriteLine("*******************");
            Console.WriteLine(satilikEvIcerik);
        }
        static void KiralikEvBilgileriYazdir()
        {
            string kiralikEvDosyaYolu = @"C:\Logs\KiralikEv.txt";
            string kiralikEvIcerik = File.ReadAllText(kiralikEvDosyaYolu);
            Console.WriteLine("Kiralık Evlerin Bilgileri:");
            Console.WriteLine("*******************");
            Console.WriteLine(kiralikEvIcerik);
        }
    }
}


