using sage.ew.db;
using sage.ew.docsven.UserControls;
using sage.ew.formul;
using sage.ew.functions;
using sage.ew.interficies;
using sage.ew.txtbox.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sage.addons.EjemAddons.Visual.BindForm
{
    /// <summary>
    /// Clase para realizar modificaciones y gestionar eventos a un txtcodlabel, en esta se realiza sobre el txtserie
    /// 
    /// Se ha implementado que, cuando el usuario:
    /// - Presente el browser aparecerá una nueva columna llamada "Add-on" y el texto será "Columna creada con el add-on de ejemplo:  código de la serie"
    /// - Modifique el valor presentará un mensaje con el nuevo valor.
    ///    
    /// </summary>
    public class BindFormAlltxtSerie : BindFormBase
    {
        #region Propiedades privadas

        /// <summary>
        /// Lista de formularios que no debe realizar la búsqueda del txtserie
        /// </summary>
        List<string> _lstFormulariosExcluidos = new List<string> { "frmprincipal", "frmthumbnaildesktop", "messageboxtactil", "frmbrowser", "frmletras" };

        #endregion Propiedades privadas

        #region Constructor

        /// <summary>
        /// Constructor de la clase BindFormAlltxtSerie
        /// </summary>
        /// <param name="toFormBase">Referencia al formulario al que estamos realizando el correspondiente _BindForm</param>
        public BindFormAlltxtSerie(IFormBase toFormBase) : base(toFormBase)
        {
        }

        #endregion Constructor

        #region Métodos public override
        
        /// <summary>
        /// Suscripción a los eventos para gestionar
        /// </summary>
        public override void _Init()
        {
            base._Init();
          
            FindAllTxtSerie();          
        }      
                
        #endregion Métodos public override

        #region Métodos privados

        /// <summary>
        /// Método que valida si a este formulario queremos realizar las modificaciones 
        /// </summary>
        private void FindAllTxtSerie()
        {
            if (!EsFormularioExcluido(_oFormBase)) 
                SuscripcionEventosSerie(_oFormBase, (FormBase)_oFormBase);
        }

        /// <summary>
        /// Método que valida si el formulario no se encuentra a la lista que se ha definido entonces buscamos los txtserie
        /// </summary>        
        /// <param name="toFormBase"></param>
        /// <returns></returns>
        private bool EsFormularioExcluido(IFormBase toFormBase)
        {
            string lcNombre = ((FormBase)_oFormBase).Name.ToLower(); //nombre formulario

            if (toFormBase == null || _lstFormulariosExcluidos.Contains(lcNombre))
                return true;

            return false;
        }

        /// <summary>
        /// Asignación de eventos
        /// </summary>
        /// <param name="toFormBase"></param>
        /// <param name="toControl"></param>
        private void SuscripcionEventosSerie(IFormBase toFormBase, Control toControl)
        {
            if (toFormBase == null || toControl == null)
                return;

            AsignarEventosTxt(toFormBase, toControl, true);  //Suscripción al evento txtserie
            AsignarEventosTab(toFormBase, toControl, true);  //Suscripción a las TabControl

            ((FormBase)toFormBase).FormClosing += (sender, e) => FormBase_FormClosing(sender, e, toFormBase, toControl); //Nos sucribimos al formclosing para cancelar los eventos
        }

        /// <summary>
        /// Cancelar eventos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormBase_FormClosing(object sender, FormClosingEventArgs e, IFormBase toFormBase, Control toControl)
        {
            if (toFormBase == null || toControl == null)
                return;

            CancelarEventos(toFormBase, toControl);
        }

        /// <summary>
        /// Cancelamos eventos
        /// </summary>
        /// <param name="toFormBase"></param>
        /// <param name="toControl"></param>
        private void CancelarEventos(IFormBase toFormBase, Control toControl)
        {
            if (toFormBase == null || toControl == null)
                return;

            AsignarEventosTxt(toFormBase, toControl, false);
            AsignarEventosTab(toFormBase, toControl, false);

            List<TabControl> lstControls = ((FormBase)toFormBase)._FindControl<TabControl>();
            if (lstControls.Count > 0)
            {
                foreach (TabControl control in lstControls)
                {
                    List<TabPage> lstPaginas = ((FormBase)toFormBase)._FindControl<TabPage>(control);
                    if (lstPaginas.Count > 0)
                    {
                        foreach (TabPage pagina in lstPaginas)
                            AsignarEventosTxt(((FormBase)toFormBase), pagina, false);
                    }
                    lstPaginas?.Clear();
                    lstPaginas = null;
                }
            }
            lstControls?.Clear();
            lstControls = null;
        }

        /// <summary>
        /// Asignar/Cancelar eventos a txtserie, txtnumdocven y txtfacturadoc
        /// En todos los formularios hay el txtserie menos en los documentos de venta que nos encontramos el txnumdocven y
        /// en las facturas de venta el txtfacturadoc
        ///        
        /// </summary>
        /// <param name="toFormBase">formulario</param>
        /// <param name="toControl">Control</param>
        /// <param name="tlSuscribirse">si es true nos suscribimos, si es false cancelamos el evento</param>
        private void AsignarEventosTxt(IFormBase toFormBase, Control toControl, bool tlSuscribirse)
        {
            if (toFormBase == null || toControl == null)
                return;

            //Utilizando el _FindControl buscamos el txtserie que hay en el formulario y nos devuelve una lista con todos los txtserie que tiene
            List<txtSerie> lstTxtSerie = ((FormBase)toFormBase)._FindControl<txtSerie>(toControl);

            if (lstTxtSerie.Count > 0)
            {
                foreach (txtSerie serie in lstTxtSerie)
                {
                    if (tlSuscribirse)
                    {
                        //Modifico el browser para añadir una columna nueva y con su valor
                        serie._Browser_Titulos_Campos += ",Add-on";
                        serie._Browser_Campos += "," + DB.SQLString("Columna creada con el add-on de ejemplo: ") + " + codigo as addon";

                        //Nos suscribimos al codigo cambiado
                        serie._Codigo_Cambiado_Before_Extended += Serie__Codigo_Cambiado_Before_Extended;                      
                    }
                    else
                    {
                        //Nos desuscribimos 
                        serie._Codigo_Cambiado_Before_Extended -= Serie__Codigo_Cambiado_Before_Extended;
                    }
                }
            }

            //Buscamos utilizando el _FindControl el txtnumdocven para asignar/cancelar los eventos que nos interesen
            List<txtNumDocVen> lstTxtNumDocVen = ((FormBase)toFormBase)._FindControl<txtNumDocVen>(toControl);
            if (lstTxtNumDocVen.Count > 0)
            {
                foreach (txtNumDocVen numdocven in lstTxtNumDocVen)
                {
                    if (tlSuscribirse)
                        numdocven._onLetraCambiadoBefore += Documento__onLetraCambiadoBefore;
                    else
                        numdocven._onLetraCambiadoBefore -= Documento__onLetraCambiadoBefore;
                }
            }

            //Buscamos utilizando el _FindControl el txtFacturaDoc para asignar/cancelar los eventos que nos interesen
            List<txtFacturaDoc> lstTxtFacturaDoc = ((FormBase)toFormBase)._FindControl<txtFacturaDoc>(toControl);
            if (lstTxtFacturaDoc.Count > 0)
            {
                foreach (txtFacturaDoc factura in lstTxtFacturaDoc)
                {
                    if (tlSuscribirse)
                        factura._onLetraCambiadoBefore += Documento__onLetraCambiadoBefore;
                    else
                        factura._onLetraCambiadoBefore -= Documento__onLetraCambiadoBefore;
                }
            }

        }

        /// <summary>
        ///  Asignar/Cancelar evento a la creación del TabControl        
        /// </summary>
        /// <param name="toFormBase"></param>
        /// <param name="toControl"></param>
        /// <param name="tlSuscribirse"></param>
        /// <returns></returns>
        private bool AsignarEventosTab(IFormBase toFormBase, Control toControl, bool tlSuscribirse)
        {
            if (toFormBase == null || toControl == null)
                return true;

            List<TabControl> lstTabControl = ((FormBase)toFormBase)._FindControl<TabControl>(toControl);
            if (lstTabControl.Count > 0)
            {
                foreach (TabControl control in lstTabControl)
                {
                    if (AsignarEventosTab(toFormBase, control, tlSuscribirse))
                    {
                        if (tlSuscribirse)
                        {
                            control.HandleCreated -= Control_HandleCreated;
                            control.HandleCreated += Control_HandleCreated;
                        }
                        else
                            control.HandleCreated -= Control_HandleCreated;
                    }
                }
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Con el objetivo de optimizar la carga de los mantenimientos, cuando se carga, solo está creada la primera página y a medida que se va accediendo
        /// a las otras páginas se van cargando, por este motivo, cuando vamos a un mantenimiento en el momento de crear la página es cuando
        /// debe buscar si hay algún txtserie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_HandleCreated(object sender, EventArgs e)
        {
            TabControl loControl = (TabControl)sender;
            Tabpages((IFormBase)loControl.TopLevelControl, loControl, true, true);
        }

        /// <summary>
        /// Asignar evento a la creación del TabPage
        /// </summary>
        /// <param name="toFormBase"></param>
        /// <param name="toControl"></param>
        /// <param name="tlOrigenControl"></param>
        /// <returns></returns>
        private bool Tabpages(IFormBase toFormBase, Control toControl, bool tlSuscribirse, bool tlOrigenControl = false)
        {
            if (toFormBase == null || toControl == null)
                return true;

            List<TabPage> lstPaginas = ((FormBase)toFormBase)._FindControl<TabPage>(toControl);
            if (lstPaginas.Count > 0)
            {
                int lnPos = 0;
                foreach (TabPage pagina in lstPaginas)
                {
                    List<TabPage> lstNumPag = ((FormBase)toFormBase)._FindControl<TabPage>(pagina);
                    if (Tabpages(toFormBase, pagina, tlSuscribirse))
                    {
                        if (lnPos != 0) // La primera página no lo hacemos ya que es la única que está creada y ya tiene sus eventos asignados
                        {
                            if (tlSuscribirse)
                            {
                                pagina.HandleCreated -= Pagina_HandleCreated;
                                pagina.HandleCreated += Pagina_HandleCreated;
                            }
                            else
                                pagina.HandleCreated -= Pagina_HandleCreated;
                        }
                        else if (tlOrigenControl) //pero si es la primera y viene con el parámetro marcado entonces si
                            AsignarEventosTxt(toFormBase, toControl, tlSuscribirse);
                    }
                    lnPos = lnPos + 1;
                }
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Nos suscribimos para realizar la asignación a txtserie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pagina_HandleCreated(object sender, EventArgs e)
        {
            TabPage loPagina = (TabPage)sender;
            AsignarEventosTxt((IFormBase)loPagina.TopLevelControl, loPagina, true);
        }

        /// <summary>
        /// Validación cambio de serie (txtserie)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tcValorCandidato"></param>
        /// <param name="tlOk"></param>
        private void Serie__Codigo_Cambiado_Before_Extended(object sender, string tcValorCandidato, ref bool tlOk)
        {
            try
            {
                if (tlOk) //Puede ser que el componente ya tenga validaciones y no las haya pasado
                {
                    if (sender is UserControl)
                    {
                        txtSerie loTxtSerie = sender as txtSerie;

                        //Solo presentamos el mensaje cuando no es de solo lectura el txtserie, ya que nos podemos encontrar que en el momento de la asignación
                        //del binding salte el mensaje, un ejemplo seria en el mantenimiento de clientes, cuando de accede a la pestaña de facturación, en ese 
                        //momento se crea la pestaña, se hace el binding y salta un mensaje, pero al añadir la condición de !loTxtSerie._ReadOnly no se presenta
                        //solo lo muestra en modo edición
                        if (loTxtSerie != null && !loTxtSerie._ReadOnly)
                            ValidarLetra(tcValorCandidato);
                    }
                }
            }
            catch (Exception loEx)
            {
                MessageBox.Show(loEx.Message + " " + loEx.StackTrace);
            }
        }

        /// <summary>
        /// Validación cambio de serie en documentos (combo)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tcValorCandidato"></param>
        /// <param name="tlOk"></param>      
        private void Documento__onLetraCambiadoBefore(object sender, string tcValorCandidato, ref bool tlOk)
        {
            try
            {
                if (tlOk) //Puede ser que el componente ya tenga validaciones y no las haya pasado
                {
                    if (sender is UserControl)
                    {
                        UserControl loComboSerie = sender as UserControl;
                        
                        tlOk = ValidarLetra(tcValorCandidato);
                    }
                }
            }
            catch (Exception loEx)
            {
                MessageBox.Show(loEx.Message + " " + loEx.StackTrace);
            }
        }

        /// <summary>
        /// Presentamos el mensaje del código cambiado, informando del nuevo valor de la serie
        /// </summary>
        /// <param name="tcLetra"></param>
        /// <returns></returns>
        private bool ValidarLetra(string tcLetra)
        {
            FUNCTIONS._MessageBox("El código de la serie seleccionado es " + tcLetra, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

            return true;
        }

        #endregion Métodos privados
    }
}
