
namespace Lab2
{
    public class Collections : ICollections
    {



        public IEnumerable<Employees> Employees => new List<Employees>()
        {
            new Employees("Grachov", "Artem", "Sergiyovich", 1, "EM1212", ".Net Developer" )
            {DateOfBirth = new DateTime(2003, 3, 12), HireDate = new DateTime(2023, 3, 21), Specialty =  "barista" },

            new Employees("Tkach", "Vladislav", "Anatoliyovich", 2, "AV3256", ".Net Developer")
            {DateOfBirth = new DateTime(2003, 12, 29), HireDate = new DateTime(2023, 3, 20), Specialty =  "manager"  },

            new Employees("Hunko", "Jaroslav", "Yuriyovich", 3, "AV9275", "lawyer")
            {DateOfBirth = new DateTime(2004, 1, 21), HireDate = new DateTime(2023, 1, 12), Specialty =  "lawyer"  },

            new Employees("Petruk", "Olga", "Sergiyivna", 4, "VL3256", "JavaScript Developer")
            {DateOfBirth = new DateTime(2003, 12, 31), HireDate = new DateTime(2023, 6, 2), Specialty =  "Java Developer"  },

            new Employees("Koshilka", "Jaroslav", "Victorovich", 5, "VL9043", "Java Developer")
            {DateOfBirth = new DateTime(2003, 8, 19), HireDate = new DateTime(2022, 12, 11), Specialty =  "JavaScript Developer"  },

            new Employees("Tsvigun", "Olexandr", "Olegovich", 6, "VL2552", ".Net Developer")
            {DateOfBirth = new DateTime(1998, 4, 30), HireDate = new DateTime(2022, 12, 11), Specialty =  "HR"  }
        };


        public IEnumerable<Employees> EmployeesWithoutEmployement => new List<Employees>()
        {
            new Employees("Buk", "Anatoliy", "Ivanovich", 7, "EM1752", ".Net Developer")
            {DateOfBirth = new DateTime(2002, 1, 27) },

            new Employees("Loshuk", "Irina", "Olexandrivna", 8, "AV9206", ".Net Developer")
            {DateOfBirth = new DateTime(2004, 10, 1)  },

             new Employees("Tsvigun", "Olexandr", "Olegovich", 6, "VL2552", ".Net Developer")
            {DateOfBirth = new DateTime(1998, 4, 30) }
        };

        public IEnumerable<Company> Companies => new List<Company>()
        {
            new Company("Monobank", 0),
            new Company("Squad", 1),
            new Company("Grib", 2),
        };

        public IEnumerable<Employement> Employements => new List<Employement>()
        {
            new Employement(Employees.ElementAt(0).EmployeeId, Companies.ElementAt(0).Id),
            new Employement(Employees.ElementAt(1).EmployeeId, Companies.ElementAt(0).Id),
            new Employement(Employees.ElementAt(2).EmployeeId, Companies.ElementAt(1).Id),
            new Employement(Employees.ElementAt(3).EmployeeId, Companies.ElementAt(2).Id),
            new Employement(Employees.ElementAt(4).EmployeeId, Companies.ElementAt(2).Id),
            new Employement(Employees.ElementAt(5).EmployeeId, Companies.ElementAt(2).Id),
        };

        public IEnumerable<Salary> Salary => new List<Salary>()
        {
            new Salary(Employees.ElementAt(0).EmployeeId),
            new Salary(Employees.ElementAt(1).EmployeeId),
            new Salary(Employees.ElementAt(2).EmployeeId),
            new Salary(Employees.ElementAt(3).EmployeeId),
            new Salary(Employees.ElementAt(4).EmployeeId),
            new Salary(Employees.ElementAt(5).EmployeeId),
        };

        

    }

}
