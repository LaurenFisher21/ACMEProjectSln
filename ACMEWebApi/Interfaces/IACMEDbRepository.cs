﻿using Shared.Models;

namespace ACMEWebApi.Interfaces
{
    public interface IACMEDbRepository
    {
        public Person CreateNewPerson(Person person);
        public bool DoesPersonExistById(int Id);
        public Person GetPersonById(int Id);
        public Person GetPersonByLastName(string lastname);
        public List<Person> GetAllPeople();
    }
}
