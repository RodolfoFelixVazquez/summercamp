using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace summercamp.Core.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public int  Instructor { get; set; }

    

        public static List<Curso> GetAll()
        {
            List<Curso> Cursos = new List<Curso>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, horario, instructor FROM curso;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Curso Curso = new Curso();
                        Curso.Id = int.Parse(dataReader["id"].ToString());
                        Curso.Nombre = dataReader["nombre"].ToString();
                        Curso.Horario = dataReader["horario"].ToString();
                        Curso.Instructor = int.Parse(dataReader["instructor"].ToString());
                     

                        Cursos.Add(Curso);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            } catch (Exception ex) {


                throw ex;
            }
            return Cursos;
        }

        public static Curso GetById(int id)
        {
            Curso Curso = new Curso();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, horario, instructor  FROM curso WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Curso.Id = int.Parse(dataReader["id"].ToString());
                        Curso.Nombre = dataReader["nombre"].ToString();
                        Curso.Horario = dataReader["horario"].ToString();
                        Curso.Instructor = int.Parse(dataReader["instructor"].ToString());

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Curso;
        }
        public static bool Guardar(int id, string nombre, string horario, int instructor)
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

                        cmd.CommandText = "INSERT INTO curso (nombre, horario, instructor) VALUES (@nombre, @horario, @instructor)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@horario", horario);
                        cmd.Parameters.AddWithValue("@instructor", instructor);


                    }
                    else
                    {

                        cmd.CommandText = "UPDATE curso SET nombre = @nombre, horario = @horario, instructor = @instructor WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@horario", horario);
                        cmd.Parameters.AddWithValue("@instructor", instructor);
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
                        cmd.CommandText = "DELETE FROM curso WHERE id = @id";
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

        public static List<Inscripcion> GetParticipantes(int id)
        {
            List<Inscripcion> Inscripciones = new List<Inscripcion>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, participante, curso  FROM inscripcion WHERE curso = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Inscripcion inscripcion = new Inscripcion();    
                        inscripcion.Id = int.Parse(dataReader["id"].ToString());
                        inscripcion.Participante = int.Parse(dataReader["participante"].ToString());
                        inscripcion.Curso = int.Parse(dataReader["curso"].ToString());

                        Inscripciones.Add(inscripcion);

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Inscripciones;
        }


    }

}
