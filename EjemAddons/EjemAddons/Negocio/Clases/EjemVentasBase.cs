using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sage.ew;
using sage.ew.global;
using sage.ew.ewbase;
using sage.ew.db;
using sage.ew.formul.Forms;
using sage.ew.interficies;
using sage.ew.articulo;
using System.Data;
using System.Windows.Forms;
using sage.ew.docsven;
using sage.ew.docventatpv;
using sage.ew.global.Diccionarios;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase base para las documentos de venta
    /// </summary>
    public class EjemVentasBase : _ExtensionDocVentaDocumento
    {
        protected string _cEjercicio = Convert.ToString(EW_GLOBAL._GetVariable("wc_any"));
        protected string _DataBaseAddon = "EJEMADDONS";
        protected bool _lCargarDocumento = false;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public EjemVentasBase()
        {
            // configuramos los parámetros mínimos que deben tener los documentos de venta a nivel de columnas
            _DataBase = _DataBaseAddon;
            _CampoEmpresa = "Empresa";
            _CampoNumero = "Numero";
            _CampoLetra = "Letra";
            _CampoLinea = "Linea";
            _Condicion = "Ejercicio = " + DB.SQLString(_cEjercicio);
            _TipoUpdate = TiposUpdate.DeleteInsert;
            _ExtensionDocsDocumentoLineaType = typeof(EjemVentasDetalleBase);
            // definimos las columnas
            DefColumnas();
            

        }

        /// <summary>
        /// Método virtual que permitimos configurar que columnas estarán presentes en el documento
        /// </summary>
        protected virtual void DefColumnas()
        {
            // añado el ejercicio
            _AddPropiedad("_Ejercicio", "Ejercicio");

            DefPropiedad loCampoX = _AddPropiedad("_Ancho", "Ancho", true);
            loCampoX._ColumnaGrid = new DefColumna();
            loCampoX._ColumnaGrid._Header = "Ancho";
            loCampoX._ColumnaGrid._NoPararEnColumna = false;
            loCampoX._ColumnaGrid._Visible = true;
            loCampoX._ColumnaGrid._TipoColumna = _TiposColumnaGrid.Número;
            loCampoX._ColumnaGrid._PosicionColumna = 5;
            loCampoX._ColumnaGrid._Width = 4;
            loCampoX._ColumnaGrid._MaxInputLength = 2;
            loCampoX._Traspasable = true;
            loCampoX._ColumnaGrid._Mascara = new ewMascara("99999");  
            loCampoX._ColumnaGrid._ReadOnly = false;

            DefPropiedad loCampoY = _AddPropiedad("_Alto", "Alto", true);
            loCampoY._ColumnaGrid = new DefColumna();
            loCampoY._ColumnaGrid._Header = "Alto";
            loCampoY._ColumnaGrid._NoPararEnColumna = false;
            loCampoY._ColumnaGrid._Visible = true;
            loCampoY._ColumnaGrid._TipoColumna = _TiposColumnaGrid.Número;
            loCampoY._ColumnaGrid._PosicionColumna = 6;
            loCampoY._ColumnaGrid._Width = 4;
            loCampoY._ColumnaGrid._MaxInputLength = 2;
            loCampoY._Traspasable = true;
            loCampoY._ColumnaGrid._Mascara = new ewMascara("99999");  
            loCampoY._ColumnaGrid._ReadOnly = false;

            DefPropiedad loCampoZ = _AddPropiedad("_Profundidad", "Profundidad", true);
            loCampoZ._ColumnaGrid = new DefColumna();
            loCampoZ._ColumnaGrid._Header = "Profund.";
            loCampoZ._ColumnaGrid._NoPararEnColumna = false;
            loCampoZ._ColumnaGrid._Visible = true;
            loCampoZ._ColumnaGrid._TipoColumna = _TiposColumnaGrid.Número;
            loCampoZ._ColumnaGrid._PosicionColumna = 7;
            loCampoZ._ColumnaGrid._Width = 4;
            loCampoZ._ColumnaGrid._MaxInputLength = 2;
            loCampoZ._Traspasable = true;
            loCampoZ._ColumnaGrid._Mascara = new ewMascara("99999");  
            loCampoZ._ColumnaGrid._ReadOnly = false;


        }

        /// <summary>
        /// Nos indica conforme el documento es traspasable
        /// </summary>
        /// <returns></returns>
        public override bool _IsTraspasable()
        {
            return true;
        }


        /// <summary>
        /// Se dispara cuando se cambia el valor de una columna
        /// </summary>
        /// <param name="teCampo"></param>
        /// <param name="toLinia"></param>
        /// <param name="toewCampo"></param>
        public override void _Camps_Lin_Change(sage.ew.docsven.CampsDocVentaLin teCampo, dynamic toLinia, ewCampo toewCampo)
        {
            if (_eBeforeAfter == TipoExecute.Before)
            {
                return;        
            }

            // obtengo la linea que estoy traspasando --> pedidos
            object loLinea = this._SearchLinea(this, toLinia);

            switch (teCampo)
            {
                case sage.ew.docsven.CampsDocVentaLin.Articulo:
                    // cambio de la columna ARTICULO
                    if (toewCampo._Changed())
                    {

                        EjemVentasDetalleBase loLineaExtension = _Get_Linea_Ext(toLinia);
                        if (!String.IsNullOrWhiteSpace(toewCampo._NewVal.ToString()))
                        {
                            loLineaExtension._LineaDocumento._Unidades = loLineaExtension._Ancho * loLineaExtension._Alto * loLineaExtension._Profundidad;
                        }
                    }
                    break;
            }

        }

    }


    /// <summary>
    /// Clase EjemVentasDetalleBase
    /// </summary>
    public class EjemVentasDetalleBase : _ExtensionDocVentaDocumentoLinea
    {
        /// <summary>
        /// Ejercicio
        /// </summary>
        private string _cEjercicio = EW_GLOBAL._GetVariable("wc_any").ToString();

        public string _Error_Message = "";

        /// <summary>
        /// Ejercicio
        /// </summary>
        /// 
        public string _Ejercicio
        {
            get { return _cEjercicio; }
            set
            {
                _SetValue(ref _cEjercicio, value, "_Ejercicio");
            }
        }

        
        public decimal _Ancho
        {
            get { return _nAncho; }
            set
            {
                _SetValue(ref _nAncho, value, "_Ancho");
                _Recalcular_Unidades();

            }
        }
        protected decimal _nAncho = 2;   

        public decimal _Alto
        {
            get { return _nAlto; }
            set
            {
                _SetValue(ref _nAlto, value, "_Alto");
                _Recalcular_Unidades();

            }
        }
        protected decimal _nAlto = 5;   

        public decimal _Profundidad
        {
            get { return _nProfundidad; }
            set
            {
                _SetValue(ref _nProfundidad, value, "_Profundidad");
                _Recalcular_Unidades();
            }
        }
        protected decimal _nProfundidad = 10;


        /// <summary>
        /// Recalcular unidades
        /// </summary>
        /// <returns></returns>
        public void _Recalcular_Unidades()
        {
            // Si está cargando no hacer nada
            if (_Parent._bIsLoading)
                return;

            // Si hay algun valor 0, no hacer nada
            if (_Ancho == 0 || _Alto == 0 || _Profundidad == 0)
                return;

            decimal lnUnits = _Ancho * _Alto * _Profundidad;

            if (lnUnits != this._LineaDocumento._Unidades)
                this._LineaDocumento._Unidades = lnUnits;

        }

    }
}
