using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managing_a_Company {
    class Program {
        static void Main  (string [] args) {
            TestClass test = new TestClass();
            
            }

        }
    public class Company {
        private string Name;
        private string Owner;
        private string ID;
       public HashSet<Employees> employees;
        public HashSet<Estates> estates;
        
        public Company (string Name, string Owner, string ID) {
            this.Name = Name;
            this.Owner = Owner;
            this.ID = ID;
            this.employees = new HashSet<Employees>();
            this.estates = new HashSet<Estates>();
            }
        public override string ToString () {

            StringBuilder res = new StringBuilder();
            res.Append("==========================COMPANY=========================\n\n");
            res.Append("Name: " + this.Name + "\n");
            res.Append("Ownere: " + this.Owner + "\n");
            res.Append("ID: " + this.ID + "\n\n\n\n ------------------------EMPLOYEES------------------------\n\n");

            foreach(Employees emp in this.employees) {
                res.Append(emp);
                res.Append("\n");
                }
            res.Append("\n\n\n\n--------------------------ESTATES--------------------------\n");
            foreach (Estates est in this.estates) {
                res.Append(est);
                res.Append("\n");
                }
            res.Append(".....................................................................................................\n");
            return res.ToString();
            }

        public void AddEmployees (Employees emp) {
            this.employees.Add(emp);
            }
        public void AddEstates (Estates est) {
            this.estates.Add(est);
            }
        }

    public enum WorkPosition

    {
    Boss,Sequrity,Manager,Sanitar,Secretary
    }
    public class Employees {
        private string Name;
        private WorkPosition WP;
        private byte Experience;
        

        public Employees (string Name  , WorkPosition WP,byte Experience) {
            this.Name = Name;
            this.WP = WP;
            this.Experience = Experience;
            }
        public override string ToString () {
            return "[ " + this.Name + " , " + this.WP + " , " + this.Experience + " ]";
            }
        }

    public class Estates {
        private decimal Area;
        private decimal Price;
        private string Location;
        

        public Estates (decimal Area , decimal Price , string Location) {
            this.Area = Area;
            this.Price = Price;
            this.Location = Location;
            }

        public override string ToString () {
            return "Area: " + this.Area + " sq. meters \nPrice: " + this.Price + "$ \nLocation: " + this.Location + " \n";
            }
        }

    public class Shop: Estates {
        public Shop(decimal Area , decimal Price ,
            string Location) : base(Area , Price , Location) {
            }
        }

    public class UndevlopedArea: Estates {
        public UndevlopedArea (decimal Area , decimal Price ,
            string Location) : base(Area , Price , Location) {
            }
        }


    public class Apartments : Estates {
        private byte NumOfFloors;
        private bool Elevator;
        private bool Furbished;

        public Apartments(byte NumOfFloors, bool Elevator, bool Furbished, decimal Area , decimal Price , 
            string Location):base(Area ,Price ,Location) {

            this.NumOfFloors = NumOfFloors;
            this.Furbished = Furbished;
            this.Elevator = Elevator;
            }

        public override string ToString () {
            return base.ToString().Remove(base.ToString().Length - 1) + "\nNumber of the floor: " + NumOfFloors + "\nElevator: " + Elevator + "\nFurbished: " + Furbished+"\n";
            }
        }

    class Houses: Estates {
        private int MetForUndev;
        private int MetForDev;
        private byte Floors;
        private bool Furbished;


        public Houses (int MetForUndev, int MetForDev, byte Floors, 
            bool Furbished, decimal Area , decimal Price , string Location) : 
            base(Area , Price , Location) {

            this.MetForDev = MetForDev;
            this.MetForUndev = MetForUndev;
            this.Floors = Floors;
            this.Furbished = Furbished;
            
            }
        
        public override string ToString () {
            return base.ToString().Remove(base.ToString().Length - 1) + "\nFloors: " + Floors +"\nFubrished: "+Furbished+ "\nFor the undeveloped area: " + MetForUndev + " sq. meters" + "\nFor the developed area: " + MetForDev + " sq. meters\n";
            }

        }

    class TestClass {
        public TestClass () {
            Company company = new Company("BestHous" , "Vasiliy Pupkin" , "123456777");

            Employees employees1 = new Employees("Mark Tven" , WorkPosition.Manager , 65);
            Employees employees2 = new Employees("Aleks Berezhnikh" , WorkPosition.Sanitar , 12);
            Employees employees3 = new Employees("Sergey Krilov" , WorkPosition.Secretary , 35);
            Employees employees4 = new Employees("Andrew Terekhov" , WorkPosition.Boss , 200);
            Employees employees5 = new Employees("Vitaliy Klichko" , WorkPosition.Sequrity , 70);

            Shop shop1 = new Shop(Convert.ToDecimal(200.5) , 5000 , "Alekseev Street");
            Shop shop2 = new Shop(Convert.ToDecimal(1254.98) , 18954 , "Moscow Street");

            UndevlopedArea unda = new UndevlopedArea(Convert.ToDecimal(300) , 2000 , "Grate Park");

            Apartments apartments1 = new Apartments(3 , true , false , 50 , Convert.ToDecimal(1850.56) , "New York");
            Apartments apartments2 = new Apartments(8 , true , true , 300 , Convert.ToDecimal(5920.40) , "Minsk");
            Apartments apartments3 = new Apartments(2 , false , false , 35 , Convert.ToDecimal(1300) , "St Petersburg");

            Houses house1 = new Houses(25 , 30 , 4 , true , Convert.ToDecimal(130) , Convert.ToDecimal(1350) , "Kiev");
            Houses house2 = new Houses(40 , 80 , 9 , true , Convert.ToDecimal(250) , Convert.ToDecimal(8095) , "Samara Gorodok");

            
            
            company.AddEmployees(employees1);
            company.AddEmployees(employees2);
            company.AddEmployees(employees3);
            company.AddEmployees(employees4);
            company.AddEmployees(employees5);
            
            company.AddEstates(shop1);
            company.AddEstates(shop2);
            company.AddEstates(unda);
            company.AddEstates(apartments1);
            company.AddEstates(apartments2);
            company.AddEstates(apartments3);
            company.AddEstates(house1);
            company.AddEstates(house2);

            Console.WriteLine(company);
            Console.ReadKey();
            }
           
        
        }
    }
