using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summercamp.Core.Entidades
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int  Participante { get; set; }
        public int  Curso { get; set; }

    

        public static List<Inscripcion> GetAll()
        {
            List<Inscripcion> Inscripcions = new List<Inscripcion>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, participante, curso FROM inscripcion;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Inscripcion Inscripcion = new Inscripcion();
                        Inscripcion.Id = int.Parse(dataReader["id"].ToString());
                        Inscripcion.Participante = int.Parse(dataReader["participante"].ToString());
                        Inscripcion.Curso = int.Parse(dataReader["curso"].ToString());
                     

                        Inscripcions.Add(Inscripcion);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            } catch (Exception ex) {


                throw ex;
            }
            return Inscripcions;
        }

        public static Inscripcion GetById(int id)
        {
            Inscripcion Inscripcion = new Inscripcion();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, participante, curso  FROM inscripcion WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Inscripcion.Id = int.Parse(dataReader["id"].ToString());
                        Inscripcion.Participante = int.Parse(dataReader["participante"].ToString());
                        Inscripcion.Curso = int.Parse(dataReader["curso"].ToString());

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Inscripcion;
        }
        public static bool Guardar(int id, int participante, int curso)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    if (id == 0)
                    {

                        cmd.CommandText = "INSERT INTO inscripcion (participante, curso) VALUES (@participante, @curso)";
                        cmd.Parameters.AddWithValue("@participante", participante);
                        cmd.Parameters.AddWithValue("@curso", curso);
                   


                    }
                    else
                    {

                        cmd.CommandText = "UPDATE inscripcion SET participante = @participante, curso = @curso WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", participante);
                        cmd.Parameters.AddWithValue("@horario", curso);
                        
                    }
                    result = cmd.ExecuteNonQuery() == 1;



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public static bool Eliminar(int id) { 
            bool result = false;
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    if (id != 0)
                    {
                        cmd.CommandText = "DELETE FROM inscripcion WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                    }
                    result =cmd.ExecuteNonQuery() == 1;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }        
        
    }

}
