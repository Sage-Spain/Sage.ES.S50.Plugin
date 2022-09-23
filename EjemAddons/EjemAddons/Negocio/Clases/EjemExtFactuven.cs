using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase extensión facturas de venta
    /// </summary>
    public class EjemExtFactuven : EjemVentasBase
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public EjemExtFactuven() : base()
        {
        }
        #endregion Constructor

        #region Métodos override

        /// <summary>
        /// Definición de las columnas
        /// </summary>
        protected override void DefColumnas()
        {
            this._Tabla = "D_ALBV_MED";
            this._ExtensionDocsDocumentoLineaType = typeof(EjemVentasDetalleBase);
            base.DefColumnas();
        }
        #endregion Métodos override
    }
}
