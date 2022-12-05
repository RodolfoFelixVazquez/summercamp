using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summercamp.Core.Entidades
{
    public  class Instructor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }



        public static List<Instructor> GetAll()
        {
            List<Instructor> Instructors = new List<Instructor>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, telefono, correo FROM instructor;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Instructor Instructor = new Instructor();
                        Instructor.Id = int.Parse(dataReader["id"].ToString());
                        Instructor.Nombre = dataReader["nombre"].ToString();
                        Instructor.Telefono = dataReader["telefono"].ToString();
                        Instructor.Correo = dataReader["correo"].ToString();


                        Instructors.Add(Instructor);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {


                throw ex;
            }
            return Instructors;
        }

       
        public static Instructor GetById(int id)
        {
            Instructor Instructor = new Instructor();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, telefono, correo  FROM instructor WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Instructor.Id = int.Parse(dataReader["id"].ToString());
                        Instructor.Nombre = dataReader["nombre"].ToString();
                        Instructor.Telefono = dataReader["telefono"].ToString();
                        Instructor.Correo = dataReader["correo"].ToString();

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Instructor;
        }
        public static bool Guardar(int id, string nombre, string telefono, string correo)
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
                        cmd.CommandText = "INSERT INTO instructor (nombre, telefono, correo) VALUES (@nombre, @telefono, @correo)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@correo", correo);

                    }
                    else
                    {

                        cmd.CommandText = "UPDATE instructor SET nombre = @nombre, telefono = @telefono, correo = @correo WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@correo", correo);
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
        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {

                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    if (id != 0)
                    {
                        cmd.CommandText = "DELETE FROM instructor WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
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

    }

}

