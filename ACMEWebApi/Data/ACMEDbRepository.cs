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
    }
}
