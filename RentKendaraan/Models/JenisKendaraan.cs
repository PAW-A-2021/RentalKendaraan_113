using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentKendaraan.Models
{
    public partial class JenisKendaraan
    {
        public JenisKendaraan()
        {
            Kendaraan = new HashSet<Kendaraan>();
        }

        public int IdJenisKendaraan { get; set; }

        [Required(ErrorMessage = "Boleh diisi dengan mobil/motor")]
        public string NamaJenisKendaraan { get; set; }

        public ICollection<Kendaraan> Kendaraan { get; set; }
    }
}
