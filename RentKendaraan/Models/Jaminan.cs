using System;
using System.Collections.Generic;

namespace RentKendaraan.Models
{
    public partial class Jaminan
    {
        public Jaminan()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int IdJaminan { get; set; }
        public string NamaJaminan { get; set; }

        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
