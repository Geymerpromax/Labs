/*Разработать классы для описанных ниже объектов. Включить в класс методы Set(…), Get(…), Show(…). 
  Определить свои методы для класса.

Вариант 2. Applicant (абитуриент): Фамилия, Имя, Отчество, Адрес, Оценки. Создать массив объектов. Вывести:
a) список абитуриентов, имеющих неудовлетворительные оценки;
b) список абитуриентов, средний балл у которых выше заданного;
c) выбрать заданное число N абитуриентов, имеющих самый высокий средний балл 
*/

using System;
using System.Collections.Generic;


namespace Lab4
{
    internal class Program
    {
        private static Random rnd = new Random();

        private static int[] GenerateAssessments()
        {
            return new int[] { rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6) };
        }

        static void Main()
        {
            Applicant applicantOne = new Applicant("Алексеев", "Артем", "Владимирович", "Беляева 1", GenerateAssessments());
            Applicant applicantTwo = new Applicant("Иванова", "Екатерина", "Дмитриевна", "Беляева 2", GenerateAssessments());
            Applicant applicantThree = new Applicant("Смирнов", "Сергей", "Александрович", "Беляева 3", GenerateAssessments());
            Applicant applicantFour = new Applicant("Петрова", "Анна", "Игоревна", "Беляева 4", GenerateAssessments());
            Applicant applicantFive = new Applicant("Козлов", "Денис", "Алексеевич", "Беляева 5", GenerateAssessments());

            List<Applicant> apps = new List<Applicant>() { applicantOne, applicantTwo, applicantThree, applicantFour, applicantFive };

            string badAppName = ""; // неудовлетворительные оценки

            float GPA = 0; //наивысший средний балл
            string GoodAppName = "";

            string perfectAppName = "";
            float perfectGPA = 0; //самый высокий средний балл

            foreach (var app in apps)
            {               
                GPA = 0;
                foreach (int ass in app.GetAssessments())
                {                  
                    GPA += ass; 
                    
                    if (ass <= 3)
                    {
                        if (!badAppName.Contains(app.GetName()))
                        {
                            badAppName += app.GetName() + " ";
                        }                    
                    }
                }

                if ((GPA / 10) > 3)
                {
                    GoodAppName += app.GetName() + " ";
                }

                if (GPA > perfectGPA)
                {
                    perfectGPA = GPA / 10;
                    perfectAppName = app.GetName();
                }
            }
         
            Console.WriteLine("Список абитуриентов, имеющих неудовлетворительные оценки: " + badAppName);
            Console.WriteLine("Cписок абитуриентов, средний балл у которых ВЫШЕ 3: " + GoodAppName);
            Console.WriteLine("Cписок абитуриентов, имеющих самый высокий средний балл: " + perfectAppName);

            applicantFive.PrintAllData();
        }
    }

    public class Applicant 
    {
        private string name;
        private string surname;
        private string patronymic;
        private string adress;
        private int[] assessments;

        public Applicant()
        {
            name = "";
            surname = "";
            patronymic = "";
            adress = "";
            assessments = new int[] { };
        }

        public Applicant(string sName, string sSurname, string sPatronymic, string sAdress, int[] sAssessments)
        {
            name = sName;
            surname = sSurname;
            patronymic = sPatronymic;
            adress = sAdress;
            assessments = sAssessments;
        }

        public void SetName(string givenName)
        {
            name = givenName;
        }
        public string GetName()
        {
            return name;
        }

        public void SetSurname(string givenSurname)
        {
            surname = givenSurname;
        }
        public string GetSurname()
        {
            return surname;
        }


        public void SetPatronymic(string givenpatronymic)
        {
            patronymic = givenpatronymic;
        }
        public string GetPatronymic()
        {
            return patronymic;
        }

        public void Setadress(string givenadress)
        {
            adress = givenadress;
        }
        public string Getadress()
        {
            return adress;
        }

        public void SetAssessments(int[] givenAssessments)
        {
            assessments = givenAssessments;
        }
        public int[] GetAssessments()
        {
            return assessments;
        }

        public void PrintAllData()
        {
            Console.WriteLine("Данные пользователи: ");
            Console.WriteLine("ФИО: " + name + " " + " " + surname + " " + patronymic);
            Console.WriteLine("Адресс: " + adress);
            Console.Write("Оценки: ");
            foreach (int i in assessments)
            {
                Console.Write(i + " ");
            }
        }
    }
}
