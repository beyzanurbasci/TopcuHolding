using TopcuHolding.Route;

namespace TopcuHolding.Route
{
    public static class Routes
    {


        public static class Home
        {
            public const string Index = "/";

        }



        public class GroupCompanies
        {
           

            public const string ReisMakina = "/ReisMakina";
            public const string TopcularEndustriyel = "/TopcularEndustriyel";
            public const string RevoEndustriyel = "/RevoEndustriyel";
            public const string Mar = "/Mar";


        }

        public static class Media
        {
            public const string Index = "/Medya";
            public const string Detail = "/Detaylar";
            public const string Detail1 = "/Detaylar1";
            public const string Detail2 = "/Detaylar2";
            public const string Detail3 = "/Detaylar3";
            public const string Detail4 = "/Detaylar4";
            public const string Detail5 = "/Detaylar5";
            public const string Detail6 = "/Detaylar6";
            

        }
        public static class Corporate
        {
            public const string Index = "kurumsal";
            public const string About = "/hakkimizda";
            public const string BoardOfManagement = "/yonetimkurulu";
            public const string GeneralManagerMessage = "/genelmuduryazisi";
            public const string History = "/tarihce";
            public const string MissionandVision = "/misyonvizyon";
            public const string OurValues = "/degerlerimiz";
            public const string ManagerMessage = "/yoneticimesaji";
        }

        public static class Contact
        {
            public const string Index = "/iletisim";
        }

        public static class HumanResources
        {
            public const string Index = "/insankaynakları";
        }

        public static class CookieRoutes
        {
            public const string Index = "cerezler";
            public const string Consent = "cerezler/consent";
            public const string SetConsent = "cerezler/onay";
            public const string CookiePolicy = "cerezler/cerezpolitikasi";
        }


    }
}

