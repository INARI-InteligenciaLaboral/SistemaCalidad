namespace SGC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interfaz.T_Interfaz")]
    public partial class T_Interfaz
    {
        [Key]
        public int ID_Interfaz { get; set; }

        [Required]
        [StringLength(1)]
        public string RutaBackground { get; set; }

        [Required]
        [StringLength(1)]
        public string LogoInari { get; set; }

        [Required]
        [StringLength(1)]
        public string LogoCalidad { get; set; }

        [Required]
        [StringLength(6)]
        public string title { get; set; }

        [Required]
        [StringLength(6)]
        public string Navegacion { get; set; }

        [Required]
        [StringLength(6)]
        public string NavHover { get; set; }

        [Required]
        [StringLength(6)]
        public string NavFont { get; set; }

        [Required]
        [StringLength(6)]
        public string NavFontHover { get; set; }

        [Required]
        [StringLength(6)]
        public string Piramide { get; set; }

        [Required]
        [StringLength(6)]
        public string PirFont { get; set; }

        [Required]
        [StringLength(6)]
        public string PirHover { get; set; }

        [Required]
        [StringLength(6)]
        public string PirFontHover { get; set; }
    }
}
