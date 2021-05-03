using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }
    }
}
