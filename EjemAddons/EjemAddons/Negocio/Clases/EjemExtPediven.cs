using System;
using System.Collections.Generic;
using sage.ew.ewbase;
using sage.ew.interficies;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase extensión de pedidos de venta
    /// </summary>
    public class EjemExtPediven : EjemVentasBase
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EjemExtPediven():base()
        {
        }
        #endregion Constructor

        #region Métodos override
        /// <summary>
        /// Definición de las columnas
        /// </summary>
        protected override void DefColumnas()
        {
            _Tabla = "D_PEDV_MED";
            _ExtensionDocsDocumentoLineaType = typeof(ColumnasPedido);
            DefColumnasPedido();
        }

        /// <summary>
        /// Método virtual que permitimos configurar que columnas estarán presentes en el documento
        /// </summary>
        private void DefColumnasPedido()
        {
            base.DefColumnas();

            DefPropiedad loOrigen = _AddPropiedad("_Origen", "Origen", true);
            loOrigen._ColumnaGrid = new DefColumna();
            loOrigen._ColumnaGrid._Header = "Origen";
            loOrigen._ColumnaGrid._NoPararEnColumna = false;
            loOrigen._ColumnaGrid._Visible = true;
            loOrigen._ColumnaGrid._TipoColumna = _TiposColumnaGrid.Texto;
            loOrigen._ColumnaGrid._PosicionColumna = 8;
            loOrigen._ColumnaGrid._Width = 4;
            loOrigen._ColumnaGrid._MaxInputLength = 2;
            loOrigen._Traspasable = true;
            loOrigen._ColumnaGrid._ReadOnly = false;
        }

        /// <summary>
        /// Este evento se dispara después de vincular el mantegrid del documento
        /// </summary>
        public override void _Mantegrid_Vinculado()
        {
            base._Mantegrid_Vinculado();
        }

        /// <summary>
        /// Actualización de información al realizar el traspaso entre documentos
        /// </summary>
        /// <param name="toExtensionDestino">Extensión destino</param>
        /// <param name="toLineaOrigen">Línea de origen del documento</param>
        /// <param name="toLineaDestino">Línea destino del documento</param>
        /// <param name="tlVisualLayer">Indica si el traspaso de la información se realiza a través del formulario visual 'frmTraspaso'</param>
        /// <returns>Devuelve true si ha realizado la actualización</returns>
        public override bool _LineaToDocumento(IExtensionDocsDocumento toExtensionDestino, dynamic toLineaOrigen, dynamic toLineaDestino, bool tlVisualLayer = true)
        {
            if (_eBeforeAfter == TipoExecute.Before)
            {
                if ((toLineaOrigen == null) || (toLineaDestino == null) || (toExtensionDestino == null))
                    return true;

                bool llOk = false;
                string lcPropertyName;
                object loPropiedad, loPropiedadServ;
                _ExtensionDocumentoLinea loExtensionLineaDestino = null, loExtensionLineaOrigen = null;

                loExtensionLineaOrigen = this._SearchLinea(this, toLineaOrigen);
                if (loExtensionLineaOrigen == null)
                    return false;

                if (toLineaDestino is sage.ew.docsven.ewDocVentaLinDEPOSITO)
                {
                    llOk = false;
                }



                _ExtensionDocumento loExtensionDestino = (_ExtensionDocumento)toExtensionDestino;
                loExtensionLineaDestino = this._SearchLastLinea(loExtensionDestino); // En la extensión destino siempre buscamos la última línea
                if (loExtensionLineaDestino == null)
                    return false;

                sage.ew.docsven.ewDocVentaLinPED loLineaPed = (sage.ew.docsven.ewDocVentaLinPED)toLineaOrigen;

                sage.ew.docventatpv.ewDocVentaLinTPV loLineadestino = (sage.ew.docventatpv.ewDocVentaLinTPV)toLineaDestino;
                llOk = base._LineaToDocumento(toExtensionDestino, loLineaPed, loLineadestino, tlVisualLayer);

                if (toLineaDestino is sage.ew.docsven.ewDocVentaLinDEPOSITO)
                {
                    llOk = false;
                }

                if (llOk)
                    foreach (KeyValuePair<string, DefPropiedad> loPropietat in _DefPropiedades)
                    {
                        if (!string.IsNullOrWhiteSpace(loPropietat.Value._CampoTabla) && loPropietat.Value._ColumnaGrid != null) // Presentamos las columnas que son traspasables
                        {
                            if (loPropietat.Value._CampoTabla == "Unitstrasp")
                            {

                                lcPropertyName = "_Unitstrasp_Traspaso";
                                loPropiedad = loExtensionLineaOrigen._GetPropertyValue(lcPropertyName);
                                loExtensionLineaDestino._SetPropertyValue("_Units", loPropiedad);

                                decimal lnUnitsServ = Convert.ToDecimal(loPropiedad);
                                lnUnitsServ = lnUnitsServ - Convert.ToDecimal(loPropiedad);

                                // Actualizamos la extensión Destino - Pedido de venta
                                loExtensionLineaDestino._SetPropertyValue("_UnitsServ", lnUnitsServ);
                                loExtensionLineaDestino._SetPropertyValue("_Unitstrasp", 0.0M);

                                // Actualizamos la extensión Origen - Pediven
                                lcPropertyName = "_UnitsServ";
                                loPropiedadServ = loExtensionLineaOrigen._GetPropertyValue(lcPropertyName);
                                lnUnitsServ = Convert.ToDecimal(loPropiedadServ);
                                lnUnitsServ = lnUnitsServ + Convert.ToDecimal(loPropiedad);
                                loExtensionLineaOrigen._SetPropertyValue("_UnitsServ", lnUnitsServ);

                            }
                        }
                    }
            }            
            return true;
        }

        #endregion Métodos override
    }

    /// <summary>
    /// Columnas pedido
    /// </summary>
    public class ColumnasPedido : EjemVentasDetalleBase
    {
        /// <summary>
        /// Origen
        /// </summary>
        public string _Origen
        {
            get { return _nOrigen; }
            set
            {
                _SetValue(ref _nOrigen, value, "_Origen");
            }
        }
        protected string _nOrigen = "ex";

        /// <summary>
        /// Origen
        /// </summary>
        public string _Origen_Traspaso
        {
            get { return _nOrigenTraspaso; }
            set
            {
                _SetValue(ref _nOrigenTraspaso, value, "_Origen_Traspaso");
            }
        }
        protected string _nOrigenTraspaso = "";

        /// <summary>
        /// Ancho
        /// </summary>
        public decimal _Ancho_Traspaso
        {
            get { return _nAnchoTraspaso; }
            set
            {
                _SetValue(ref _nAnchoTraspaso, value, "_Ancho_Traspaso");
            }
        }
        protected Decimal _nAnchoTraspaso = 0.0M;

        /// <summary>
        /// Alto
        /// </summary>
        public decimal _Alto_Traspaso
        {
            get { return _nAltoTraspaso; }
            set
            {
                _SetValue(ref _nAltoTraspaso, value, "_Alto_Traspaso");
            }
        }
        protected Decimal _nAltoTraspaso = 0.0M;

        /// <summary>
        /// Profundidad
        /// </summary>

        public decimal _Profundidad_Traspaso
        {
            get { return _nProfundidadTraspaso; }
            set
            {
                _SetValue(ref _nProfundidadTraspaso, value, "_Profundidad_Traspaso");
            }
        }
        protected Decimal _nProfundidadTraspaso = 0.0M;

    }
}
