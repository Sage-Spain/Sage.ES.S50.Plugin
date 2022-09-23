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
            //loOrigen._ColumnaGrid._Mascara = ""new ewMascara("99999");
            loOrigen._ColumnaGrid._ReadOnly = false;
        }

        public override void _Mantegrid_Vinculado()
        {
            base._Mantegrid_Vinculado();
            //_Mantegrid._BeforeColChange += new ew.objetos.UserControls.Mantegrid._BeforeColChange_Handler(mantegridLinies__BeforeColChange);
            //_Mantegrid._Grid.CellBeginEdit += new DataGridViewCellCancelEventHandler(_Grid_CellBeginEdit);
            //_Mantegrid._Grid.CellEnter += _Grid_CellEnter;
            //_Mantegrid._Grid.CellFormatting += _Grid_CellFormatting;
            //_Mantegrid._KeyPress += new ew.objetos.UserControls.Mantegrid._KeyPress_Handler(_Grid_KeyPress);
        }
        
        public override bool _LineaToDocumento(IExtensionDocsDocumento toExtensionDestino, dynamic toLineaOrigen, dynamic toLineaDestino, bool tlVisualLayer = true)
        {
            // Con fecha 6/9/19, por este metodo solamente pasa una vez por tanto lo ejecutamos
            // cuando es Before, seria lo mismo no poner la condición , pero por si a caso

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

                                // Actualizamos la Extension Destino Pedido de venta
                                loExtensionLineaDestino._SetPropertyValue("_UnitsServ", lnUnitsServ);
                                loExtensionLineaDestino._SetPropertyValue("_Unitstrasp", 0.0M);

                                // Actualizamos la Extension Origen - Pediven
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
