namespace SGC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interfaz.T_Comunicados")]
    public partial class T_Comunicados
    {
        [Key]
        public long ID_Comunicado { get; set; }

        public DateTime Fecha_Alta { get; set; }

        public DateTime Fecha_Inicio { get; set; }

        public DateTime Fecha_Fin { get; set; }

        [Required]
        [StringLength(100)]
        public string Ruta_Imagen { get; set; }
    }
}
