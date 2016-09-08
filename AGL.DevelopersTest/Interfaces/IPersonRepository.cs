using AGL.DevelopersTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.DevelopersTest.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPeople();
    }
}
