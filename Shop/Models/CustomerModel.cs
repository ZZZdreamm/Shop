using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Adress { get; set; }

        public string CardNumber { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
    }
}
