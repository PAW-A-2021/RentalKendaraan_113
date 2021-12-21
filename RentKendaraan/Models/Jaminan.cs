using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentKendaraan.Models
{
    public partial class Jaminan
    {
        public Jaminan()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int IdJaminan { get; set; }

        [Required(ErrorMessage = "Bisa Diisi dengan Fotokopi KTP/SIM")]
        public string NamaJaminan { get; set; }

        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
