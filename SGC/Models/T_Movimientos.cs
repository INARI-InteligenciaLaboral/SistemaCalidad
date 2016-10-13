namespace SGC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Asistencia.T_Movimientos")]
    public partial class T_Movimientos
    {
        [Key]
        public long ID_Movimiento { get; set; }

        [StringLength(50)]
        public string NombreDoc { get; set; }

        [StringLength(4)]
        public string Codificacion { get; set; }

        [StringLength(2)]
        public string CodAdicional { get; set; }

        public int? NoRevision { get; set; }

        public int? ID_StatusDoc { get; set; }

        public int? ID_TipoDoc { get; set; }

        public int? ID_Area { get; set; }

        public int? ID_Depart { get; set; }

        public string Descripcion { get; set; }

        public DateTime? Fecha_Alta { get; set; }

        [StringLength(1)]
        public string LinkWeb { get; set; }

        [StringLength(1)]
        public string Ruta_Archivo { get; set; }

        public DateTime FechaMov { get; set; }

        [StringLength(17)]
        public string CodificacionCalc { get; set; }
    }
}
