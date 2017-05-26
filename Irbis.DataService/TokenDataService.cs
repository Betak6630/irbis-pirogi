using System;
using Irbis.Entities;
using PetaPoco;

namespace Irbis.DataService
{
    public class TokenDataService
    {
        private Database _db;
        public TokenDataService(Database db)
        {
            _db = db;
        }

        public string CreateToken(int userId)
        {
            var token = new Token()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CreatedAt = DateTime.Now
            };

            _db.Insert("Token", "Id", token);

            return token.Id.ToString();
        }

        public bool IsExistsToken(int userId)
        {
            var sqlQuery = $"select count(*) from Token where userId={userId}'";
            var result = _db.ExecuteScalar<int>(sqlQuery);

            return result==1;
        }
    }
}