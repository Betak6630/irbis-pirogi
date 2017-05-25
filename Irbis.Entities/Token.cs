using System;

namespace Irbis.Entities
{
    public class Token
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}