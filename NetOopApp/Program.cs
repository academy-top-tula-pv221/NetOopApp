using System.Xml.Linq;

namespace NetOopApp
{
    class Person
    {
        string name;
        int age;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public virtual int Age
        {
            set
            {
                if(value >= 0 && value <= 100)
                    age = value;
            }
            get => age;
        }

        public Person() { }
        public Person(string name) => this.name = name;
        public virtual void Print()
        {
            Console.WriteLine($"Name: {name}");
        }
        public void PrintFull()
        {
            Console.WriteLine($"{Name} {Age}");
        }
    }

    class Employe : Person
    {
        int salary;

        public new string Name
        {
            get => "mr. " + base.Name;
            set => base.Name = value;
        }
        public int Salary
        {
            get => salary;
            set => salary = value;
        }

        public override int Age 
        { 
            get => base.Age; 
            set 
            {
                if(value >= 18 && value <= 75)
                    base.Age = value;
            }
        }
        public Employe() { }
        
        public Employe(string name, int salary) : base(name)
        {
            this.salary = salary;
        }
        public override sealed void Print()
        {
            base.Print();
            Console.WriteLine($"Salary: {salary}");
        }

        public new void PrintFull()
        {
            Console.WriteLine($"{Name} {Age} {Salary}");
        }
    }

    class Citizen : Person
    {
        public string Passport { set; get; }
        public Citizen() { }
        public Citizen(string name, string passport) : base(name)
        {
            Passport = passport;
        }
    }

    class MyClass
    {

    }
   

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() { Name = "Person", Age = 23 };
            person.Print();
            person.PrintFull();

            person = new Employe() { Name = "Employe", Age = 34, Salary = 50000 };
            person.Print();
            ((Employe)person).PrintFull();

            person = new Citizen() { Name = "Citizen", Age = 43, Passport = "AS12344" };
            person.Print();
            person.PrintFull();

            //((Citizen)person).Passport = "AS56565";
            //var obj = person as Citizen;
            //if(obj is not null)
            //    obj.Passport = "AS23456";

            //IsPerson(new Person() { Name = "Person" });
            //IsPerson(new Employe() { Name = "Emplye", Salary = 10000 });
            //IsPerson(new Citizen() { Name = "Citizen", Passport = "AS12345"});
            //IsPerson(new MyClass());

            void IsPerson(object obj)
            {
                //Person person1;
                //if (obj is Person)
                //{
                //    person1 = obj as Person;
                //    // person
                //}

                if (obj is Person person2)
                {
                    person2.Print();
                }

                // person

            }
        }
    }
}