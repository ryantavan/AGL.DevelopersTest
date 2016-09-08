using AGL.DevelopersTest.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.DevelopersTest.Models
{
    public class Person
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
