using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotnetAndGraphQL.Domain
{
    public class Contact
    {

        public Contact()
        { }
        public Contact(Guid contactId, string? email, string? telefone, Guid customerId)
        {
            ContactId = contactId;
            Email = email;
            Telefone = telefone;
            CustomerId = customerId;
        }

        [Key]
        public Guid ContactId {get;set;}

        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? Telefone { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }

    }
}
