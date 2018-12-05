using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LinqHW
{
    public static class Options
    {
        public static string ToMoney(this decimal d)
        {
            return String.Format(new CultureInfo("EN-us"), "{0:C}", d);
        }

        public static int Product(this IEnumerable<int> coll)
        {
            return coll.Aggregate((prev1, curr) => prev1 + curr);
        }

        //равенство коллекций  независимо от порядка 
        public static bool Are<T>(this IEnumerable<T> coll1, IEnumerable<T> coll2)
        {
            return !(coll1.Except(coll2).Any() || coll2.Except(coll1).Any());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var people = Dataset.People;

            int[] a1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            //int sum = a1.Aggregate((prev1, curr) => prev1 + curr);
            int sum = a1.Product();

            string[] strs = new string[] { "as", "asas", "asfafgsadgf"};
            string concat = strs.Aggregate((p, c) => $"{c}---{p}");

            //object[] objs = new object[] { true, false, true};
            //var casted = objs.Cast<object>.ToArray();


            //Console.WriteLine($"{concat}");

            bool greatThenAny = a1.Any(x => x > 10); //проверка что есть элемент коллекции удовлетворяют условию
            bool greatAll = a1.All(x => x > 10); //проверка что все элементы коллекции удовлетворяют условию

            bool isNotEmpty = a1.Any();
            bool isNotEmpty1 = a1.Count() > 0;

            //var allLangs = people.SelectMany(p => p.Languages).ToArray();
            var allLangs = people.Select(p => p.Languages).Distinct().ToArray();

            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 2, 3, 4, 7, 8 };
            bool equal = arr1.SequenceEqual(arr2); //важен порядок элементов


            var inter = arr1.Intersect(arr2); //общие элементы

            var exclude = arr1.Except(arr2);//исключить общие элементы

            var eq = arr1.Are(arr2); // обе коллекции равны независимо от порядка следования элементов

            int[] arr7 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            var taken = arr7.Take(3);
            var taken1 = arr7.Skip(2).Take(3);
            var takenWhile = arr7.TakeWhile(x => x < 50);
            var skipWhile = arr7.SkipWhile(x => x < 50).TakeWhile(x=>x>70);

            var someone = people.Select(p => new { FirstName = p.Name, PeopAge = p.Age });

            var anonym = new { Make ="Honda", Year=2012}; //анонимный класс

            string[] langs = new string[] { "en", "de", "ua", "it"};
            var dtlangs = Dataset.Langs.ToArray();

            //inner join
            var q7=
            from dl in dtlangs
            join l in langs on dl.Key equals l
            select l;

            //left  join
            var queryLeft =
                from dl in dtlangs
                join l in langs on dl.Key equals l
                into left
                select left.DefaultIfEmpty().ToArray();

            //отложенное выполнение
            var old = people.Select(p => { p.Age = ChangeAge(); return p; });
            var arrOld = old.ToArray();

            old.ToList().ForEach(p=>p.Age=75); // только для списка

            //запрос выполняется на ToList, ToArray, Count, foreach


            Console.WriteLine("Press any key...");
            //Console.ReadKey();

            //1) Получить число мужчин в коллекции; число женщин
            int menCount = people.Count(p => p.Gender == Gender.Man);
            int womenCount = people.Count(p => p.Gender == Gender.Woman);
            Console.WriteLine($"Men count={menCount}; Women count={womenCount}");

            //2) Отсортировать персонажей по фамилии потом по имени, выбрать их описание в формате $"{Name} {SurName}, age {Age} lives in {City}, {Country}. 
            //He (или she, решить тернарным опертором) is {Occupation} and makes {AnnualIncome} a year. {Family status to string}, speaks {Languages Count} languages
            
            var query1 = people.OrderBy(p => p.SurName).OrderBy(p => p.Name).Select(p => (
                p.Name, 
                p.SurName, 
                p.Age, 
                p.Gender, 
                p.Occupation, 
                p.HomeAddress.City, 
                p.HomeAddress.City.Country.Name, 
                p.AnnualIncome, 
                p.FamilyStatus, 
                p.Languages

                ));

            
            Console.WriteLine();
            foreach (var (Name, SurName, Age, Gender, Occupation, City, CountryName, AnnualIncome, FamilyStatus, Languages) in query1)
            {
                Console.WriteLine($"{Name} {SurName}, age {Age} lives in {City}, {CountryName}");
                string s = $"{(Gender == Gender.Man ? "He" : "She")} is {Occupation} and makes {AnnualIncome.ToMoney()} a year. " +
                    $"{FamilyStatus}, speaks {Languages.Length} languages: {String.Join(", ", Languages.Select(l => l.Name))}";

                Console.WriteLine(s);
            }

            //Найти тех, кто живет в странах с  населением больше 80 миллионов
            var q80mlnMore = people.Where(p => p.HomeAddress.City.Country.Population > 80 * 1000000).Select(p=>(p.Name, p.SurName));

            Console.WriteLine();
            Console.WriteLine($"Найти тех, кто живет в странах с  населением больше 80 миллионов:");

            foreach (var (Name, SurName) in q80mlnMore)
            {
                Console.WriteLine($"{Name} {SurName}");
            }

            //Найти средний доход в группе персонажей(return decimal Average()) с высшим образованием(выше HECert - аналого нашего двухгодичного "младшего специалиста")
            decimal avrAnnualIncome=people.Where(p => p.EducationLevel >= EducationLevel.HECert).Average(p => p.AnnualIncome);

            Console.WriteLine();
            Console.WriteLine("Средний доход людей с высшим образованием:");
            Console.WriteLine($"{avrAnnualIncome.ToMoney()}");


            //Найти тех, чей годовой доход превышает годовой доход в их стране
            var q1 = people.Where(p => p.AnnualIncome > p.HomeAddress.City.Country.AvgIncome).Select(p => (p.Name, p.SurName));

            Console.WriteLine();
            Console.WriteLine("Найти тех, чей годовой доход превышает годовой доход в их стране");

            foreach (var (Name, SurName) in q1)
            {
                Console.WriteLine($"{Name} {SurName}");
            }

            //Найти максимальное число языков, которым владеет персонаж(return int Max()
            Console.WriteLine("Найти максимальное число языков, которым владеет персонаж");
            Console.WriteLine($"{people.Max(p => p.Languages.Length)}");

            //Найти виртуозного полиглота(для которого число языков равняется числу из п.6)
            Console.WriteLine();
            var polyglotPerson = people.First(p => p.Languages.Length == people.Max(polyglot => polyglot.Languages.Length));
            Console.WriteLine("Найти виртуозного полиглота(для которого число языков равняется числу из п.6");
            Console.WriteLine($"{polyglotPerson.Name} {polyglotPerson.SurName}");

            //8) Найти персонажа, который не владеет языком страны, в которой он проживает.Если такого нет - вернуть null
            //Person person = people.First(p=> !p.Languages.Contains(p.HomeAddress.City.Country.Language.Name))
            var mrx = people.FirstOrDefault(p => !p.Languages.Select(l => l.Id).Contains(p.HomeAddress.City.Country.Language.Id));

            Console.WriteLine($"{mrx.Name}");
            

            //9) Найти людей, проживающих в Германии, упорядочить по возрасту от большего до меньшего, выбрать в формате $"{Name} {Surname} {Age} {City}"
            var q2 = from p in people where p.HomeAddress.City.Country.Code == "de" orderby p.Age descending select (p.Name, p.SurName, p.Age, p.HomeAddress.City.Name);
            Console.WriteLine("");
            Console.WriteLine("Найти людей, проживающих в Германии, упорядочить по возрасту от большего до меньшего");
            foreach (var (Name, SurName, Age, CityName) in q2)
            {
                Console.WriteLine($"{Name} {SurName} {Age} {CityName}");
            }


            Console.WriteLine();
            //10)Найти процентную долю тех, кто состоит в браке от общего числа персонажей
            int totalPersonCount = people.Count();
            //можно ли найти количество через другую форму запроса?     
            int married = people.Where(p=>p.FamilyStatus == FamilyStatus.Married).Count();
            //int married = (from p in people where p.FamilyStatus == FamilyStatus.Married).Count();
            Console.WriteLine($"В браке состоит {Math.Round((double)married / totalPersonCount * 100, 1)}% людей");


            int[] arr = { 1, 2, 3, 4, 5, 6, 7,8 ,9 ,0 };

            //11) Найти тех, кто владеет двумя и более языками но получает зарплату ниже средней по их стране
            var q3 = from p in people where (p.Languages.Length >= 2 && p.AnnualIncome < p.HomeAddress.City.Country.AvgIncome) select (p.Name, p.SurName);

            Console.WriteLine("");
            Console.WriteLine("Найти тех, кто владеет двумя и более языками но получает зарплату ниже средней по их стране");

            foreach (var (Name, SurName) in q3)
            {
                Console.WriteLine($"{Name}, {SurName}");
            }

            //12) Найти единственного кандидата наук, если такого нет либо если выборка больше 1 - вернуть ошибку
            var qDoctor = people.FirstOrDefault(p => p.EducationLevel == EducationLevel.PhD);
            Console.WriteLine($"12) Найти единственного кандидата наук, если такого нет либо если выборка больше 1 - вернуть ошибку");
            Console.WriteLine($"{qDoctor.Name} {qDoctor.SurName}");


            //13) Найти людей из испаноговорящих стран, вернуть в формате $"{Name} {Occupation} {City} {Country}"
            Console.WriteLine($"13) Найти людей из испаноговорящих стран");
            foreach (var p in people.Where(p=>p.HomeAddress.City.Country.Language.Name==Dataset.Langs["es"].Name).Select(p=> new { FirstName=p.Name, p.SurName, p.Occupation, Country=p.HomeAddress.City.Country.Name, City=p.HomeAddress.City.Name }))
            {
                Console.WriteLine($"{p.FirstName} {p.Occupation} {p.City} {p.Country}");
            }

            //14) Найти персонажа, который живет в городе с наименьшим населением(относительно места проживания других персонажей)
            var pLittleTown = people.First(p=>p.HomeAddress.City.Population <= people.Min(pm => pm.HomeAddress.City.Population));

            Console.WriteLine($"Найти персонажа, который живет в городе с наименьшим населением");
            Console.WriteLine($"{pLittleTown.Name} {pLittleTown.SurName} {people.Min(pm => pm.HomeAddress.City.Population)}");

            //15) Найти персонажа, который живет в городе с наименьшим абсолютным населением(город с наименьшим населением в списке городов), если такого нет - вернуть налл
            Console.WriteLine($"Найти персонажа, который живет в городе с наименьшим абсолютным населением");
            var pAbsoluteMin = people.FirstOrDefault(p => p.HomeAddress.City.Population == Dataset.Cities.Min(pmin => pmin.Value.Population));
            Console.WriteLine($"{pAbsoluteMin?.Name} {pAbsoluteMin?.SurName}");

            //Console.WriteLine($"{Dataset.Cities.Min(p => p.Value.Population)}");


            //17) Определить, какая доля людей, владеющих английским, проживает не в англоговорящих странах по отношению ко всем людям из списка, 
            //которые владеют английским
            var countEngLivedInNotEngCountres = people.Count(p => p.Languages.Contains(Dataset.Langs["en"]) && p.HomeAddress.City.Country.Language.Name != Dataset.Langs["en"].Name);
            var countTotalEng = people.Count(t => t.Languages.Contains(Dataset.Langs["en"]));
            var percent = (double)countEngLivedInNotEngCountres / countTotalEng * 100;
                    
            Console.WriteLine($"Определить, какая доля людей, владеющих английским, " +
                $"проживает не в англоговорящих странах по отношению ко всем " +
                $"людям из списка, которые владеют английским");

            Console.WriteLine($"{string.Format("{0:f}", percent)}%");

            var richest = people.First(p => p.AnnualIncome == people.Max(pmax => pmax.AnnualIncome));

            //18) Найти самого богатого персонажа
            Console.WriteLine("Найти самого богатого персонажа");
            Console.WriteLine($"{richest.Name} {richest.SurName}");

            //19) Найти персонажа с наименьшим доходом в Британии
            var minAnnualIncome = 
                people.First(p=>
                    p.AnnualIncome == people.Where(m=>m.HomeAddress.City.Country == Dataset.Countries["uk"]).Min(min=>min.AnnualIncome)
                    && p.HomeAddress.City.Country == Dataset.Countries["uk"]
                );

            

            Console.WriteLine($"Найти персонажа с наименьшим доходом в Британии");
            Console.WriteLine($"{minAnnualIncome.Name} {minAnnualIncome.SurName} {minAnnualIncome.AnnualIncome} {minAnnualIncome.HomeAddress.City.Country.Name}");


            //20) Отсортировать персонажей по доходу по нисходящей, потом по имени и по фамилии по восходящей
            Console.WriteLine($"Отсортировать персонажей по доходу по нисходящей, потом по имени и по фамилии по восходящей");
            //foreach (var person in people.OrderByDescending(p=>p.AnnualIncome).OrderBy(p=>p.Name).OrderBy(p => p.SurName))
            foreach (var person in people.OrderBy(p => p.SurName).OrderBy(p => p.Name).OrderByDescending(p => p.AnnualIncome))
            {
                Console.WriteLine($"{person.AnnualIncome} {person.Name} {person.SurName}");
            }


            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static int ChangeAge()
        {
            return 60;
        }
    }
}
