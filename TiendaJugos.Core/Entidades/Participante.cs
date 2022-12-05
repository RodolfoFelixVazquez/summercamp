using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summercamp.Core.Entidades
{
    public  class Participante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }



        public static List<Participante> GetAll()
        {
            List<Participante> Participantes = new List<Participante>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, telefono, correo FROM participante;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Participante Participante = new Participante();
                        Participante.Id = int.Parse(dataReader["id"].ToString());
                        Participante.Nombre = dataReader["nombre"].ToString();
                        Participante.Telefono = dataReader["telefono"].ToString();
                        Participante.Correo = dataReader["correo"].ToString();


                        Participantes.Add(Participante);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {


                throw ex;
            }
            return Participantes;
        }

       
        public static Participante GetById(int id)
        {
            Participante Participante = new Participante();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, telefono, correo  FROM participante WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Participante.Id = int.Parse(dataReader["id"].ToString());
                        Participante.Nombre = dataReader["nombre"].ToString();
                        Participante.Telefono = dataReader["telefono"].ToString();
                        Participante.Correo = dataReader["correo"].ToString();

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Participante;
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
                        cmd.CommandText = "INSERT INTO participante (nombre, telefono, correo) VALUES (@nombre, @telefono, @correo)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@correo", correo);

                    }
                    else
                    {

                        cmd.CommandText = "UPDATE participante SET nombre = @nombre, telefono = @telefono, correo = @correo WHERE id = @id";
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
                        cmd.CommandText = "DELETE FROM participante WHERE id = @id";
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

