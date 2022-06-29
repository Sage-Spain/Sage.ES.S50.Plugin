using sage.ew.formul;
using sage.ew.interficies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sage.addons.EjemAddons.Visual.BindForm
{
    /// <summary>
    /// Clase base para la gestión del BindForm de los formularios del Addon de Ejemplo
    /// </summary>
    public abstract class BindFormBase : IDisposable
    {
        #region Propiedades protected internal
        /// <summary>
        /// Referencia al formulario al que estamos realizando el correspondiente _BindForm
        /// La asignación se realiza en el constructor de la clase
        /// </summary>
        protected internal FormBase _oFormBase = null;
        #endregion Propiedades protected internal

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// 
        /// Mediente la instrucción "_oFormBase._AddBindFormClass(this)" se añade la instancia para su posterior liberación al realizarse el Dispose de la instancia 
        /// </summary>
        /// <param name="_toFormBase">Referencia al formulario al que estamos realizando el correspondiente _BindForm</param>
        public BindFormBase(IFormBase _toFormBase)
        {

            // Certificamos que el formulario donde se está realizando el BindForm es una instancia basasa en el formulario"FormBase"
            if (_toFormBase != null && _toFormBase is FormBase)
            {
                // Asignamos la referencia al formulario
                _oFormBase = (FormBase)_toFormBase;

                // Añadimos la instancia del objeto actual al diccionario BindFormClass, para la posterior liberación de memoria al salir del formulario
                // EJEMPLO _AddBindFormClass
                _oFormBase._AddBindFormClass(this);
            }

            // Llamamos al método _Init para poder gestionar eventos, añadir controles...
            _Init();

        }
        #endregion Constructor

        #region Métodos public virtual
        /// <summary>
        /// Método _Init para realizar los controles necesarios en la capa visual del formulario
        /// 
        /// Por ejemplo para añadir un control mediante la instrucción "_InsertarObjetoAddon" o la suscripción a los eventos necesarios
        /// </summary>
        public virtual void _Init()
        {
        }

        /// <summary>
        /// suscripción a los eventos necesarios
        /// 
        /// Será necesario realizar la llamada correspondiente a este método por ejemplo en el método _Init una vez realizadas las acciones necesarias como añadir o buscar controles.
        /// </summary>
        public virtual void _SuscripcionEventos()
        {
        }

        /// <summary>
        /// Cancelación a suscripción de los eventos para la correcta liberación de la memoria
        /// 
        /// A implementar en la clase derivada
        /// Se llamará a este método cuando se realice el Dispose
        /// </summary>
        public virtual void _CancelarSuscripcionEventos()
        {
        }

        /// <summary>
        /// Gestión del Dispose
        /// 
        /// Asignamos a null la referencia del formulario para poder liberar correctamente la memoria
        /// </summary>
        public virtual void Dispose()
        {
            _CancelarSuscripcionEventos();

            // Esta linea es muy importante liberar cualquier referencia del formulario con la clase actual y de este modo se podrá liberar la memoria correctamente
            _oFormBase = null;
        }
        #endregion Métodos public virtual
        
        #region Métodos protected internal
        /// <summary>
        /// Busca un control en el formulario de un tipo específico
        /// 
        /// Es importante indicar que el control ha de estar incluido en el Designer el formulario donde lo buscamos
        /// Si está en un formulario base es necesario realizar la búsqueda mediante _FindControl(string tcName)
        /// </summary>
        /// <typeparam name="T">Tipo de control a buscar</typeparam>
        /// <returns></returns>
        protected internal T _FindControl<T>()
        {
            T loControl = default(T);

            if (_oFormBase != null)
            {
                FormBase loFormBase = ((FormBase)_oFormBase);

                if (loFormBase.Controls.OfType<T>().Any())
                    loControl = loFormBase.Controls.OfType<T>().First();
            }

            return loControl;
        }

        /// <summary>
        /// Buscar un control en el formulario por nombre
        /// </summary>
        /// <param name="tcName">Nombre del control a buscar</param>
        /// <returns></returns>
        protected internal Control _FindControl(string tcName)
        {
            if (_oFormBase == null)
                return null;

            Control loControl = ((FormBase)_oFormBase)._FindControl(tcName);

            return loControl;
        }
        #endregion Métodos protected internal
    }
}
