using FormulaApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Test.Fixtures
{
    public class FansFixtures
    {
        public static List<Fan> GetFans() => new() //Expression-bodied Methods
        {
            new Fan()
            {
                Email = "gastoncisneros@gmail.com",
                Id = 1,
                Name = "Gaston",
            },
            new Fan()
            {
                Email = "testing@gmail.com",
                Id = 2,
                Name = "Test",
            }
        };

        public static List<Fan> GetEmptyFans() => new() { };
    }
}
