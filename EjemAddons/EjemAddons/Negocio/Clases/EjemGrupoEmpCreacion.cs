using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sage.ew.db;
using sage.ew.ewbase;
using sage.ew.functions;
using sage.ew.global;
using sage.ew.usuario;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase de ejemplo para creación, eliminación y cambio de grupo de empresas.
    /// </summary>
    public class EjemGrupoEmpCreacion
    {
        /// <summary>
        /// Ejemplo de creación de un nuevo grupo de empresas.
        /// </summary>
        /// <param name="tcCodigoGrupoCrear">Código de grupo a crear formado por 4 dígitos numéricos.</param>
        /// <param name="mensajeError">Mensaje de error que se podrá consultar en el origen de la llamada caso de que falle la creación del grupo.</param>
        /// <returns>Devuelve true si se ha podido crear el grupo correctamente, false caso contrario.</returns>
        private bool creacion(string tcCodigoGrupoCrear, ref string mensajeError)
        {
            bool llOk = true;
            mensajeError = string.Empty;

            // En este ejemplo el código de grupo a crear ya lo recibimos como parámetro.

            // Externamente a la llamada a este método, siempre que se quiera obtener un nuevo código de grupo que no exista, sin tener que
            // preocuparse de ir probando códigos, se puede llamar a la siguiente función la cual directamente nos devuelve un código de
            // grupo inexistente.
            //
            // string lcCodigoGrupoInexistente = GrupoempTools._Obtener_CodigoGrupo_Inexistente();


            // En primer lugar se ha de verificar que no esté creado ya el grupo en la instalación activa de Sage50
            // o en otra instalación de Sage50 con otra licencia pero que apunte a la misma instancia de SQLServer.
            //
            // Cada instancia de SQLSERVER a la que se apunta desde Sage50 tendrá una base de datos llamado SAGESYS 
            // (o EUROWINSYS) en la que existe una tabla llamada GRUPOSEMP. En esta tabla se guardan todos los códigos
            // de grupo de todas las diferentes instalaciones de Sage50 que apunten a esta instancia.
            //
            // Por tanto, verificando que el grupo que se pretende crear no exista en esta tabla nos garantiza que 
            // no existe el grupo ni en la instalación activa ni en cualquier otra instalación diferente de Sage50 que
            // apunte a la misma instancia de SQLServer.
            //

            string lcCodExistente = Convert.ToString(DB.SQLValor("gruposemp", "codigo", tcCodigoGrupoCrear, "codigo", "eurowinsys"));
            if (!string.IsNullOrWhiteSpace(lcCodExistente))
            {
                mensajeError = "El código de grupo " + tcCodigoGrupoCrear + " ya está siendo utilizado en ésta o otra instalación de " +
                               "Sage50 que trabaja apuntando a la misma instancia del servidor SQL. Imposible crear grupo.";
                return false;
            }

            // Al crear un grupo XXXX se creará la base de datos de comunes COMUXXXX, la base de datos de gestion con los datos del ejercicio
            // 2023YY, y una base de datos para addon que se instale por defecto en Sage50, por ejemplo TPV00YY, LOTES0YY, RGPD00YY, GESTDOYY,
            // INFORAYY, etc. Y se añade registro en SAGESYS!GRUPOSEMP con el código de grupo XXXX.
            //

            // Ya comprobamos anteriormente que el grupo que se pretende crear no existía en SAGESYS!GRUPOSEMP, antes de pasar a la creación
            // del grupo vamos a hacer otro control adicional para asegurar que no exista la base de datos de comunes COMUXXXX donde XXXX es
            // el grupo que se pretende crear. Como se ha comentado anteriormente es una de las bases de datos que se creará al crear el
            // grupo XXXX.
            //
            string lcDbComunes = "COMU" + tcCodigoGrupoCrear;
            if (DB._SQLExisteBBDD(lcDbComunes))
            {
                mensajeError = "ATENCIÓN: La base de datos " + lcDbComunes + " correspondiente al grupo que pretende crear ya existe en el servidor SQL." +
                               "Imposible crear nuevo grupo de empresa con este código.";
                return false;
            }

            // No verificamos la no existencia de las bases de datos del ejercicio y addons que le correspondería crear al crear el grupo, ya
            // lo hace la propia función a la que llamaremos para crear el grupo.
            //

            // GrupoempTools es una clase static, no hace falta crear objeto.
            //

            // Ruta a EUROSERV de la instalación en la que se está creando el grupo.
            //
            GrupoempTools._Euroserv = Convert.ToString(EW_GLOBAL._GetVariable("wc_iniservidor"));

            // Propiedad para indicar si queremos que se guarde un log con todos los detalles de la creación del grupo.
            //
            GrupoempTools._Log = true;

            // Ruta donde generaremos el log, por defecto la función siguiente nos devuelve un nombre con el siguiente formato:
            //
            // log_creagremp_YYYY_aaaammdd_hhmmss.txt
            //
            // donde YYYY es el código de grupo a crear, aaaammdd es la fecha de creación del grupo, 
            // y hhmmss es la hora de la creación del grupo.
            //
            GrupoempTools._RutaFicheroLog = GrupoempTools._Obtener_RutaLog_Automatica(tcCodigoGrupoCrear, 1);

            string lcNombreGrupoCrear = "Nombre del grupo";

            // Ejercicio que se creará en el grupo y que se marcará automáticamente como predeterminado. El grupo se crea con un solo
            // ejercicio.
            //
            // Si una vez creado el grupo con éxito se quiere crear algún otro ejercicio adicional se utilizará la siguiente llamada:
            //
            // bool llOk = GrupoempTools._Crear_Ejercicio(tcGrupoOrigen, tcEjerOrigen, tcEjerNuevo, tdFIniEjerNuevo, tdFFinEjerNuevo, tlMarcarEjerPredet)
            //
            // donde:
            //
            // tcGrupoOrigen: es el grupo sobre el que se quiere añadir un nuevo ejercicio, por ejemplo "0001".
            // tcEjerOrigen: es el ejercicio que se utilizará como base para la creación del nuevo ejercicio, por ejemplo "2023".
            // tcEjerNuevo: es el nuevo ejercicio a crear, por ejemplo "2022"
            // tdFIniEjerNuevo: es la fecha inicial del nuevo ejercicio a crear, por ejemplo new DateTime(2022,1,1);
            // tdFFinEjerNuevo: es la fecha final del nuevo ejercicio a crear, por ejemplo new DateTime(2022,12,31);
            // tlMarcarEjerPredet: si se ha de marcar el nuevo ejercicio como predeterminado, por defecto false.
            //
            string lcEjercicioCrear = "2023";

            // Nombre de la empresa que se creará en el grupo. El código de empresa será siempre 01.
            //
            string lcNombreEmpresaCrear = "Nombre de la empresa";

            // Cif de la empresa que se creará en el grupo.
            //
            string lcCifEmpresaCrear = "A1234123";

            // Si se han de conservar los clientes del grupo principal de la instalación a partir de la cual se crea el nuevo grupo.
            //
            bool llConservarClientes = false;

            // Si se han de conservar los usuarios del grupo principal de la instalación a partir de la cual se crea el nuevo grupo.
            //
            bool llConservarUsuarios = true;

            // Si el grupo a crear trabajará con ejercicio partido o no.
            //
            bool llEjercicioPartido = false;

            // Fecha inicial de ejercicio.
            //
            DateTime ldtFechaIniEjercicio = new DateTime(2023, 1, 1);

            // Fecha final de ejercicio.
            //
            DateTime ldtFechaFinEjercicio = new DateTime(2023, 12, 31);

            // Crear el nuevo grupo con las longitudes standar.
            //
            bool llLongitudesStandar = true;

            // Llamamos al método de GrupoempTools que hace la creación del grupo. 
            //
            // Esperar pacientemente a que acabe de ejecutarse este método que es el que crea el grupo. Puede tardar unos pocos minutos,
            // en función de los recursos de la máquina en la que se esté ejecutando.
            //
            llOk = GrupoempTools._Crear_Grupo(tcCodigoGrupoCrear, lcNombreGrupoCrear, lcEjercicioCrear, lcNombreEmpresaCrear, lcCifEmpresaCrear, "",
                                              llConservarClientes, llConservarUsuarios, llEjercicioPartido,
                                              ldtFechaIniEjercicio, ldtFechaFinEjercicio, llLongitudesStandar);

            // Si algo no fue bien, devolvemos el mensaje de error a origen.
            //
            if (!llOk)
            {
                mensajeError = "No se ha podido crear el nuevo grupo " + tcCodigoGrupoCrear + ". Mensaje de error: " + GrupoempTools._Error_Message;
            }
            else
            {
                // Si se creó el grupo correctamente tendremos un ejercicio solamente en el grupo y será el ejercicio predeterminado. Si
                // queremos crear algun otro ejercicio anterior lo podemos hacer de la siguiente forma.
                //
                ldtFechaIniEjercicio = new DateTime(2022, 1, 1);
                ldtFechaFinEjercicio = new DateTime(2022, 12, 31);
                string lcEjercicioOrigen = "2023";
                string lcEjercicioDestino = "2022";
                llOk = GrupoempTools._Crear_Ejercicio(tcCodigoGrupoCrear, lcEjercicioOrigen, lcEjercicioDestino, ldtFechaIniEjercicio, ldtFechaFinEjercicio, false);

                // Si algo no fue bien, devolvemos el mensaje de error a origen.
                //
                if (!llOk)
                    mensajeError = "Se ha podido crear el grupo " + tcCodigoGrupoCrear + " con el ejercicio predeterminado pero se ha producido " +
                                   "un fallo al crear el ejercicio adicional. Mensaje de error: " + GrupoempTools._Error_Message;

            }

            return llOk;
        }


        /// <summary>
        /// Ejemplo de eliminación de un grupo de empresas.
        /// </summary>
        /// <param name="tcCodigoGrupoEliminar">Código de grupo a eliminar.</param>
        /// <param name="mensajeError">Mensaje de error que se podrá consultar en el origen de la llamada caso de que falle la eliminación del grupo.</param>
        /// <returns>Devuelve true si se ha podido eliminar el grupo correctamente, false caso contrario.</returns>
        private bool eliminacion(string tcCodigoGrupoEliminar, ref string mensajeError)
        {
            bool llOk = true;
            mensajeError = "";

            // El grupo principal de la instalación no se puede eliminar.
            //
            GrupoEmpresa loGrupoEmp = new GrupoEmpresa(tcCodigoGrupoEliminar);
            if (loGrupoEmp._Pripal)
            {
                mensajeError = "El grupo de empresas " + tcCodigoGrupoEliminar + " que pretende eliminar es grupo principal y no puede eliminarse.";
                return false;
            }

            // El grupo activo tampoco se puede eliminar.
            //
            string lcDbComunesGrupo = "COMU" + tcCodigoGrupoEliminar;
            if (DB.DbComunes.ToUpper().Trim() == lcDbComunesGrupo.ToUpper().Trim())
            {
                mensajeError = "Para eliminar el grupo " + tcCodigoGrupoEliminar + " éste NO debe ser el grupo activo de la conexión al servidor SQL, debe estar conectado a otro grupo.";
                return false;
            }

            // GrupoempTools es una clase static, no hace falta crear objeto.
            //

            // Ruta a EUROSERV de la instalación en la que se pretende eliminar el grupo.
            //
            GrupoempTools._Euroserv = Convert.ToString(EW_GLOBAL._GetVariable("wc_iniservidor"));

            // Propiedad para indicar si queremos que se guarde un log con todos los detalles de la eliminación del grupo.
            //
            GrupoempTools._Log = true;

            // Ruta donde generaremos el log, por defecto la función siguiente nos devuelve un nombre con el siguiente formato:
            //
            // log_borrargremp_YYYY_aaaammdd_hhmmss.txt
            //
            // donde YYYY es el código de grupo a eliminar, aaaammdd es la fecha de eliminación del grupo, 
            // y hhmmss es la hora de la eliminación del grupo.
            //
            GrupoempTools._RutaFicheroLog = GrupoempTools._Obtener_RutaLog_Automatica(tcCodigoGrupoEliminar, 1);

            // Llamamos al método de GrupoempTools que elimina el grupo.
            //
            llOk = GrupoempTools._Borrar_Grupo(tcCodigoGrupoEliminar);

            // Si algo no fue bien, devolvemos el mensaje de error a origen.
            //
            if (!llOk)
                mensajeError = "No se ha podido eliminar el grupo " + tcCodigoGrupoEliminar + ", mensaje de error: " + GrupoempTools._Error_Message;

            return llOk;
        }


        /// <summary>
        /// Ejemplo de cambio de grupo de empresas.
        /// </summary>
        /// <param name="tcCodigoGrupoCambiar">Código de grupo al que queremos cambiar.</param>
        /// <param name="mensajeError">Mensaje de error que se podrá consultar en el origen de la llamada caso de que falle el cambio de grupo.</param>
        /// <returns>Devuelve true si se ha podido cambiar de grupo correctamente, false caso contrario.</returns>
        private bool cambio(string tcCodigoGrupoCambiar, ref string mensajeError)
        {
            bool llOk = true;

            // El grupo al que se quiere cambiar no existe.
            //
            GrupoEmpresa loGrupoExistente = new GrupoEmpresa(tcCodigoGrupoCambiar);
            if (loGrupoExistente._Estado != ewMante._EstadosMantenimiento.MostrandoRegistro)
            {
                mensajeError = "El grupo de empresas " + tcCodigoGrupoCambiar + " al que quiere cambiar no existe.";
                return false;
            }
            loGrupoExistente = null;

            // Código de empresa del nuevo grupo en la que queremos que quede situado una vez se haya llevado a cabo el cambio
            // de grupo.
            //
            string lcEmpresaSituar = "01";

            GrupoEmpresaSel loGrupo = new GrupoEmpresaSel();
            llOk = loGrupo._CambiarGrupo(tcCodigoGrupoCambiar, lcEmpresaSituar);

            if (!llOk)
                mensajeError = "No se puedo efectuar el cambio de grupo al grupo " + tcCodigoGrupoCambiar;

            return llOk;
        }
    }
}
