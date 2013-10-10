using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                        /*Klasser skall placeras så att det är en klass per fil (med samma namn). Din kommentering kan förbättras.*/
namespace _004_arv_praktiskt {
    class Program {
        //listorna där elever samt lärare sparas
        public static List<Elev> elevLista = new List<Elev>();
        public static List<Lärare> lärarLista = new List<Lärare>();
         
        static void Main(string[] args) {
            /*
            Console.WriteLine("Välkommen till arbetsmiljön! klicka på valfri knapp");
            Program program = new Program();
            elevLista.Add(new Elev("Gabbe", "1337", "snopp", "13371337", "11Te", new Kurs("Programering", "k")));
            elevLista.Add(new Elev("Nuben", "1337", "snopp", "13371337", "11Te", new Kurs("Programering", "k")));
            program.Introduktion();
             */
            
        }
        /*
        public void Introduktion() {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("1. Läs av lärare i skolan\n2. Läs av elever i skolan\n" +
                "3. Lägg in lärare i systemet\n4. Lägg in elev i systemet\n" +
                "5. Redigera Elev\n6. Redigera Lärare\n"+
                "7. avsluta programmet");
            string key = Console.ReadLine();
            Console.Clear();
            if (key == "1") {
                skrivUtLärare();
            }
            if (key == "2") {
                skrivUtElever();
            }
            if (key == "3") {
                läggTillLärare();
            }
            if (key == "4") {
                läggTillElev();
            }
            if (key == "5") {
                redigeraElev();
            }
            if (key == "6") {
                redigeraLärare();
            }
            Console.ReadKey();
        }
        public void skrivUtLärare() {
            if (lärarLista.Count() != 0) {
                for (int i = 0; i < lärarLista.Count; i++) {
                    skrivUtLärarePåIndex(i);
                }
            } else {
                Console.WriteLine("Var god lägg till en lärare!");
                Introduktion();
            }
        }
        public void skrivUtElever() {
            if (elevLista.Count() != 0) {
                for (int i = 0; i < elevLista.Count; i++) {
                    skrivUtElevPåIndex(i);
                    
                }
            } else {
                Console.WriteLine("Var god lägg till en Elev!");
                Introduktion();
            }
        }
        public void redigeraElev() {
            if (elevLista.Count() != 0) {
                int elevVald = -1;
                for (int i = 0; i < elevLista.Count(); i++) {
         *          list<kurs> tempList = new 
                    Console.WriteLine(i + ". " + elevLista[i].getNamn() + " " + elevLista[i].getKlass());
                }
                while(elevVald<0 || elevVald>elevLista.Count()){
                    try {
                        elevVald = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        
                    } catch {
                        Console.WriteLine("Eleven du valde är inte ett index eller existerar inte!, var god skriv indexet!");
                    }
                }
                Console.Clear();
                Console.WriteLine(elevVald);
                if (elevVald != -1 && elevVald < elevLista.Count()) {
                    string ändringAvElev = "";
                    Console.WriteLine("Vad vill du redigera på eleven: " + elevLista[elevVald].getNamn());
                    Console.WriteLine("1. namn\n2. pNr\n3. Adress\n4. teleNr\n5. klass\n6. kurs");

                    string key = Console.ReadLine();
                    Console.Clear();
                    if (key == "1") {
                        Console.Write("Namn: ");
                        ändringAvElev = Console.ReadLine();
                        elevLista[elevVald].setNamn(ändringAvElev);
                        Console.Clear();

                        Console.WriteLine("Namnet är nu ändrat! Tryck på valfri knapp för att komma tillbaka till menyn");
                    }
                    if (key == "2") {
                        Console.Write("Personnummer: ");
                        ändringAvElev = Console.ReadLine();
                        elevLista[elevVald].setPnr(ändringAvElev);
                        Console.Clear();
                        Console.WriteLine("Personnummret är nu ändrat! Tryck på valfri knapp för att komma tillbaka till menyn");
                    }
                    if (key == "3") {
                        Console.Write("Adress: ");
                        ändringAvElev = Console.ReadLine();
                        elevLista[elevVald].setAdress(ändringAvElev);
                        Console.Clear();
                        Console.WriteLine("Adressen är nu ändrat! Tryck på valfri knapp för att komma tillbaka till menyn");
                    }
                    if (key == "4") {
                        Console.Write("Telenr: ");
                        ändringAvElev = Console.ReadLine();
                        elevLista[elevVald].setTeleNr(ändringAvElev);
                        Console.Clear();
                        Console.WriteLine("Telefonnummret är nu ändrat! Tryck på valfri knapp för att komma tillbaka till menyn");
                    }
                    if (key == "5") {
                        Console.Write("Klass: ");
                        ändringAvElev = Console.ReadLine();
                        elevLista[elevVald].setKlass(ändringAvElev);
                        Console.Clear();
                        Console.WriteLine("Klassen är nu ändrat! Tryck på valfri knapp för att komma tillbaka till menyn");
                    }
                    if (key == "6") {
                        for (int i = 0; i < elevLista[elevVald].getKurs().Count(); i++) {
                            Console.WriteLine(i + ". " + elevLista[elevVald].getKurs()[i].Kursen);
                        }
                        Console.ReadKey();
                    }
                    Introduktion();
                } 

                else {
                    Console.WriteLine("Eleven du skrev finns inte i registret");
                    Introduktion();
                }

            } else {
                Console.WriteLine("Var god lägg till en Elev!");
                Introduktion();
            }
        }
        public void skrivUtElevPåIndex(int index) {
            Console.WriteLine(elevLista[index].ToString());
            Console.WriteLine("----------------------------------------------------");
        }
        public void skrivUtLärarePåIndex(int index) {
            Console.WriteLine(lärarLista[index].ToString());
            Console.WriteLine("----------------------------------------------------");
        }
        public void redigeraLärare() {
            if (lärarLista.Count() != 0) {
                //Redigera elev listan
            } else {
                Console.WriteLine("Var god lägg till en lärare!");
                Introduktion();
            }
        }
        public Lärare läggTillLärare() {
            Lärare lärare = new Lärare("","","","","",new lärarKurser(""));
            return lärare;
        }
        public Elev läggTillElev() {
            Elev elev = new Elev("","","","","",new Kurs("",""));
            return elev;
        } 
         */
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
        public List<Kurs> getKursUtanBetyg() {
            List<Kurs> tempList = new List<Kurs>();
            for (int i = 0; i < Kurs.Count(); i++) {
                if (Kurs[i].Betyg == "" || Kurs[i].Betyg == null) {
                    tempList.Add(Kurs[i]);
                }
            }
            return tempList;
        }
        public List<Kurs> getKursMedBetyg() {
            List<Kurs> tempList = new List<Kurs>();
            for (int i = 0; i < Kurs.Count(); i++) {
                if (Kurs[i].Betyg != "") {
                    tempList.Add(Kurs[i]);
                }
            }
            return tempList;
        }
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
