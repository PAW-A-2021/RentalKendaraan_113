using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentKendaraan.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Customer = new HashSet<Customer>();
        }

        public int IdGender { get; set; }

        [Required(ErrorMessage = "Diisi dengan L/P")]
        public string NamaGender { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
