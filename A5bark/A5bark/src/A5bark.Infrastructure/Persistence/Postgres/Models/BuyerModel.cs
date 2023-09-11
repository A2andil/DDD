using A5bark.Infrastructure.Persistence.Types;
using System;

namespace A5bark.Infrastructure.Persistence.Postgres.Models
{
    public class BuyerModel : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressModel Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
