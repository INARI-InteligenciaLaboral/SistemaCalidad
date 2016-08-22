namespace SGC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Archivos.T_Documentos")]
    public partial class T_Documentos
    {
        [Key]
        public long ID_Doc { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(4)]
        public string Codificacion { get; set; }

        [StringLength(2)]
        public string CodAdicional { get; set; }

        public int NoRevision { get; set; }

        public int ID_Status { get; set; }

        public int ID_TipoDoc { get; set; }

        public int ID_Area { get; set; }

        public int ID_Depart { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha_Alta { get; set; }

        [StringLength(1)]
        public string LinkWeb { get; set; }

        [Required]
        [StringLength(1)]
        public string Ruta_Archivo { get; set; }

        [StringLength(17)]
        public string CodificacionCalc { get; set; }

        public virtual T_Area T_Area { get; set; }

        public virtual T_Departamento T_Departamento { get; set; }
    }
}
