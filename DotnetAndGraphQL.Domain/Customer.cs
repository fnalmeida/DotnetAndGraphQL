using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetAndGraphQL.Domain
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(Guid customerID, string firstName, DateTime birth, string document)
        {
            CustomerID = customerID;
            FirstName = firstName;
            Birth = birth;
            Document = document;
        }

        [Key]
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public DateTime Birth { get; set; }
        public string Document { get; set; }

        [UseSorting]
        public ICollection<Contact>? Contacts { get; set; }
    }
}
