using System;
using sage.ew.ewbase;
using sage.ew.interficies;
using sage.ew.global;
using static sage.ew.docsven.Docsven;
using System.Data;
using sage.ew.db;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase extensión de albaranes de venta
    /// </summary>
    public class EjemExtAlbaven : EjemVentasBase
    {
        #region Propiedades 
        private string _cAny = EW_GLOBAL._GetVariable("wc_any").ToString();
        #endregion Propiedades

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EjemExtAlbaven() : base()
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


        /// <summary>
        /// Mantegrid vinculado
        /// </summary>
        public override void _Mantegrid_Vinculado()
        {
            base._Mantegrid_Vinculado();
        }

        /// <summary>
        /// Elimación de una línea
        /// </summary>
        /// <param name="toLineaDocumento"></param>
        /// <returns></returns>
        public override bool _Delete_Linea(IDocumentLinea toLineaDocumento)
        {
            string lcSql = "";
            decimal lnPiezas = 0.0M;
            string lcTablaDest = "";

            _ExtensionDocumentoLinea loLiniaAs = null;

            if (_eBeforeAfter == TipoExecute.Before)
            {
                return true;
            }

            bool deleted = true;

            if (!_Documento._BorrandoDocumento)
            {

                foreach (_ExtensionDocumentoLinea loLinia in _Lineas)
                {
                    if (object.Equals(loLinia._LineaDocumento, toLineaDocumento))
                    {
                        loLiniaAs = loLinia;
                        lnPiezas = Convert.ToDecimal(loLinia._GetPropertyValue("_Units"));
                        break;
                    }
                }
                ewDocVentaLin loLinAlb = (ewDocVentaLin)toLineaDocumento;


                switch (loLinAlb._Doc)
                {
                    case 1:    //  Origen pedidos de venta
                        lcTablaDest = "D_PEDV_MED";
                        break;

                    case 3:    //  Origen presupuestos
                        lcTablaDest = "D_PRES_MED";
                        break;
                }
                if (!string.IsNullOrWhiteSpace(lcTablaDest))
                {
                    string lcEmpresa = loLinAlb._Empresa;
                    string lcNumero = loLinAlb._Doc_Num.Substring(0, 10);
                    string lcLetra = loLinAlb._Doc_Num.Substring(10);
                    int lnLinea = loLinAlb._Doc_Lin;
                    decimal lnUnitServ = 0.0M;
                    DataTable ldtAlbaven = new DataTable();

                    lcSql = "Select UnitsServ From " + DB.SQLDatabase(_DataBaseAddon, lcTablaDest) +
                            " Where EJERCICIO = " + DB.SQLString(_cAny) +
                            " and empresa = " + DB.SQLString(lcEmpresa) +
                            " and numero = " + DB.SQLString(lcNumero) +
                            " and letra = " + DB.SQLString(lcLetra) +
                            " and linea = " + DB.SQLString(lnLinea);

                    if (!DB.SQLExec(lcSql, ref ldtAlbaven))
                        return false;

                    if (ldtAlbaven.Rows.Count > 0)
                    {
                        lnUnitServ = Convert.ToDecimal(ldtAlbaven.Rows[0]["UnitsServ"]);
                        lnUnitServ = lnUnitServ - lnPiezas;
                        lcSql = "Update " + DB.SQLDatabase(_DataBaseAddon, lcTablaDest) +
                                    " Set UnitsServ = " + DB.SQLString(lnUnitServ) +
                                    " Where EJERCICIO = " + DB.SQLString(_cAny) +
                                    " and empresa = " + DB.SQLString(lcEmpresa) +
                                    " and numero = " + DB.SQLString(lcNumero) +
                                    " and letra = " + DB.SQLString(lcLetra) +
                                    " and linea = " + DB.SQLString(lnLinea);

                        DB.SQLExec(lcSql);
                    }
                }
            }
            if (deleted)
            {
                deleted = base._Delete_Linea(toLineaDocumento);
            }
            return deleted;
        }

        /// <summary>
        /// Método que se ejecuta cuando el usuario carga en memoria un documento 
        /// </summary>
        /// <param name="tcEmpresa">empresa</param>
        /// <param name="tcNumero">número</param>
        /// <param name="tcClave3">clave3</param>
        /// <returns></returns>
        public override bool _Load(string tcEmpresa, string tcNumero, string tcClave3 = "")
        {
            return base._Load(tcEmpresa, tcNumero, tcClave3);
        }

        /// <summary>
        /// Método que se ejecuta cuando el usuario guarda un documento
        /// </summary>
        /// <param name="tbForzarGuardarLineas">Si se pasa true, guardará todas las líneas</param>
        /// <returns></returns>       
        public override bool _Save(bool tbForzarGuardarLineas = false)
        {
            return base._Save(tbForzarGuardarLineas);
        }

        /// <summary>
        /// Borrar el documento
        /// </summary>
        /// <returns></returns>
        public override bool _Delete()
        {
            bool deleted = true;
            string lcEmpresa, lcNumero, lcLetra, lcSql, lcTablaDest = "";
            int lnLinea;
            decimal lnUnitServ, lnPiezas = 0.0M;
            DataTable ldtPresuven;
            if (_Documento._BorrandoDocumento)
            {
                if (_eBeforeAfter == TipoExecute.Before)
                {
                    // 1.- _Mantegrid._Grid.DataSource 
                    //     es una vista del grid con todos los registros que vemos por pantalla.
                    // 2.- BindingList<ewDocVentaLinPED> lo = (BindingList<ewDocVentaLinPED>)_Mantegrid._Grid.DataSource
                    //     El objeto lo -> contendrá los registros del grid.
                    // 3.- _Lineas, tenemos las líneas de la extensión.
                    //  3.1 _ExtensionDocumentoLinea loLinia = (_ExtensionDocumentoLinea)_Lineas[i];
                    //  3.2 lnTipo = ((sage.ew.docsven.ewDocVentaLinPED)loLinia._LineaDocumento)._Doc
                    //  3.3 int lnTipo = loLinia._Documento._Lineas[i]._Doc;
                    // Las líneas 3.2 o 3.3 hacen lo mismo

                    for (int i = _Lineas.Count - 1; i > -1; i--)
                    {

                        _ExtensionDocumentoLinea loLinia = (_ExtensionDocumentoLinea)_Lineas[i];
                        lnPiezas = Convert.ToDecimal(loLinia._GetPropertyValue("_Units"));
                        int lnTipo = loLinia._Documento._Lineas[i]._Doc;
                        switch (lnTipo)
                        {
                            case 1:    //  Origen pedidos de venta
                                lcTablaDest = "D_PEDV_MED";
                                break;

                            case 3:    //  Origen presupuestos
                                lcTablaDest = "D_PRES_MED";
                                break;
                        }
                        if (!string.IsNullOrWhiteSpace(lcTablaDest))
                        {

                            lcEmpresa = loLinia._Documento._Lineas[i]._Empresa;
                            lcNumero = loLinia._Documento._Lineas[i]._Doc_Num.Substring(0, 10);
                            lcLetra = loLinia._Documento._Lineas[i]._Doc_Num.Substring(10);
                            lnLinea = loLinia._Documento._Lineas[i]._Doc_Lin;
                            lnUnitServ = 0.0M;
                            ldtPresuven = new DataTable();

                            lcSql = "Select UnitsServ From " + DB.SQLDatabase(_DataBaseAddon, lcTablaDest) +
                                    " Where EJERCICIO = " + DB.SQLString(_cAny) +
                                    " and empresa = " + DB.SQLString(lcEmpresa) +
                                    " and numero = " + DB.SQLString(lcNumero) +
                                    " and letra = " + DB.SQLString(lcLetra) +
                                    " and linea = " + DB.SQLString(lnLinea);

                            if (!DB.SQLExec(lcSql, ref ldtPresuven))
                                return false;

                            if (ldtPresuven.Rows.Count > 0)
                            {
                                lnUnitServ = Convert.ToDecimal(ldtPresuven.Rows[0]["UnitsServ"]);
                                lnUnitServ = lnUnitServ - lnPiezas;
                                lcSql = "Update " + DB.SQLDatabase(_DataBaseAddon, lcTablaDest) +
                                             " Set UnitsServ = " + DB.SQLString(lnUnitServ) +
                                             " Where EJERCICIO = " + DB.SQLString(_cAny) +
                                             " and empresa = " + DB.SQLString(lcEmpresa) +
                                             " and numero = " + DB.SQLString(lcNumero) +
                                             " and letra = " + DB.SQLString(lcLetra) +
                                             " and linea = " + DB.SQLString(lnLinea);

                                DB.SQLExec(lcSql);
                            }
                        }
                    }
                }

                if (deleted)
                {
                    deleted = base._Delete();
                }
            }
            return deleted;
        }

        #endregion Métodos override

    }
}
