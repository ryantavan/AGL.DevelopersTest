using AGL.DevelopersTest.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.DevelopersTest.Models
{

    public class Person
    {
        public string name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender gender { get; set; }
        public int age { get; set; }
        private IEnumerable<Pet> _pets;
        public IEnumerable<Pet> pets {
            get {
                return _pets;
            }
            set {
                _pets = value;
                if (_pets != null)
                {
                    _pets.ToList().ForEach(x => x.Owner = this);
                }

            }
        }
    }
}
