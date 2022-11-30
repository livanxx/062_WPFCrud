using _062_WPFCrud.DataAccess.Context;
using System.Collections.Generic;
using System.Linq;

namespace _062_WPFCrud.DataAccess.Repositories
{
    public class PersonRepository : RepositoryBase<person>
    {
        public List<person> GetPeopleAbove20YearsOld()
        {
            var query = _db.Set<person>().Where(m => m.Age > 20).ToList();
            return query;
        }


        public person GetPersonNamedAlejandro()
        {
            var query = _db.people.FirstOrDefault(person => person.Name == "Alejandro");
            return query;
        }
    }
}
