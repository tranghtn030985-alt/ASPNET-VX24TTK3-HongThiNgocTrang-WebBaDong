using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace du_lich_bien_ba_dong.Models
{
    [Table("TinTuc")]
    public class TinTuc
    {
        [Key]
        public int TinTucId { get; set; }

        [Required]
        [StringLength(100)]
        public string TieuDe { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public int LuotXem { get; set; }

        [Required]
        public string HinhAnhUrl { get; set; }
        [Required]
        [StringLength(500)]
        public string TomTat { get; set; }

        [Required]
        [StringLength(1000)]
        public string BanTin { get; set; }
    }
}