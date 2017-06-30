using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZooApi
{
    public class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {
                // PREPARO LA CADENA DE CONEXIÓN A LA BD
                string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                // CREO LA CONEXIÓN
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                // TRATO DE ABRIR LA CONEXION
                conexion.Open();

            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }
       
        
        
        
        //APARTIR DE AQUI ESTAN ESPECIES
        




        //get_especie completo sin filtro
        public static List<Especies> GetEspecie()
        {
            List<Especies> resultado = new List<Especies>();


            string procedimientoAEjecutar = "dbo.GET_ESPECIE";

            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {

                Especies especie = new Especies();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.clasificacion = new Clasificacion();
                especie.clasificacion.idClasificacion = (int)reader["idClasificacion"];
                especie.clasificacion.denominacion = reader["Clasificacion"].ToString();
                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                especie.tipoAnimal.denominacion = reader["TipoAnimal"].ToString();
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];

                resultado.Add(especie);

            }

            return resultado;
        }
       
        // especies por id
        public static List<Especies> GetEspecieId(long idEspecie)
        {
            List<Especies> resultado = new List<Especies>();


            string procedimientoAEjecutar = "dbo.GET_ESPECIES_ID";

            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = idEspecie;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {

                Especies especie = new Especies();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.clasificacion = new Clasificacion();
                especie.clasificacion.idClasificacion = (int)reader["idClasificacion"];
                especie.clasificacion.denominacion = reader["Clasificacion"].ToString();
                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                especie.tipoAnimal.denominacion = reader["TipoAnimal"].ToString();
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];

                resultado.Add(especie);

            }

            return resultado;
        }

        //crear la especie
        public static int AgregarEspecie(Especies especie)
        {
            string procedimiento = "dbo.AgregarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroClasificacion = new SqlParameter();
            parametroClasificacion.ParameterName = "idClasificacion";
            parametroClasificacion.SqlDbType = SqlDbType.Int;
            parametroClasificacion.SqlValue = especie.clasificacion.idClasificacion;

            comando.Parameters.Add(parametroClasificacion);

            SqlParameter parametroTipoAnimal = new SqlParameter();
            parametroTipoAnimal.ParameterName = "idTipoAnimal";
            parametroTipoAnimal.SqlDbType = SqlDbType.BigInt;
            parametroTipoAnimal.SqlValue = especie.tipoAnimal.idTipoAnimal;

            comando.Parameters.Add(parametroTipoAnimal);

            SqlParameter parametroNombre = new SqlParameter();
            parametroNombre.ParameterName = "nombre";
            parametroNombre.SqlDbType = SqlDbType.NVarChar;
            parametroNombre.SqlValue = especie.nombre;

            comando.Parameters.Add(parametroNombre);

            SqlParameter parametroPatas = new SqlParameter();
            parametroPatas.ParameterName = "nPatas";
            parametroPatas.SqlDbType = SqlDbType.NVarChar;
            parametroPatas.SqlValue = especie.nPatas;

            comando.Parameters.Add(parametroPatas);

            SqlParameter parametroEsMascota = new SqlParameter();
            parametroEsMascota.ParameterName = "esMascota";
            parametroEsMascota.SqlDbType = SqlDbType.NVarChar;
            parametroEsMascota.SqlValue = especie.esMascota;

            comando.Parameters.Add(parametroEsMascota);


            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        //actualizar la especie
        public static int ActualizarEspecie(long id, Especies especie)
        {
            string procedimiento = "dbo.ActualizarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlParameter parametroClasificacion = new SqlParameter();
            parametroClasificacion.ParameterName = "idClasificacion";
            parametroClasificacion.SqlDbType = SqlDbType.Int;
            parametroClasificacion.SqlValue = especie.clasificacion.idClasificacion;

            comando.Parameters.Add(parametroClasificacion);

            SqlParameter parametroTipoAnimal = new SqlParameter();
            parametroTipoAnimal.ParameterName = "idTipoAnimal";
            parametroTipoAnimal.SqlDbType = SqlDbType.BigInt;
            parametroTipoAnimal.SqlValue = especie.tipoAnimal.idTipoAnimal;

            comando.Parameters.Add(parametroTipoAnimal);

            SqlParameter parametroNombre = new SqlParameter();
            parametroNombre.ParameterName = "nombre";
            parametroNombre.SqlDbType = SqlDbType.NVarChar;
            parametroNombre.SqlValue = especie.nombre;

            comando.Parameters.Add(parametroNombre);

            SqlParameter parametroPatas = new SqlParameter();
            parametroPatas.ParameterName = "nPatas";
            parametroPatas.SqlDbType = SqlDbType.NVarChar;
            parametroPatas.SqlValue = especie.nPatas;

            comando.Parameters.Add(parametroPatas);

            SqlParameter parametroEsMascota = new SqlParameter();
            parametroEsMascota.ParameterName = "esMascota";
            parametroEsMascota.SqlDbType = SqlDbType.NVarChar;
            parametroEsMascota.SqlValue = especie.esMascota;

            comando.Parameters.Add(parametroEsMascota);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        //eliminar la especie
        public static int EliminarEspecie(long id)
        {
            string procedimiento = "dbo.EliminarEspecie";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;

            comando.Parameters.Add(parametroId);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }
    }
}
