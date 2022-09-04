using ACMEWebApi.Interfaces;
using Shared.Models;

namespace ACMEWebApi.Data
{
    public class ACMEDbRepository : IACMEDbRepository
    {
        private DataContext _dataContext;

        public ACMEDbRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Person
        //Person Controller.
        public Person CreateNewPerson(Person person)
        {
            _dataContext.People.Add(person);
            _dataContext.SaveChanges();

            return person;
        }

        public Person UpdatePerson(Person person)
        {
            _dataContext.Update(person);
            _dataContext.SaveChanges();
            return person;
        }

        public Person DeletePerson(Person person)
        {
            _dataContext.Remove(person);
            _dataContext.SaveChanges();
            return null;
        }

        public Person GetPersonById(int Id)
        {
            var person = _dataContext.People.Where(x => x.PersonId == Id).FirstOrDefault();
            return person;
        }

        public Person FindPersonById(int Id)
        {
            var person = _dataContext.People.Find(Id);
            return person;
        }

        public Person GetPersonByLastName(string lastname)
        {
            var person = _dataContext.People.Where(x => x.LastName.Contains(lastname)).FirstOrDefault();
            return person;
        }

        public List<Person> GetAllPeople()
        {
            var person = _dataContext.People.ToList();
            return person;
        }

        public bool DoesPersonExistById(int Id)
        {
            return _dataContext.People.Any(x => x.PersonId == Id);
        }
        #endregion


        #region Employee
        //Employee Controller.
        public Employee CreateNewEmployee(Employee employee)
        {
            _dataContext.Employees.Add(employee);
            _dataContext.SaveChanges();

            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _dataContext.Update(employee);
            _dataContext.SaveChanges();

            return employee;
        }

        public Employee DeleteEmployee(Employee employee)
        {
            _dataContext.Remove(employee);
            _dataContext.SaveChanges();

            return null;
        }

        public bool DoesEmployeeExistById(int Id)
        {
            return _dataContext.Employees.Any(x => x.EmployeeId == Id);
        }

        public Employee GetEmployeeById(int Id)
        {
            var employee = _dataContext.Employees.Where(x => x.EmployeeId == Id).FirstOrDefault();
            return employee;
        }

        public Employee GetEmployeeByEmpNum(string empNum)
        {
            var employee = _dataContext.Employees.Where(x => x.EmployeeNum == empNum).FirstOrDefault();
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return _dataContext.Employees.ToList();
        }
        #endregion
    }
}
