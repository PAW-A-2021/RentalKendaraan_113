using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentKendaraan.Models
{
    public partial class Kendaraan
    {
        public Kendaraan()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int IdKendaraan { get; set; }

        [Required(ErrorMessage = "Nama Kendaraan tidak boleh kosong")]
        public string NamaKendaraan { get; set; }

        [Required(ErrorMessage = "Contoh AB 1482 YEA")]
        public string NoPolisi { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi dengan angka")]
        public string NoStnk { get; set; }


        public int? IdJenisKendaraan { get; set; }
        public string Ketersediaan { get; set; }

        public JenisKendaraan IdJenisKendaraanNavigation { get; set; }
        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
