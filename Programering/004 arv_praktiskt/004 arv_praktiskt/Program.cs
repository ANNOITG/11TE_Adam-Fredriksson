using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                        /*Klasser skall placeras så att det är en klass per fil (med samma namn). Din kommentering kan förbättras.*/
namespace _004_arv_praktiskt {
    class Program {
        
        static void Main(string[] args) {
            Console.WriteLine("Välkommen till arbetsmiljön! klicka på valfri knapp");
            Console.ReadKey();
            Console.WriteLine("1. Läs av lärare i skolan\n2. Läs av elever i skolan\n" +
                "3. Lägg in lärare i systemet\n4. Lägg in elev i systemet\n5. Tryck på 5 för att avsluta programmet");
            

            Kurs Kursen = new Kurs("Programering", "A+");
            List<Elev> elevLista = new List<Elev>();
            List<Lärare> lärarLista = new List<Lärare>();
            
            lärarLista.Add(new Lärare("Anno", "1337", "Landet", "13371337", "500", new lärarKurser("programering")));
            elevLista.Add(new Elev("addebooi", "1337", "Bajsgatan32", "13371337", "11te", new Kurs("Programering","A+")));
            elevLista.Add(new Elev("Jockebooi", "1336", "Korvgatan92", "SwagNummer", "noob", new Kurs("Svenska1", "F+")));
            for (int i = 0; i < elevLista.Count; i++) {
                elevLista[i].setKurs(new Kurs("Svenska2", "C+"));
                Console.WriteLine(elevLista[i].ToString());
                Console.WriteLine("----------------------------------------------------");
            }

            for (int i = 0; i < lärarLista.Count; i++) {
                lärarLista[i].setKurs(new lärarKurser("WebbserverProgramering"));
                Console.WriteLine(lärarLista[i].ToString());
            }
            
            Console.ReadKey();
        }

        public void skrivUtLärare() {
        }
        public void skrivUtElever() {
        }
        public Lärare läggTillLärare() {
            Lärare lärare = new Lärare("","","","","",new lärarKurser(""));
            return lärare;
        }
        public Elev läggTillElev() {
            Elev elev = new Elev("","","","","",new Kurs("",""));
            return elev;
        }
        
    }
    class Person {
        private string namn;
        private string pnr;
        private string telenr;
        private string adress;

        public string getNamn() { return namn; }
        public void setNamn(string namn) { this.namn = namn; }

        public string getPnr() { return pnr; }
        public void setPnr(string personnummer) { this.pnr = personnummer ; }

        public string getTeleNr() { return telenr; }
        public void setTeleNr(string telenr) { this.telenr = telenr; }

        public string getAdress() { return adress; }
        public void setAdress(string adress) { this.adress = adress; }
    }


    class Lärare : Person {
        private string Lön;
        private List<lärarKurser> Kurs = new List<lärarKurser>();

        public string getLön() { return Lön; }
        public void setLön(string Lön) { this.Lön = Lön; }

        public List<lärarKurser> getKurs() { return Kurs; }
        public void setKurs(lärarKurser kurs) { this.Kurs.Add(kurs); }

        public void höjLön(string ändringAvLön) {
            setLön(Convert.ToString(Convert.ToInt32(getLön()) + Convert.ToInt32(ändringAvLön)));
        }

        public override string ToString() {
            List<lärarKurser> Kurs = getKurs();
            string kursString = "";
            string text = "Namn: " + getNamn() + "\n" + "Adress: " + getAdress() +
                "\n" + "TeleNummer: " + getTeleNr() + "\n" + "Personnummer: " +
                getPnr() + "\nLön: " + getLön() + "\n";
            for (int i = 0; i < Kurs.Count; i++) {
                kursString += "Kurs: " + Kurs[i].kurs + "\n";
            }
            text += kursString;

            return text;
        }
        
        public Lärare(string Namn, string pNr, string Adress, string teleNr, string lön, lärarKurser kurs) {
            setAdress(Adress);
            setNamn(Namn);
            setPnr(pNr);
            setTeleNr(teleNr);
            setLön(lön);
            setKurs(kurs);
        }
    }

    class Elev : Person {
        private List<Kurs> Kurs = new List<Kurs>();
        private string Klass;

        public List<Kurs> getKurs() { return Kurs; }
        public void setKurs(Kurs Kurs) {
            this.Kurs.Add(Kurs);
        }

        public string getKlass() { return Klass; }
        public void setKlass(string Klass) { this.Klass = Klass; }

        public void fåBetygAvLärare(Kurs Kurs) {
            setKurs(Kurs);
        }

        public override string ToString() {
            List<Kurs> Kurs = getKurs();
            string kursString = "";
            string text = "Namn: " + getNamn() + "\n" + "Adress: " + getAdress() +
                "\n" + "TeleNummer: " + getTeleNr() + "\n" + "Personnummer: " +
                getPnr() + "\nKlass: " + getKlass() + "\n";
            for (int i = 0; i < Kurs.Count; i++) {
                kursString += "Betyg: " + Kurs[i].Kursen + " " + Kurs[i].Betyg + "\n";
            }
            text += kursString;

            return text;
        }

        public Elev(string Namn, string pNr, string Adress, string teleNr, string Klass, Kurs Kurs) {
            setAdress(Adress);
            setNamn(Namn);
            setPnr(pNr);
            setTeleNr(teleNr);
            setKurs(Kurs);
            setKlass(Klass);
        }
    }

    public class Kurs {
        public string Kursen { get; set; }
        public string Betyg { get; set; }

        public Kurs(string kurs, string betyg) {
           
            this.Betyg = betyg;
            this.Kursen = kurs;
        }
    }
    public class lärarKurser {
        public string kurs { get; set; }

        public lärarKurser(string kurs) {
            this.kurs = kurs;
        }
    }
}
