using PetaPoco;

namespace Irbis.DataService
{
    public class OrderDataService
    {
        private Database _db;

        public OrderDataService(Database db)
        {
            _db = db;
        }
    }
}