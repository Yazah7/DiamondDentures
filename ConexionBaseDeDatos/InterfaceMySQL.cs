﻿using Entidad;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ConexionBaseDeDatos
{
    /// <summary>
    /// Describe los métodos para accesar a una base de datos de MySQL
    /// </summary>
    public static partial class InterfaceMySQL
    {
        // Para poder trabajar juntos no podemos hacerlo como
        // lo hemos estado haciendo anteriormente, ya que si todos
        // modificamos el mismo archivo al mismo tiempo podemos
        // interferir inconsientemente en el trabajo de otros, 
        // para evitar esto introduciremos el trabajo en clases parciales
        // ¿cómo funciona esto? Podemos consultar el siguiente link
        // https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods
        // cada quién deberá editar su propio archivo, se migrará de la clase
        // InterfaceBaseDeDatos a InterfaceMySQL, al finalizar no deberá haber
        // ningún uso de la clase InterfaceBaseDeDatos para asegurar que todos
        // los módulos se hayan migrado a la nueva definición de la base de datos
        // y funcionen correctamente.

        // En los procedimientos almacenados, en los insert, coloquen las columnas
        // de destino y los valores, para cuando se añadan nuevas columnas (de ser
        // necesario) no afecten los procedimientos almacenados ya creados.

        // Recomiendo fuertemente que borren o comenten los metodos de la
        // InterfaceBaseDeDatos cuando sirvan en esta clase para tener un control
        // de lo que llevamos modificado

        /// <summary>
        /// Define los tipos que puede devolver un procedimiento almacenado.
        /// </summary>
        enum TipoConsulta { DevuelveInt, DevuelveReader };

        /// <summary>
        /// Nombre del Administrador de la base de datos
        /// </summary>
        static string Administrador { get { return "root"; } }

        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        static string BaseDeDatos { get { return "diamonddentures"; } }

        /// <summary>
        /// Contraseña de la base de datos
        /// </summary>
        static string Contraseña { get { return "diamonddentures"; } }

        /// <summary>
        /// Puerto para acceder a la instancia de MySQL
        /// </summary>
        static uint Puerto { get { return 3306; } }

        /// <summary>
        /// Servidor para acceder a la instancia de MySQL
        /// </summary>
        static string Servidor { get { return "35.193.200.182"; } }

        /// <summary>
        /// Guarda el número de registros afectados por una consulta
        /// </summary>
        static int RegistrosAfectados { get; set; }

        /// <summary>
        /// Regresa si una operacion fue realizada con éxito
        /// </summary>
        static bool OperacionRealizada { get { return RegistrosAfectados > 0; } }

        /// <summary>
        /// Variable conexion para establecer una conexion entre el programa y el servidor
        /// </summary>
        static MySqlConnection Conexion { get; set; }

        /// <summary>
        /// Variable comando para guardar la sentencia a ejecutar
        /// </summary>
        static MySqlCommand Comando { get; set; }

        /// <summary>
        /// Lector de datos de tablas
        /// </summary>
        static MySqlDataReader Lector { get; set; }

        static DataTable ResultadoTabla { get; set; }

        /// <summary>
        /// Crea o Actualiza la base de datos en la nube
        /// </summary>
        public static void ActualizarBaseDeDatos()
        {
            EjecutarConsulta(Properties.Resources.Script_TablasDD);
            EjecutarConsulta(Properties.Resources.Script_Procedimientos_Base);
            EjecutarConsulta(Properties.Resources.Script_Rolland);
            EjecutarConsulta(Properties.Resources.Script_Olachea);
            EjecutarConsulta(Properties.Resources.Script_Yazahel);
            EjecutarConsulta(Properties.Resources.Script_Michell);
        }

        /// <summary>
        /// Inicializa la conexion para su uso con la base de datos online.
        /// </summary>
        static void InicializarConexion()
        {
            InicializarConexion(BaseDeDatos);
        }

        /// <summary>
        /// Inicializa la conexión con la Base de Datos establecida
        /// </summary>
        /// <param name="BD">Base de datos a conectar</param>
        static void InicializarConexion(string BD)
        {
            MySqlConnectionStringBuilder Cadena = new MySqlConnectionStringBuilder();
            Cadena.Port = Puerto;
            Cadena.Server = Servidor;
            Cadena.UserID = Administrador;
            Cadena.Password = Contraseña;
            Cadena.Database = BD;
            Conexion = new MySqlConnection(Cadena.ConnectionString);
        }

        /// <summary>
        /// Manda a ejecutar la consulta establecida en el parámetro.
        /// </summary>
        /// <param name="Consulta">Consulta a ejecutar en el gestor de base de datos</param>
        static void EjecutarConsulta(string Consulta)
        {
            InicializarConexion("mysql");
            AbrirConexion();
            Comando = new MySqlCommand(Consulta, Conexion);
            Comando.ExecuteNonQuery();
            CerrarConexion();
            InicializarConexion();
        }

        /// <summary>
        /// Ejecuta un lector de tabla mediante un procedimiento almacenado
        /// </summary>
        /// <param name="NombreProcedimiento">Nombre del procedimiento almacenado</param>
        /// <returns>Objeto que permite leer los datos de la tabla</returns>
        static MySqlDataReader EjecutarProcedimientoAlmacenado(string NombreProcedimiento)
        {
            Comando = new MySqlCommand(NombreProcedimiento, Conexion);
            Comando.CommandType = CommandType.StoredProcedure;
            AbrirConexion();
            MySqlDataReader Lector = Comando.ExecuteReader();
            CerrarConexion();
            return Lector;
        }

        /// <summary>
        /// Ejecuta una consulta mediante un procedimiento almacenado
        /// </summary>
        /// <param name="NombreProcedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="Datos">Datos a insertar como parametros en el procedimiento</param>
        /// <returns>Número de registros afectador por la operación</returns>

        static void EjecutarProcedimientoAlmacenado
            (string NombreProcedimiento, TipoConsulta Tipo, params MySqlParameter[] Datos)
        {
            Comando = new MySqlCommand(NombreProcedimiento, Conexion);
            for (int i = 0; i < Datos.Length; i++)
                Comando.Parameters.Add(Datos[i]);
            Comando.CommandType = CommandType.StoredProcedure;
            AbrirConexion();
            if (Tipo == TipoConsulta.DevuelveInt)
                RegistrosAfectados = Comando.ExecuteNonQuery();
            else
            {
                Lector = Comando.ExecuteReader();
                ResultadoTabla = new DataTable();
                ResultadoTabla.Load(Lector);
            }
            CerrarConexion();
        }

        /// <summary>
        /// Permite convertir el nombre y valor de un parametro a una clase de tipo MySqlParameter
        /// </summary>
        /// <param name="Nombre">Nombre del parámetro</param>
        /// <param name="Valor">Valor del parámetro</param>
        /// <returns>Instancia de la clase MySqlParameter</returns>
        static MySqlParameter Parametro(string Nombre, object Valor)
        {
            return new MySqlParameter(Nombre, Valor);
        }

        /// <summary>
        /// Abre la conexión
        /// </summary>
        static void AbrirConexion()
        {
            try
            {
                if (Conexion.State != ConnectionState.Open)
                {
                    Conexion.Open();
                }
                else
                {
                    Conexion.Close();
                    AbrirConexion();
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show("No se pudo establecer la conexión, por favor revisa tu conexión a internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Cierra la conexión
        /// </summary>
        static void CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
        }

        #region Login & Usuarios

        /// <summary>
        /// Verifica la existencia de Administradores
        /// </summary>
        /// <returns></returns>
        public static bool HayAdministradores()
        {
            bool HayAdmin = false;
            MySqlDataReader Lector = EjecutarProcedimientoAlmacenado("ConteoAdministradores");
            if (Lector.HasRows)
            {
                Lector.Read();
                if (Convert.ToInt32(Lector["resultado"].ToString()) == 0)
                    HayAdmin = true;
            }
            return HayAdmin;
        }

        /// <summary>
        /// Registra un número de empleado
        /// </summary>
        /// <param name="NumeroEmpleado">Numero de empleado a registrar</param>
        /// <returns>Operación exitosa</returns>
        public static bool RegistrarEmpleado(int NumeroEmpleado)
        {
            EjecutarProcedimientoAlmacenado("RegistrarEmpleado", TipoConsulta.DevuelveInt,
                Parametro("@emp", NumeroEmpleado));
            return OperacionRealizada;
        }

        /// <summary>
        /// Valida si un empleado está registrado
        /// </summary>
        /// <param name="NumeroTrabajador">Número de trabajador a validar</param>
        /// <returns>Número existente</returns>
        public static bool ValidarEmpleado(int NumeroTrabajador)
        {
            EjecutarProcedimientoAlmacenado("ValidarEmpleado", TipoConsulta.DevuelveReader,
                Parametro("@emp", NumeroTrabajador));
            if (ResultadoTabla.Rows.Count > 0)
            {
                RegistrosAfectados = 1;
            }
            return OperacionRealizada;
        }

        /// <summary>
        /// Registra un usuario en la base de datos
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public static bool RegistroUsuario(RegistroUsuario Usuario)
        {
            EjecutarProcedimientoAlmacenado("RegistrarUsuario", TipoConsulta.DevuelveInt,
                Parametro("emplead", Usuario.NumeroTrabajador),
                Parametro("logi", Usuario.Login),
                Parametro("passwor", Usuario.Password),
                Parametro("apellido", Usuario.Apellidos),
                Parametro("nombr", Usuario.Nombre),
                Parametro("FechaNacimient", Usuario.FechaNacimiento_),
                Parametro("NumCas", Usuario.NumCasa),
                Parametro("Direccio", Usuario.Direccion),
                Parametro("Coloni", Usuario.Colonia),
                Parametro("Ciuda", Usuario.Ciudad),
                Parametro("Municipi", Usuario.Municipio),
                Parametro("Estad", Usuario.Estado),
                Parametro("Pai", Usuario.Pais),
                Parametro("CodPo", Usuario.CodPos),
                Parametro("TelCas", Usuario.TelCasa),
                Parametro("TelOficin", Usuario.TelOficina),
                Parametro("TelCe", Usuario.TelCel),
                Parametro("Emai", Usuario.Email),
                Parametro("Pregunt", Usuario.Pregunta),
                Parametro("Respuest", Usuario.Respuesta),
                Parametro("Activ", Usuario.Activo),
                Parametro("Departament", Usuario.Departamento),
                Parametro("FechaIngres", Usuario.FechaIngreso_),
                Parametro("Puest", Usuario.Puesto),
                Parametro("Sueld", Usuario.SueldoDiario)
                );
            return OperacionRealizada;
        }

        /// <summary>
        /// Método para recuperar un usuario de la base de datos
        /// </summary>
        /// <param name="login">Login del usuario a recuperar</param>
        /// <param name="Usuario">RegistroUsuario que guardará la información del usuario</param>
        /// <returns>Si encontró un usuario o no</returns>
        public static bool RecuperarUsuario(string login, out RegistroUsuario Usuario)
        {
            EjecutarProcedimientoAlmacenado("RecuperarUsuario", TipoConsulta.DevuelveReader,
                Parametro("log", login));
            Usuario = ObtenerUsuario();
            return OperacionRealizada;
        }

        /// <summary>
        /// Método para obtener una tarjeta bancaria de la base de datos
        /// </summary>
        /// <param name="login">Login del usuario dueño de la tarjeta</param>
        /// <param name="Tarjeta">RegistroTarjeta que guardará la información</param>
        /// <returns>El registro con la información de la tarjeta</returns>
        public static bool RecuperarTarjeta(string login, out RegistroTarjeta Tarjeta)
        {
            EjecutarProcedimientoAlmacenado("RecuperarTarjeta", TipoConsulta.DevuelveReader,
                Parametro("log", login));
            Tarjeta = ObtenerTarjeta();
            return OperacionRealizada;
        }
        #endregion

        #region MétodosDeApoyo

        /// <summary>
        /// Método para obtener un usuario leído por MySQL
        /// </summary>
        /// <returns>Usuario de la consulta, null si no hubo nada</returns>
        static RegistroUsuario ObtenerUsuario()
        {
            RegistroUsuario[] x = RellenarUsuarios();
            RegistroUsuario temp = x.Length > 0 ? x[0] : null;
            RegistrosAfectados = temp != null ? 1 : 0;
            return temp;
        }

        /// <summary>
        /// Método para obtener una tarjeta leída por MySQL
        /// </summary>
        /// <returns>Tarjeta de la consulta, null si no se encontró nada</returns>
        static RegistroTarjeta ObtenerTarjeta()
        {
            RegistroTarjeta[] x = RellenarTarjetas();
            RegistroTarjeta temp = x.Length > 0 ? x[0] : null;
            RegistrosAfectados = temp != null ? 1 : 0;
            return temp;
        }

        /// <summary>
        /// Método para obtener tarjetas de la base de datos
        /// </summary>
        /// <returns>Colección de tarjetas</returns>
        static RegistroTarjeta[] RellenarTarjetas()
        {
            RegistroTarjeta[] Cards = new RegistroTarjeta[ResultadoTabla.Rows.Count];
            for (int i = 0; i < Cards.Length; i++)
            {
                DataRow temp = ResultadoTabla.Rows[i];
                Cards[i] = new RegistroTarjeta(
                    temp["login"].ToString(),
                    temp["numero"].ToString(),
                    temp["titular"].ToString(),
                    temp["apellidos"].ToString(),
                    temp["banco"].ToString(),
                    temp["fven"].ToString(),
                    temp["activo"].ToString()
                    );
            }
            return Cards;
        }

        /// <summary>
        /// Mete los valores obtenidos en ResultadosTabla en un arreglo de usuarios
        /// </summary>
        /// <returns>Arreglo de usuarios</returns>
        static RegistroUsuario[] RellenarUsuarios()
        {
            RegistroUsuario[] Users = new RegistroUsuario[ResultadoTabla.Rows.Count];
            for (int i = 0; i < Users.Length; i++)
            {
                DataRow temp = ResultadoTabla.Rows[i];
                Users[i] = new RegistroUsuario(
                    Convert.ToInt32(temp["N_Empleado"]),
                    temp["Login"].ToString(),
                    temp["Password"].ToString(),
                    temp["Nombre"].ToString(),
                    temp["Apellidos"].ToString(),
                    Convert.ToDateTime(temp["FechaNacimiento"]),
                    temp["NumCasa"].ToString(),
                    temp["Direccion"].ToString(),
                    temp["Colonia"].ToString(),
                    temp["Ciudad"].ToString(),
                    temp["Municipio"].ToString(),
                    temp["Estado"].ToString(),
                    temp["Pais"].ToString(),
                    temp["CodPos"].ToString(),
                    temp["TelCasa"].ToString(),
                    temp["TelOficina"].ToString(),
                    temp["TelCel"].ToString(),
                    temp["Email"].ToString(),
                    temp["Pregunta"].ToString(),
                    temp["Respuesta"].ToString(),
                    temp["Activo"].ToString(),
                    temp["Departamento"].ToString(),
                    temp["Puesto"].ToString(),
                    Convert.ToDateTime(temp["FechaIngreso"]),
                    Convert.ToSingle(temp["Sueldo"])
                    );
            }
            return Users;
        }

        #endregion
    }
}