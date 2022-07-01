using sage.addons.EjemAddons.Negocio.Clases;
using sage.addons.EjemAddons.Visual.BindForm;
using sage.ew.ewbase;
using sage.ew.formul;
using sage.ew.formul.Forms;
using sage.ew.interficies;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;


/// <summary>
/// Este es el espacio de nombres de su módulo.
/// Puede encontrar más información y ayuda en el fichero readme.txt
/// </summary>
namespace sage.addons.EjemAddons
{
    /// <summary>
    /// Clase base para el módulo EjemAddons
    /// </summary>
    public partial class EjemAddons : Modulo
    {

        #region PROPIEDADES

        /// <summary>
        /// Firma del addon
        /// </summary>
        public override string Firma { get; set; }

        /// <summary>
        /// Instancia del ensamblado al que pertenece la libreria
        /// </summary>
        ///public Assembly _Assembly;

        #endregion PROPIEDADES

        #region CONSTRUCTORES

        /// <summary>
        /// Inicializa una nueva instancia de la classe
        /// </summary>
        public EjemAddons()
        {
            // Asignar los tipos para la configuración del módulo
            this.UserControlConfigType = typeof(Visual.UserControls.EjemAddonsConfig);
            this.ModuloConfigType = typeof(Negocio.Clases.EjemAddonsConfig);
        }
        #endregion CONSTRUCTORES

        #region MÉTODOS

        /// <summary>
        /// Método que nos permite configurar como se debe actualizar nuestro add-on y desde que espacio FTP
        /// Únicamente configuramos para que nos devuelva un objeto que cumpla la interfaz IAccesAddonUrl y Sage 50 tanto en el 
        /// proceso de actualización de una Master como la actualización de una release automáticamente accederá a la configuración
        /// del hosting y se bajará la última versión del add-on.
        /// </summary>
        /// <returns></returns>
        public override IAccesAddonUrl _GetNewVersion()
        {
            // devolvemos un objeto del tipo UpdateAddonHosting que cumple la interfaz que se espera
            // en este objeto se definen las propiedades url del ftp, usuario, password del usuario y la carpeta donde está
            // el paquete del add-on (instalador del add-on)
            return new UpdateAddonHosting();
        }

        /// <summary>
        /// Devuelve la lista prévia del documento
        /// </summary>
        /// <param name="tcClass"></param>
        /// <param name="toTipoObjeto"></param>
        /// <param name="tcPantalla"></param>
        /// <returns></returns>
        public override object _GetListaPrevia(string tcClass, Type toTipoObjeto, string tcPantalla)
        {
            object loInstancia = null;

            switch (tcClass)
            {
                default:
                    break;
            }

            return loInstancia;
        }

        /// <summary>
        /// Método para obtener las instancias de clases de extensiones desde los documentos y mantenimientos
        /// </summary>
        /// <param name="_key">Nombre por el que identificar el mantenimiento</param>
        /// <param name="_mantePrincipal">Instancia del mantenimiento que se va a extender</param>
        /// <returns></returns>
        public override object _Extension(string _key, sage.ew.interficies.IMante _mantePrincipal)
        {
            // Ya se ha definido una extensión del mantenimiento de empresa para la configuración del módulo.
            // Se instancia en la base y se recoge en loInstancia.
            // La clase de negocio es classConfig.cs y la parte visual usercontrolConfig.cs.

            object loInstancia = base._Extension(_key, _mantePrincipal);

            _key = _key.ToLower().Trim();

            switch (_key)
            {
                default:
                    break;
            }

            return loInstancia;
        }

        /// <summary>
        /// Método para obtener las instancias de clases de extensiones de mantenimientos de tablas relacionadas (ManteTRel)
        /// </summary>
        /// <param name="_key">Nombre por el que identificar el mantenimiento de relacionado</param>
        /// <param name="_manteTRelPrincipal">Mantenimiento relacionado principal (el que se va a extender)</param>
        /// <param name="_ordenAddon">Número de orden en que se cargará el addon y sus columnas</param>
        /// <returns></returns>
        public override object _ExtensionManteTRel(string _key, sage.ew.interficies.IManteTRel _manteTRelPrincipal, int _ordenAddon)
        {
            object loInstancia = null;

            _key = _key.ToLower().Trim();

            switch (_key)
            {
                default:
                    break;
            }

            return loInstancia;
        }

        /// <summary>
        /// Vincula los formularios de la aplicación con los del addon
        /// </summary>
        /// <param name="_nombreForm">Nombre del formulario</param>
        /// <param name="_formBase">Instancia del formulario base</param>
        public override void _BindForm(string _nombreForm, IFormBase _formBase)
        {
            base._BindForm(_nombreForm, _formBase);

            _nombreForm = _nombreForm.ToLower().Trim();

            // Puede que el formulario sea el FormMante base. En ese caso, utilizamos el nombre de _Pantalla
            if (_nombreForm == "formmante")
                _nombreForm = _formBase._Pantalla.ToLower().Trim();

            switch (_nombreForm)
            {
                case "frmdocventatpv":
                case "frmdocventaped":
                case "frmdocventapresupuesto":
                case "frmdocventaalbaran":
                    // Añadimos una opción en el botón de herramientas de los documentos de venta que nos presentará un mensaje con el título del formulario.
                    BindFormGetOpcionesHerramientas loBindFormGetOpcionesHerramientas = new BindFormGetOpcionesHerramientas(_formBase);

                    // Ejemplo _GetOpciones para los documentos de venta
                    // El código está implementado en la clase "BindFormGetOpcionesDocumentosVenta" para poder diferenciar el código de ejemplo para acceder al botón de herramientas
                    // No es necesario tener dos clases, está implementado de esta forma para poder visualizar más fácilmente el ejemplo a mostrar
                    BindFormGetOpcionesDocumentosVenta loBindFormGetOpcionesDocumentosVenta = new BindFormGetOpcionesDocumentosVenta(_formBase);
                    break;


                case "frmfactalbaranespendientes":
                    BindFormEventosClick loBindFormEventosClick = new BindFormEventosClick(_formBase);
                    break;

                case "frmasientos":
                    // Ejemplo _GetOpciones para tener acceso al menú del botón “Opciones” en la pantalla de Asientos
                    BindFormGetOpcionesAsientos loBindFormGetOpcioneAsientos = new BindFormGetOpcionesAsientos(_formBase);
                    break;

                case "frmlistasprevias":
                    // Ejemplo _GetOpciones para tener acceso al menú del botón “Opciones” de las listas previas de la pantalla de Asientos
                    BindFormGetOpcionesListasPrevias loBindFormGetOpcionesListasPrevias = new BindFormGetOpcionesListasPrevias(_formBase);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Método que se dispara cada vez que se carga este add-on en Sage 50
        /// </summary>
        /// <returns>true si la carga del módulo finaliza con éxito, false en caso contrario</returns>
        public override Boolean _Load()
        {
            return base._Load();
        }

        /// <summary>
        /// Método que se dispara cada vez que se cierra Sage 50
        /// </summary>
        /// <returns>true si la descarga del módulo finaliza con éxito, false en caso contrario</returns>
        public override Boolean _Unload()
        {
            return base._Unload();
        }

        /// <summary>
        /// Método que se dispara cada vez que se actualiza a una Máster de Sgae 50
        /// </summary>
        /// <returns>true si se actualiza el módulo con éxito, false en caso contrario</returns>
        public override Boolean _Update()
        {
            return base._Update();
        }

        /// <summary>
        /// Método que se dispara cada vez que hay una actualización automática de librerías de Sage 50
        /// </summary>
        /// <returns></returns>
        public override bool _UpdateRelease()
        {
            return base._UpdateRelease();
        }

        /// <summary>
        /// Método que se dispara cuando el usuario desinstala el add-on en una instalación de Sage 50
        /// </summary>
        /// <param name="tcExecute">tipo ejecución (after o before)</param>
        /// <returns>true si ha sido correcto</returns>
	    public override bool _Desinstalar(TipoExecute tcExecute)
        {
            return base._Desinstalar(tcExecute);
        }

        /// <summary>
        /// Método que se dispara cuando el usuario instala el add-on en una instalación de Sage 50
        /// </summary>
        /// <param name="tcExecute">tipo ejecución (after o before)</param>
        /// <returns>true si ha sido correcto</returns>
	    public override bool _Instalar(TipoExecute tcExecute)
        {
            return base._Instalar(tcExecute);
        }

        /// <summary>
        /// Método que se dispara cada vez que se crea un nuevo ejercicio fiscal en Sage 50
        /// </summary>
        /// <param name="tcEjerAnt">ejercicio anterior</param>
        /// <param name="tcEjerActual">ejercicio actual</param>
        /// <returns>true si ha sido correcto</returns>
        public override bool _Apertura(string tcEjerAnt, string tcEjerActual)
        {
            return base._Apertura(tcEjerAnt, tcEjerActual);
        }

        #endregion MÉTODOS
    }
}
