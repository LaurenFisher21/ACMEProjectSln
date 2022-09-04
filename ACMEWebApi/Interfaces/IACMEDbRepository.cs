using Shared.Models;

namespace ACMEWebApi.Interfaces
{
    public interface IACMEDbRepository
    {
        // Person Model and Controller.
        public Person CreateNewPerson(Person person);
        public Person UpdatePerson(Person person);
        public Person DeletePerson(Person person);
        public bool DoesPersonExistById(int Id);
        public Person GetPersonById(int Id);
        public Person FindPersonById(int Id);
        public Person GetPersonByLastName(string lastname);
        public List<Person> GetAllPeople();


        // Employee Model and Controller.
        public Employee CreateNewEmployee(Employee employee);
        public Employee UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(Employee employee);
        public bool DoesEmployeeExistById(int Id);
        public Employee GetEmployeeById(int Id);
        public Employee GetEmployeeByEmpNum(string empNum);
        public List<Employee> GetAllEmployees();
    }
}
