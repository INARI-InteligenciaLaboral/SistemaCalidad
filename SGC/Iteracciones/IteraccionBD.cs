using SGC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGC.Iteracciones
{
    public class IteraccionBD
    {
        public static bool InsertComunicado(T_Comunicados t_comunicado)
        {
            using (SqlConnection mySqlConnection = new SqlConnection("Persist Security Info = False;"))
            {
                mySqlConnection.Open();
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText =
                  "INSERT INTO Interfaz.T_Comunicados VALUES ( @Fecha_Alta, @Fecha_Inicio, @Fecha_Fin,@Ruta_Imagen)";
                mySqlCommand.Parameters.Add("@Fecha_Alta", SqlDbType.DateTime);
                mySqlCommand.Parameters.Add("@Fecha_Inicio", SqlDbType.DateTime);
                mySqlCommand.Parameters.Add("@Fecha_Fin", SqlDbType.DateTime);
                mySqlCommand.Parameters.Add("@Ruta_Imagen", SqlDbType.NVarChar,100);
                mySqlCommand.Parameters["@Fecha_Alta"].Value = Convert.ToDateTime(DateTime.Now);
                mySqlCommand.Parameters["@Fecha_Inicio"].Value = Convert.ToDateTime(t_comunicado.Fecha_Inicio);
                mySqlCommand.Parameters["@Fecha_Fin"].Value = Convert.ToDateTime(t_comunicado.Fecha_Fin);
                mySqlCommand.Parameters["@Ruta_Imagen"].Value = t_comunicado.Ruta_Imagen.ToString();
                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();
            }
            return true;
        }
        public static bool UpdateArchivo(T_Documentos t_documentos)
        {
            using (SqlConnection mySqlConnection = new SqlConnection("Persist Security Info = False;"))
            {
                mySqlConnection.Open();
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText =
                  "Update [Archivos].[T_Documentos] SET Ruta_Archivo = @Ruta_Archivo WHERE ID_Doc = @ID";
                mySqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);
                mySqlCommand.Parameters.Add("@Ruta_Archivo", SqlDbType.NVarChar, 100);
                mySqlCommand.Parameters["@ID"].Value = t_documentos.ID_Doc;
                mySqlCommand.Parameters["@Ruta_Archivo"].Value = t_documentos.Ruta_Archivo.ToString();
                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();
            }
            return true;
        }
        public static DataTable ObtenerProcedimientos()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 3";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerDescPuesto()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Ruta_Archivo as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 7 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerRegyPoli()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 8 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerBoletin()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 9 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerObjTac()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 10 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerStatusHa()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 11 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerDocExtr()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.LinkWeb as Ruta,Doc.Ruta_Archivo as Rutas";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 12 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerManuales()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 13 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerOrganigrama()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 6 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerPoliObj()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Nombre as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 2 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerProc()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Ruta_Archivo as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 3 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerInst()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Ruta_Archivo as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 4 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerForReg()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Ruta_Archivo as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 5 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
        public static DataTable ObtenerManual()
        {
            string m_cadena = "Persist Security Info = False;";
            DataTable m_Procesos = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "Select Doc.Ruta_Archivo as Archivo,Doc.Ruta_Archivo as Ruta,Area.Nombre as Area,Dep.Nombre as Depart, TPD.Nombre AS TipoDoc";
                    m_command += " from Archivos.T_Documentos AS Doc INNER JOIN Asistencia.T_Area AS Area ON Doc.ID_Area = Area.ID_Area";
                    m_command += " INNER JOIN Asistencia.T_Departamento AS Dep ON Doc.ID_Depart = Dep.ID_Depart INNER JOIN Archivos.T_Tipo_Documento AS";
                    m_command += " TPD ON Doc.ID_TipoDoc = TPD.ID_TipoDoc WHERE ID_Status = 1 AND TPD.ID_TipoDoc = 1 Order by Area.Nombre,Dep.Nombre,Doc.Nombre";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_Procesos.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch
            { }
            return m_Procesos;
        }
    }
}