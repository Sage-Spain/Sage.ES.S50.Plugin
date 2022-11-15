using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Sage50
using sage.ew.ewbase.Clases;
using sage.ew.ewbase.Forms;
using sage.ew.ewbase.UserControls;
using sage.ew.functions;
using sage.ew.global;

using sage.addons.EjemAddons.Visual.UserControls;

namespace sage.addons.EjemAddons.Visual.Forms
{
    /// <summary>
    /// Ejemplo de implementación de formulario asistente para ejecutar un proceso, por ejemplo, un proceso de importación a partir de
    /// un fichero (clientes, artículos, etc.).
    /// </summary>
    public partial class frmEjemAsistente : FormWizard
    {
        #region PROPIEDADES PRIVADAS


        /// <summary>
        /// Para saber cuando se ha finalizado el proceso de importación correctamente.
        /// </summary>
        private bool _lImportacionFinalizadaOk = false;


        /// <summary>
        /// Objeto de la clase de negocio al que esta vinculado el formulario asistente y sobre el cual se irán volcando los diferentes 
        /// configuraciones que vaya estableciendo el usuario en los diferentes pasos del asistente, para en el momento de la ejecución
        /// del proceso (usuario pulse el botón Empezar) tenga todo lo necesario para ejecutar el proceso. 
        /// 
        /// El proceso en sí también lo ejecutará esta clase.
        /// </summary>
        private Negocio.Clases.Importacion _oImportacion = new Negocio.Clases.Importacion();


        /// <summary>
        /// Referencia a la página activa del asistente en la que se encuentra el usuario en un momento dado. A medida que el usuario
        /// va pasando por las diferentes página esta referencia se va actualizando.
        /// </summary>
        private PaginaPasoWizard _oPagina = null;


        /// <summary>
        /// Referencia al backgroundworker relacionado con el asistente. 
        /// 
        /// Se utiliza internamente para ejecutar código cada vez que el usuario pulsa 'Siguiente' para avanzar a la siguiente página.
        /// También se utiliza para ejecutar el proceso del asistente en la página Proceso y también para cancelar la ejecución de dicho
        /// proceso mientras se está ejecutando.
        /// </summary>
        private BackgroundWorker _oWorker = null;


        /// <summary>
        /// Referencia al usercontrol que irá en la página inicial del asistente.
        /// </summary>
        private EjemAsistente_PaginaInicial _oUsrCtrlPagInicio = null;

        
        /// <summary>
        /// Referencia al usercontrol que irá en la página del paso 1 del asistente.
        /// </summary>
        private EjemAsistente_PaginaPaso1 _oUsrCtrlPagPaso1 = null;


        /// <summary>
        /// Referencia al usercontrol que irá en la página del paso 2 del asistente.
        /// </summary>
        private EjemAsistente_PaginaPaso1 _oUsrCtrlPagPaso2 = null;


        /// <summary>
        /// Referencia al usercontrol que irá en la página del paso 3 del asistente.
        /// </summary>
        private EjemAsistente_PaginaPaso1 _oUsrCtrlPagPaso3 = null;


        /// <summary>
        /// Referencia al usercontrol que irá en la página de ejecución del proceso del asistente.
        /// </summary>
        private EjemAsistente_PaginaProceso _oUsrCtrlPagProceso = null;

        
        /// <summary>
        /// Referencia al usercontrol que irá en la página final del asistente.
        /// </summary>
        private EjemAsistente_PaginaFinal _oUsrCtrlPagFinal = null;


        #endregion PROPIEDADES PRIVADAS


        #region CONSTRUCTOR


        /// <summary>
        /// Constructor del formulario asistente.
        /// </summary>
        public frmEjemAsistente()
        {
            // En función de si se permite ejecutar el proceso del asistente en empresas consolidadas, dejar o eliminar este control.
            //
            if (Convert.ToBoolean(EW_GLOBAL._GetVariable("wl_normal")) == false)
            {
                FUNCTIONS._MessageBox("Opción no disponible en una empresa consolidada.", "Proceso importación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            InitializeComponent();

            ConstructorLocal();

            return;
        }


        /// <summary>
        /// Configuraciones varias del formulario asistente.
        /// </summary>
        private void ConstructorLocal()
        {
            // Titulo que se mostrará en el asistente.
            //
            _Titulo = "Importación de datos";

            // Nombre de pantalla para poder dar o quitar accesos al formulario asistente.
            //
            _Pantalla = "ASIST_IMPORT";

            // Quitar opciones del botón ...
            //
            this._MostrarCrearAccesoDirecto = false;
            this._MostrarAccesoFavoritos = false;

            this.CenterToScreen();

            // Cargar configuración Asistente, si existe alguna configuración, se puede cargar en este punto.

            // Definir los pasos de que se componen el asistente.
            //
            DefinirPasosAsistente();

            return;
        }


        #endregion CONSTRUCTOR


        #region MÉTODOS PRIVADOS


        /// <summary>
        /// Método para la definición de todos los pasos del asistente.
        /// </summary>
        private void DefinirPasosAsistente()
        {
            PaginaPasoWizard loPag;

            // No dejar navegar desde el menú lateral izquierdo. 
            //
            this._PermitirNavegacionPasos = false;

            // Para indicar que al finalizar el asistente no se salga automaticámente de él sino que sea el usuario el que cierre
            // el formulario.
            //
            this._FinalizarSinSalir = true;

            // Para poder indicar que no queremos utilizar la barra de progreso del asistente (caso de utilizarse, aparecerá en la parte
            // izquierda inferior del asistente).
            //
            this._UtilizarBarraProgreso = false;  



            // DEFINICIÓN DE LAS PÁGINAS DEL ASISTENTE.
            //

            // 1. Definición página inicial.
            //
            loPag = new PaginaPasoWizard();
            
            // Nombre interno que le damos a la página, para poder diferenciarla de las otras y realizar programación en algún
            // evento según la página en que nos encontremos.
            //
            loPag._NombrePagina = "pgInicio";

            // Descripción corta de la página que aparece en la parte izquierda del formulario, en el esquema visual vertical en el que
            // se muestran los diferentes pasos del asistente. Utilizar unos 20 carácteres aproximádamente para este texto.
            //
            loPag._DescripcionPaso = "Descripción inicio";

            // Descripción larga de la página que aparece en la parte inferior izquierda de la página, al pie del esquema visual
            // de páginas.
            //
            loPag._DescripcionLargaPaso = "Asistente para la importación de datos";

            // Clase usercontrol que se colocará en esta página.
            //
            loPag._ClasePagina = "sage.addons.EjemAddons.Visual.UserControls.EjemAsistente_PaginaInicial";
            
            // Posibilidad de definir un video explicativo del funcionamiento del contenido de la página.
            //
            // Aparece en la parte inferior izquierda del asistente, debajo de la descripción larga, un link "Más información" el cual, 
            // al pulsarlo, se ejecuta una acción que se puede personalizar para cada página. Para ello, sobreescribir el método
            // el método _ShowVideo() en este mismo formulario.
            //
            loPag._Video = "http://www.sage.es";

            _ListaPaginas.Add(loPag);

            
            // 2. Definición página paso 1 del asistente.
            //
            loPag = new PaginaPasoWizard();
            loPag._NombrePagina = "pgPaso1";
            loPag._DescripcionPaso = "Descripción paso 1";
            loPag._DescripcionLargaPaso = "Descripción detallada del paso 1.";
            loPag._ClasePagina = "sage.addons.EjemAddons.Visual.UserControls.EjemAsistente_PaginaPaso1";
            loPag._Video = "";
            _ListaPaginas.Add(loPag);


            // 3. Definición página paso 2 del asistente.
            //
            loPag = new PaginaPasoWizard();
            loPag._NombrePagina = "pgPaso2";
            loPag._DescripcionPaso = "Descripción paso 2";
            loPag._DescripcionLargaPaso = "Descripción detallada del paso 2.";
            loPag._ClasePagina = "sage.addons.EjemAddons.Visual.UserControls.EjemAsistente_PaginaPaso2";
            loPag._Video = "";
            _ListaPaginas.Add(loPag);


            // 4. Definición página paso 3 del asistente.
            //
            loPag = new PaginaPasoWizard();
            loPag._NombrePagina = "pgPaso3";
            loPag._DescripcionPaso = "Descripción paso 3";
            loPag._DescripcionLargaPaso = "Descripción detallada del paso 3.";
            loPag._ClasePagina = "sage.addons.EjemAddons.Visual.UserControls.EjemAsistente_PaginaPaso3";
            loPag._Video = "";
            _ListaPaginas.Add(loPag);


            // 5. Definición página proceso del asistente en la que el usuario pulsará el botón Empezar que le aparecerá, y en la
            // que se irá visualizando información mientras se va ejecutando el proceso incluida alguan progresbar si el programador
            // lo desea.
            //
            loPag = new PaginaPasoWizard();
            loPag._NombrePagina = "pgProceso";
            loPag._DescripcionPaso = "Importación de datos";
            loPag._DescripcionLargaPaso = "Ejecución proceso de importación de datos.";
            loPag._ClasePagina = "sage.addons.EjemAddons.Visual.UserControls.EjemAsistente_PaginaProceso";
            loPag._Video = "";
            _ListaPaginas.Add(loPag);


            // 6. Definición página final del asistente con un resumen de la ejecución del proceso.
            //
            loPag = new PaginaPasoWizard();
            loPag._NombrePagina = "pgFinal";
            loPag._DescripcionPaso = "Fin proceso.";
            loPag._DescripcionLargaPaso = "Proceso de importación finalizado.";
            loPag._ClasePagina = "sage.addons.EjemAddons.Visual.UserControls.EjemAsistente_PaginaFinal";
            loPag._Video = "";
            loPag._MostrarResumen = true;
            _ListaPaginas.Add(loPag);

            return;
        }


        /// <summary>
        /// Método para la carga de la página Inicial del asistente.
        /// 
        /// Solo se ejecuta la primera vez que se carga la pagina Inicial, una vez añadido el usercontrol a la página por la clase base
        /// de este formulario, y se utiliza para realizar cualquier configuración adicional en las propiedades del usercontrol que se ha
        /// añadido o cualquier otra acción que requiera realizar una vez añadido el usercontrol a la página.
        /// </summary>
        /// <param name="toControl">Objeto usercontrol que se ha añadido a la página Inicial.</param>
        /// <returns></returns>
        private bool LoadPaginaInicio(object toControl)
        {
            return true;
        }


        /// <summary>
        /// Método para la carga de la página Paso 1 del asistente.
        /// 
        /// Solo se ejecuta la primera vez que se carga la pagina Paso 1, una vez añadido el usercontrol a la página por la clase base
        /// de este formulario, y se utiliza para realizar cualquier configuración adicional en las propiedades del usercontrol que se ha
        /// añadido o cualquier otra acción que requiera realizar una vez añadido el usercontrol a la página.
        /// </summary>
        /// <param name="toControl">Objeto usercontrol que se ha añadido a la página Paso 1.</param>
        /// <returns></returns>
        private bool LoadPaginaPaso1(object toControl)
        {
            return true;
        }


        /// <summary>
        /// Método para la carga de la página Paso 2 del asistente.
        /// 
        /// Solo se ejecuta la primera vez que se carga la pagina Paso 2, una vez añadido el usercontrol a la página por la clase base
        /// de este formulario, y se utiliza para realizar cualquier configuración adicional en las propiedades del usercontrol que se ha
        /// añadido o cualquier otra acción que requiera realizar una vez añadido el usercontrol a la página.
        /// </summary>
        /// <param name="toControl">Objeto usercontrol que se ha añadido a la página Paso 2.</param>
        /// <returns></returns>
        private bool LoadPaginaPaso2(object toControl)
        {
            return true;
        }


        /// <summary>
        /// Método para la carga de la página Paso 3 del asistente.
        /// 
        /// Solo se ejecuta la primera vez que se carga la pagina Paso 3, una vez añadido el usercontrol a la página por la clase base
        /// de este formulario, y se utiliza para realizar cualquier configuración adicional en las propiedades del usercontrol que se ha
        /// añadido o cualquier otra acción que requiera realizar una vez añadido el usercontrol a la página.
        /// </summary>
        /// <param name="toControl">Objeto usercontrol que se ha añadido a la página Paso 3.</param>
        /// <returns></returns>
        private bool LoadPaginaPaso3(object toControl)
        {
            return true;
        }


        /// <summary>
        /// Método para la carga de la página Proceso del asistente.
        /// 
        /// Solo se ejecuta la primera vez que se carga la pagina Proceso, una vez añadido el usercontrol a la página por la clase base
        /// de este formulario, y se utiliza para realizar cualquier configuración adicional en las propiedades del usercontrol que se ha
        /// añadido o cualquier otra acción que requiera realizar una vez añadido el usercontrol a la página.
        /// </summary>
        /// <param name="toControl">Objeto usercontrol que se ha añadido a la página Proceso.</param>
        /// <returns></returns>
        private bool LoadPaginaProceso(object toControl)
        {
            // Guardamos en el formulario asistente referencia al usercontrol de la página proceso del asistente.
            //
            _oUsrCtrlPagProceso = (EjemAsistente_PaginaProceso)toControl;

            // Configuramos propiedades del usercontrol de la página proceso del sistema.
            //
            _oUsrCtrlPagProceso._Importacion = _oImportacion;

            return true;
        }


        /// <summary>
        /// Método para la carga de la página Final del asistente.
        /// 
        /// Solo se ejecuta la primera vez que se carga la pagina Final, una vez añadido el usercontrol a la página por la clase base
        /// de este formulario, y se utiliza para realizar cualquier configuración adicional en las propiedades del usercontrol que se ha
        /// añadido o cualquier otra acción que requiera realizar una vez añadido el usercontrol a la página.
        /// </summary>
        /// <param name="toControl">Objeto usercontrol que se ha añadido a la página Final.</param>
        /// <returns></returns>
        private bool LoadPaginaFinal(object toControl)
        {
            return true;
        }


        /// <summary>
        /// Método para realizar acciones al salir de la página Inicio del asistente.
        /// </summary>
        /// <returns></returns>
        private bool SavePaginaInicio()
        {
            return true;
        }

        /// <summary>
        /// Método para realizar acciones al salir de la página Paso 1 del asistente.
        /// </summary>
        /// <returns></returns>
        private bool SavePaginaPaso1()
        {
            return true;
        }


        /// <summary>
        /// Método para realizar acciones al salir de la página Paso 2 del asistente.
        /// </summary>
        /// <returns></returns>
        private bool SavePaginaPaso2()
        {
            return true;
        }


        /// <summary>
        /// Método para realizar acciones al salir de la página Paso 3 del asistente.
        /// </summary>
        /// <returns></returns>
        private bool SavePaginaPaso3()
        {
            return true;
        }


        /// <summary>
        /// Método para realizar acciones al salir de la página Proceso del asistente.
        /// </summary>
        /// <returns></returns>
        private bool SavePaginaProceso()
        {
            return true;
        }


        /// <summary>
        /// Método para realizar acciones al salir de la página Final del asistente.
        /// </summary>
        /// <param name="tnIndex"></param>
        /// <returns></returns>
        private bool SavePaginaFinal(int tnIndex)
        {
            return true;
        }


        #endregion MÉTODOS PRIVADOS


        #region MÉTODOS PROTECTED OVERRIDE


        /// <summary>
        /// Evento que se ejecuta para refrescar la barra de progreso al recibir las notificaciones de progreso mediante 
        /// backgroundworker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void _BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            base._BackgroundWorker_ProgressChanged(sender, e);

            if (_oUsrCtrlPagProceso != null)
            {
                _oUsrCtrlPagProceso._TextProgreso = _oImportacion._TextStep;
                _oUsrCtrlPagProceso._BarraProgreso = e.ProgressPercentage;
                _oUsrCtrlPagProceso._TextoDetalle = _oImportacion._TextStepDetalle;
            }

            return;
        }


        /// <summary>
        /// Método que se ejecuta tan pronto se pulsa el botón Anterior, Siguiente o el Empezar/Finalizar, y posteriormente a la acción que 
        /// provoca la pulsación del botón, es decir, se ejecuta 2 veces para cada pulsación de estos botones, una antes y otra después de la
        /// ejecución de la acción que provoca el botón.
        /// 
        /// En particular sirve para cambiar el texto del botón Empezar/Finalizar si se ha llegado a la página de ejecución del proceso
        /// o a la página de resumen final de ejecución del proceso (posterior a la página de ejecución del proceso), caso de que se haya
        /// configurado la existencia de esta página resumen final.
        /// </summary>
        /// <param name="teOrigen">
        /// Origen de la llamada al método. En función de la enumeración eOrigenRevisarControles por ejemplo AnteriorInicio (justo después de 
        /// pulsar el botón Anterior), AnteriorFin (después de pulsar el botón anterior una vez se ha cambiado a la página anterior, 
        /// SiguienteInicio (justo después de pulsar el botón Siguiente), SiguienteFinFail (después de pulsar el botón Siguiente y haber 
        /// fallado la acción que desencadena en la página actual el botón, SiguienteFinOk (después de pulsar el botón Siguiente y haber 
        /// finalizado Ok la acción que desenecadena en la página actual el botón, ... y otros valores más de la enumeración.
        /// </param>
        /// <param name="toPagina">Página activa en este instante, según el valor del parámetro teOrigen la página activa podra ser la
        /// actual, o la siguiente/anterior que toque como consecuencia de pulsar el botón.</param>
        protected override void _RevisarControles(eOrigenRevisarControles teOrigen, PaginaPasoWizard toPagina)
        {
            if (toPagina._NombrePagina == "pgProceso" && teOrigen == eOrigenRevisarControles.SiguienteFinOk)
            {
                // Pasará por aquí cuando se haya pulsado el botón Siguiente, se haya realizado la acción que corresponda y quedemos
                // situados en la página pgProceso.
                //
                _RevisarEstadoControl(eControlesRevisar.BotonFinalizar, eControlesRevisarPropiedades.Text, "Empezar");
                _RevisarEstadoControl(eControlesRevisar.BotonFinalizar, eControlesRevisarPropiedades._Tooltip, "Empezar importación");
            }

            if (toPagina._NombrePagina == "pgFinal" && teOrigen == eOrigenRevisarControles.FinalizarFinOk)
            {
                // Pasará por aquí cuando hayamos pulsado el botón de Empezar (que es realmente el mismo botón que el botón Finalizar),
                // se haya realizado la acción y quedemos situado en la página final de resumen. En función de si el proceso se ejecutó
                // OK o no, habilitamos unos botones u otros.
                //
                if (_lImportacionFinalizadaOk)
                {
                    // Proceso finalizao correctamente, cambio el texto del botón por Finalizar y lo dejo como unica opción, ya no 
                    // puede pulsar ni Cancelar, ni Anterior. Siguiente ya no podía por el hecho de estar en la página de proceso o resumen.
                    //
                    _RevisarEstadoControl(eControlesRevisar.BotonFinalizar, eControlesRevisarPropiedades.Text, "Finalizar");
                    _RevisarEstadoControl(eControlesRevisar.BotonFinalizar, eControlesRevisarPropiedades._Tooltip, "Finalizar");
                    _RevisarEstadoControl(eControlesRevisar.BotonAnterior, eControlesRevisarPropiedades.Enabled, false);
                    _RevisarEstadoControl(eControlesRevisar.BotonCancelar, eControlesRevisarPropiedades.Enabled, false);
                }
                else
                {
                    // Proceso finalizao incorrectamente, aseguro el texto del botón a "Empezar" y permito Cancelar el asistente o ir a
                    // un paso anterior.
                    //
                    _RevisarEstadoControl(eControlesRevisar.BotonFinalizar, eControlesRevisarPropiedades.Text, "Empezar");
                    _RevisarEstadoControl(eControlesRevisar.BotonFinalizar, eControlesRevisarPropiedades._Tooltip, "Empezar importación");
                    _RevisarEstadoControl(eControlesRevisar.BotonAnterior, eControlesRevisarPropiedades.Enabled, true);
                    _RevisarEstadoControl(eControlesRevisar.BotonCancelar, eControlesRevisarPropiedades.Enabled, true);
                }
            }

            return;
        }


        /// <summary>
        /// Método que se dispara al cargar una nueva página en el asistente. 
        /// 
        /// Solo se ejecuta la primera vez que se carga la pagina, las siguientes veces que se accede a la página (pulsando el botón 
        /// Anterior p.e.) ya no pasa por aquí por que la página ya ha sido cargada con anterioridad y internamente lo único que hace es 
        /// situarse en la página que toca.
        /// </summary>        
        /// <param name="tcNombrePagina">Nombre de la página del asistente en la que cargar el usercontrol respectivo de la página.</param>        
        /// <param name="toControl">Referencia al UserControl asociado a la página del asistente que se pretende cargar.</param> 
        /// <returns></returns>
        protected override bool _LoadWizardPage(string tcNombrePagina, object toControl)
        {
            bool llOk = true;

            // En función del nombre de la página llamamos al método respectivo donde el programador podrá colocar código para realizar
            // acciones adicionales en la página que se esté cargando.
            //
            // Recordar que la acción de colocar el usercontrol de la página en la página correspondiente ya la hace la clase base sobre
            // la que se basa este formulario, el programador se despreocupa de eso, este método es sólamente para ejecutar acciones
            // adicionales que se quieren realizar en el usercontrol una vez se ha colocada en la página contenedora del mismo.
            // 
            switch (tcNombrePagina)
            {
                case "pgInicio":
                    llOk = LoadPaginaInicio(toControl);
                    break;

                case "pgPaso1":
                    llOk = LoadPaginaPaso1(toControl);
                    break;

                case "pgPaso2":
                    llOk = LoadPaginaPaso2(toControl);
                    break;

                case "pgPaso3":
                    llOk = LoadPaginaPaso3(toControl);
                    break;

                case "pgProceso":
                    llOk = LoadPaginaProceso(toControl);
                    break;

                case "pgFinal":
                    llOk = LoadPaginaFinal(toControl);
                    break;

                default:
                    break;
            }

            return llOk;
        }


        /// <summary>
        /// Para poder ejecutar código al final de la carga de las distintas páginas del asistente.
        /// 
        /// Al igual que el método _LoadWizardPage() este método _LoadWizardPageAfter() solo se ejecuta cuando se carga la página por 
        /// primera vez, las siguientes veces ya no.
        /// </summary>
        /// <param name="tcNombrePagina">Nombre de la página del asistente en la que se ha cargado el usercontrol respectivo de la página.</param>        
        /// <param name="toControl">Referencia al UserControl asociado a la página del asistente que se ha cargado.</param> 
        /// <returns></returns>
        protected override bool _LoadWizardPageAfter(string tcNombrePagina, object toControl)
        {
            bool llOk = true;

            // En función del nombre de la página el programador podrá colocar el código que corresponda a posteriori de cargar la página.
            //       
            switch (tcNombrePagina)
            {
                case "pgInicio":
                    break;

                case "pgPaso1":
                    break;

                case "pgPaso2":
                    break;

                case "pgPaso3":
                    break;

                case "pgProceso":
                    break;

                case "pgFinal":
                    break;

                default:
                    break;
            }

            return llOk;
        }


        /// <summary>
        /// Método que se dispara al clickar en el botón Siguiente, para realizar las validaciones pertinentes antes de pasar a la 
        /// siguiente página, o cualquier otra acción que interese realizar previamente al siguiente paso. 
        /// 
        /// Solo se ejecuta en los páginas del asistente anteriores a la página que ejecuta el proceso del asistente.
        /// </summary>       
        /// <param name="toPagina">Pagina del asistente que se trata de abandonar cuando se ha pulsado el botón Siguiente.</param>
        /// <param name="toWorker">Objeto BackgroundWorker.</param>
        /// <returns></returns>
        protected override bool _SaveWizardPage(PaginaPasoWizard toPagina, BackgroundWorker toWorker)
        {
            bool llOk = true;
            Int32 lnIndex = 0;

            if (toPagina._ControlPagina == null)
                return true;

            // Asigmanos parámetros a nuestras propiedades privadas.
            // 
            _oPagina = toPagina;
            _oWorker = toWorker;

            if (_oPagina._ControlPagina is MultiPagesWizard) 
                lnIndex = ((MultiPagesWizard)_oPagina._ControlPagina)._Index;

            // Realizar las acciones y validaciones pertinentes antes de pasar a la siguiente página, o cualquier otra acción que
            // interese realizar previamente al siguiente paso.
            //
            // Si en alguna página no se cumplen las condiciones necesarias para pasar al siguiente paso, el método llamado para
            // validar la página deberá devolver false.
            //
            string lcPagina = toPagina._NombrePagina;
            
            switch (lcPagina)
            {
                case "pgInicio":
                    llOk = SavePaginaInicio();
                    break;

                case "pgPaso1":
                    llOk = SavePaginaPaso1();
                    break;

                case "pgPaso2":
                    llOk = SavePaginaPaso2();
                    break;

                case "pgPaso3":
                    llOk = SavePaginaPaso3();
                    break;

                default:
                    break;
            }

            return llOk;
        }


        /// <summary>
        /// Método que se dispara al cancelar en cualquier momento el asistente antes de la finalización del mismo.
        /// 
        /// Si pulsa el botón 'Cancelar' se pregunta al usuario si quiere abandonar el asistente y si selecciona SÍ, se ejecuta este 
        /// método.
        /// </summary>
        /// <param name="toWorker">Objeto BackgroundWorker asociado.</param>
        /// <returns></returns>
        protected override bool _CancelWizard(BackgroundWorker toWorker)
        {
            // Cancelar worker del Cancelar.
            //
            toWorker.WorkerSupportsCancellation = true;
            toWorker.CancelAsync();

            // Cancelar worker del Finalizar.
            //
            if (_oWorker != null)
            {
                _oWorker.WorkerSupportsCancellation = true;
                _oWorker.CancelAsync();
            }

            return true;
        }


        /// <summary>
        /// Acción a ejecutar al hacer click sobre el link "Más información" que aparece en la parte inferior izquierda del asistente
        /// en un determinado paso del mismo, cuando el programador ha definido para aquel paso la propiedad _Video.
        /// 
        /// Esta acción puede ser mostrar una URL de un video o cualquier otra cosa que decida el programador.
        /// </summary>
        /// <param name="tcNombrePagina">Nombre de la página del asistente en la que está situado el usuario cuanado hace click sobre 'Más información'.</param>
        /// <param name="tcKeyLink">URL del video correspondiente, opcional.</param>
        /// <returns></returns>
        protected override bool _ShowVideo(String tcNombrePagina, String tcKeyLink)
        {
            switch (tcNombrePagina)
            {
                case "pgInicio":
                    System.Diagnostics.Process.Start(tcKeyLink);
                    break;
            }

            return true;
        }


        /// <summary>
        /// Este método se dispara cuando se pulsa el botón "Empezar" para ejecutar el proceso que haya definido en el asistente, y
        /// caso de que el asistente tenga definido una página final de resumen, también al pulsar el botón "Finalizar" en dicha página
        /// de resumen.
        /// </summary>
        /// <param name="toPagina">Página en la que se encuentra el usuario cuando se pulsa el botón Empezar/Finalizar (es el mismo 
        /// botón con diferente texto).<param>
        /// <param name="toWorker">Objeto bakgroundworder que está ejecutando el proceso.</param>
        /// <returns></returns>
        protected override bool _FinishWizard(PaginaPasoWizard toPagina, BackgroundWorker toWorker)
        {
            if (toPagina._ControlPagina == null)
                return true;

            _oWorker = toWorker;

            if (_lImportacionFinalizadaOk)
            {
                _FinalizarSinSalir = false;
            }
            else
            {

                // Ejecutar proceso del asistente.
                //
                _lImportacionFinalizadaOk = _oImportacion._Importar(toWorker);
                if (toWorker.CancellationPending)
                    return true;

                if (_lImportacionFinalizadaOk)
                    _ListaPaginas[_PaginaActiva]._Paso._Estado = PasoWizard.Estado.Terminado;
            }

            return _lImportacionFinalizadaOk;
        }


        #endregion MÉTODOS PROTECTED OVERRIDE
    }
}
