using Menager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menager.Dal
{
    public interface IRepository
    {
        void AddPerson(Person person);  
        void UpdatePerson(Person person);   
        void DeletePerson(Person person);
        Person GetPerson(int idPerson);
        IList<Person> GetPeople();

    }
}
