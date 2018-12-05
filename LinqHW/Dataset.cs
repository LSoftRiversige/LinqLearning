using System;
using System.Collections.Generic;

namespace LinqHW
{
    public static class Dataset
    {
        private static Dictionary<string, Language> _langs;

        public static Dictionary<string, Language> Langs
        {
            get
            {
                if (_langs == null)
                {
                    _langs = new Dictionary<string, Language>()
                    {
                        ["en"] = new Language(1, "English", "en"),
                        ["de"] = new Language(2, "German", "de"),
                        ["es"] = new Language(3, "Spanish", "es"),
                        ["ru"] = new Language(4, "Russian", "ru"),
                        ["cn"] = new Language(5, "Chinese", "cn")
                    };
                }
                return _langs;
            }
        }

        private static Dictionary<string, Country> _countries;
        public static Dictionary<string, Country> Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new Dictionary<string, Country>()
                    {
                        ["uk"] = new Country(1, "United Kingdon", "uk", 66020000, Langs["en"], 60778M),
                        ["us"] = new Country(2, "United States", "us", 325000000, Langs["en"], 81400M),
                        ["de"] = new Country(3, "Germany", "de", 82000000, Langs["de"], 30652M),
                        ["sw"] = new Country(4, "Switzerland", "sw", 8420000, Langs["de"], 36378M),
                        ["es"] = new Country(5, "Spain", "es", 46000000, Langs["es"], 23129M),
                        ["ar"] = new Country(6, "Argentina", "ar", 40000000, Langs["es"], 10368M),
                        ["mx"] = new Country(7, "Mexico", "mx", 112000000, Langs["es"], 10116M),
                        ["co"] = new Country(8, "Columbia", "co", 49000000, Langs["es"], 8304M)
                    };
                }
                return _countries;
            }

        }

        private static Dictionary<string, City> _cities;
        public static Dictionary<string, City> Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new Dictionary<string, City>()
                    {
                        ["lo"] = new City(1, "London", 8136000, Countries["uk"]),
                        ["ca"] = new City(2, "Cardiff", 335140, Countries["uk"]),
                        ["ma"] = new City(3, "Manchester", 510700, Countries["uk"]),
                        ["ny"] = new City(4, "New Yourk", 8623000, Countries["us"]),
                        ["la"] = new City(5, "Los Angeles", 4000000, Countries["us"]),
                        ["se"] = new City(6, "Seatle", 724700, Countries["us"]),
                        ["be"] = new City(7, "Berlin", 3570000, Countries["de"]),
                        ["ha"] = new City(8, "Hamburg", 1810000, Countries["de"]),
                        ["du"] = new City(9, "Dusseldorf", 770000, Countries["de"]),
                        ["mu"] = new City(10, "Munich", 612000, Countries["de"]),
                        ["zu"] = new City(11, "Zurich", 402000, Countries["sw"]),
                        ["ba"] = new City(12, "Basel", 171000, Countries["sw"]),
                        ["br"] = new City(13, "Barcelona", 1610000, Countries["es"]),
                        ["md"] = new City(14, "Madrid", 3160000, Countries["es"]),
                        ["co"] = new City(15, "Cordoba", 326000, Countries["es"]),
                        ["bu"] = new City(16, "BuenosAires", 2890000, Countries["ar"]),
                        ["mx"] = new City(17, "MexicoCity", 8850000, Countries["mx"])
                    };
                }
                return _cities;
            }
        }
        public static Person[] People
        {
            get => new Person[]
{
            new Person()
            {
                Id =1,
                Name = "Harry",
                SurName = "Smith",
                Age = 25,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Single,
                Languages = new Language[]{ Langs["en"], Langs["cn"] },
                EducationLevel = EducationLevel.Bachelor,
                OccupationType = OccupationType.SelfEmployed,
                Occupation = "Interpreter",
                AnnualIncome = 60000M,
                HomeAddress = new Address(1,"1 Downing st",Cities["lo"])
            },
            new Person()
            {
                Id =2,
                Name = "Jack",
                SurName = "Green",
                Age = 36,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Married,
                Languages = new Language[]{ Langs["en"], Langs["es"] },
                EducationLevel = EducationLevel.HighSchool,
                OccupationType = OccupationType.SelfEmployed,
                Occupation = "Businessman",
                AnnualIncome = 120000M,
                HomeAddress = new Address(2,"1 Main st",Cities["lo"])
            },
            new Person()
            {
                Id =3,
                Name = "Hernando",
                SurName = "De Soto",
                Age = 41,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Divorced,
                Languages = new Language[]{ Langs["es"], Langs["en"],Langs["ru"] },
                EducationLevel = EducationLevel.Master,
                OccupationType = OccupationType.Employee,
                Occupation = "Software Developer",
                AnnualIncome = 26000M,
                HomeAddress = new Address(3,"1 Galicia st",Cities["md"])
            },
            new Person()
            {
                Id =4,
                Name = "Juan",
                SurName = "Carlos",
                Age = 21,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Unknown,
                Languages = new Language[]{ Langs["es"], Langs["de"] },
                EducationLevel = EducationLevel.Bachelor,
                OccupationType = OccupationType.Employee,
                Occupation = "Financial analyst",
                AnnualIncome = 28000M,
                HomeAddress = new Address(4,"1 Domingo st",Cities["ba"])
            },
            new Person()
            {
                Id =5,
                Name = "Roy",
                SurName = "Smirnoff",
                Age = 27,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Single,
                Languages = new Language[]{ Langs["en"], Langs["ru"] },
                EducationLevel = EducationLevel.Master,
                OccupationType = OccupationType.Employee,
                Occupation = "Marketing Manager",
                AnnualIncome = 86000M,
                HomeAddress = new Address(5,"1 Beach st",Cities["la"])
            },
            new Person()
            {
                Id =6,
                Name = "Samantha",
                SurName = "Seagul",
                Age = 25,
                Gender = Gender.Woman,
                FamilyStatus = FamilyStatus.Single,
                Languages = new Language[]{ Langs["en"], Langs["cn"], Langs["ru"] },
                EducationLevel = EducationLevel.HECert,
                OccupationType = OccupationType.Employee,
                Occupation = "Travel Agent",
                AnnualIncome = 78000M,
                HomeAddress = new Address(6,"13 Mount st",Cities["se"])
            },
            new Person()
            {
                Id =7,
                Name = "Lisa",
                SurName = "Goldstein",
                Age = 18,
                Gender = Gender.Woman,
                FamilyStatus = FamilyStatus.Single,
                Languages = new Language[]{ Langs["de"] },
                EducationLevel = EducationLevel.HighSchool,
                OccupationType = OccupationType.Trainee,
                Occupation = "Student",
                AnnualIncome = 10000M,
                HomeAddress = new Address(7,"1 Gross st",Cities["be"])
            },
            new Person()
            {
                Id =8,
                Name = "Sasha",
                SurName = "Huenberger",
                Age = 22,
                Gender = Gender.Woman,
                FamilyStatus = FamilyStatus.Single,
                Languages = new Language[]{ Langs["de"], Langs["ru"] },
                EducationLevel = EducationLevel.Master,
                OccupationType = OccupationType.Trainee,
                Occupation = "PhD Student",
                AnnualIncome = 30000M,
                HomeAddress = new Address(8,"1 University st",Cities["ha"])
            },
            new Person()
            {
                Id =9,
                Name = "Hertruda",
                SurName = "Schaft",
                Age = 20,
                Gender = Gender.Woman,
                FamilyStatus = FamilyStatus.Single,
                Languages = new Language[]{ Langs["en"], Langs["de"] },
                EducationLevel = EducationLevel.HECert,
                OccupationType = OccupationType.Employee,
                Occupation = "Sales manager",
                AnnualIncome = 43000M,
                HomeAddress = new Address(9,"1 Ubon st",Cities["mu"])
            },
            new Person()
            {
                Id =10,
                Name = "Tomas",
                SurName = "Bernstein",
                Age = 45,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Married,
                Languages = new Language[]{ Langs["en"], Langs["de"],Langs["cn"],Langs["ru"] },
                EducationLevel = EducationLevel.PhD,
                OccupationType = OccupationType.Employee,
                Occupation = "CEO",
                AnnualIncome = 116000M,
                HomeAddress = new Address(10,"1 Gelden st",Cities["zu"])
            },
            new Person()
            {
                Id =11,
                Name = "Maria",
                SurName = "de Blanca",
                Age = 61,
                Gender = Gender.Woman,
                FamilyStatus = FamilyStatus.Divorced,
                Languages = new Language[]{ Langs["es"]},
                EducationLevel = EducationLevel.Bachelor,
                OccupationType = OccupationType.Retired,
                Occupation = "Retired",
                AnnualIncome = 14000M,
                HomeAddress = new Address(11,"1 Marpais st",Cities["co"])
            },

            new Person()
            {
                Id =12,
                Name = "Rodrigo",
                SurName = "Sanches",
                Age = 70,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Married,
                Languages = new Language[]{ Langs["en"], Langs["es"] },
                EducationLevel = EducationLevel.Master,
                OccupationType = OccupationType.Retired,
                Occupation = "Retired",
                AnnualIncome = 17000M,
                HomeAddress = new Address(12,"1 Verde st",Cities["md"])
            },

            new Person()
            {
                Id =13,
                Name = "Vladimir",
                SurName = "Kurilov",
                Age = 34,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Single,
                Languages = new Language[]{ Langs["ru"], Langs["en"] },
                EducationLevel = EducationLevel.HighSchool,
                OccupationType = OccupationType.Unknown,
                Occupation = null,
                //AnnualIncome = 6500M,
                AnnualIncome = 60000,
                HomeAddress = new Address(13,"1 Gauchos st",Cities["bu"])
            },
              new Person()
            {
                Id =14,
                Name = "Elizabeth",
                SurName = "Doe",
                Age = 28,
                Gender = Gender.Woman,
                FamilyStatus = FamilyStatus.Married,
                Languages = new Language[]{ Langs["en"] },
                EducationLevel = EducationLevel.Master,
                OccupationType = OccupationType.Employee,
                Occupation = "Risk manager",
                AnnualIncome = 73000M,
                HomeAddress = new Address(14,"1 Highland st",Cities["ma"])
            },
             new Person()
            {
                Id =15,
                Name = "Valdis",
                SurName = "Birkavskis",
                Age = 46,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Married,
                Languages = new Language[]{ Langs["en"], Langs["de"],Langs["ru"] },
                EducationLevel = EducationLevel.Master,
                OccupationType = OccupationType.Employee,
                Occupation = "Civil engineer",
                AnnualIncome = 51000M,
                HomeAddress = new Address(15,"1 Workres st",Cities["du"])
            },
               new Person()
            {
                Id =16,
                Name = "Carlos",
                SurName = "Slim",
                Age = 61,
                Gender = Gender.Man,
                FamilyStatus = FamilyStatus.Married,
                Languages = new Language[]{ Langs["en"], Langs["es"] },
                EducationLevel = EducationLevel.Bachelor,
                OccupationType = OccupationType.SelfEmployed,
                Occupation = "Businessman",
                AnnualIncome = 4651000M,
                HomeAddress = new Address(16,"1 Rico st",Cities["du"])
            }
};
        }
    }

    public enum Gender
    {
        Unknown,
        Man,
        Woman
    }
    public enum FamilyStatus
    {
        Unknown,
        Single,
        Married,
        Divorced
    }
    public enum OccupationType
    {
        Unknown,
        Employee,
        SelfEmployed,
        Trainee,
        Retired
    }
    public enum EducationLevel
    {
        SecondarySchool,
        HighSchool,
        HECert,
        Bachelor,
        Master,
        PhD
    }
    public interface IAbbreviatable
    {
        string Code { get; set; }
    }
    public interface INamable
    {
        string Name { get; set; }

    }
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
    public interface IFullyIdentifable : IIdentifiable, INamable, IAbbreviatable
    {

    }
    public interface IPopulatable
    {
        int Population { get; set; }
    }
    public class Person : IIdentifiable, INamable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public FamilyStatus FamilyStatus { get; set; }
        public Address HomeAddress { get; set; }
        public Language[] Languages { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public OccupationType OccupationType { get; set; }
        public string Occupation { get; set; }
        public decimal AnnualIncome { get; set; }
    }
    public class Address : IIdentifiable
    {
        public Address(int id, string adddreLine, City city)
        {
            Id = id;
            AddressLine1 = adddreLine;
            City = city;
        }
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public City City { get; set; }
    }
    public class City : IIdentifiable, INamable, IPopulatable
    {
        public City(int id, string name, int pop, Country country)
        {
            Id = id;
            Name = name;
            Population = pop;
            Country = country;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public Country Country { get; set; }
    }
    public class Country : IFullyIdentifable, IPopulatable
    {
        public Country(int id, string name, string code, int pop, Language language, decimal avgIncome)
        {
            Id = id;
            Name = name;
            Code = code;
            Population = pop;
            Language = language;
            AvgIncome = avgIncome;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Population { get; set; }
        public Language Language { get; set; }
        public decimal AvgIncome { get; set; }
    }
    public class Language : IFullyIdentifable
    {
        public Language(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}