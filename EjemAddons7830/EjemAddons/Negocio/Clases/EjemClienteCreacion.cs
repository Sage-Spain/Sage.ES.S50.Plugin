using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sage.ew.cliente;
using sage.ew.db;
using sage.ew.global;
using sage.ew.global.Diccionarios;
using sage.ew.ewbase;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase de ejemplo de creación de cliente con lo siguiente:
    /// 
    /// Datos mínimos del cliente, por ejemplo, el nombre, tipo de IVA, marca y familia.
    /// Datos de contacto.
    /// Datos bancarios.
    /// 2 direcciones de envío.
    /// 2 días de giro.
    /// 1 periodo de vacaciones.
    /// 1 cuota.
    /// </summary>
    public class EjemClienteCreacion
    {
        /// <summary>
        /// Ejemplo de creación de un cliente.
        /// </summary>
        private bool creacion(ref string mensajeError)
        {
            bool llOk = true;
            string lcClienteCrear = "43009815";
            mensajeError = "";

            // Supongamos que queremos crear un ciente de código 43009815

            // Antes de crear el cliente debemos asegurarnos de que el cliente no exista ya en la base de datos.
            //
            // Formas de verificar la existencia del cliente hay varias.
            //
            // Una forma de verificar si el cliente ya existe sería mediante consulta SQL al servidor de datos.
            //
            string lcCodigoExistente = Convert.ToString(DB.SQLValor("clientes", "codigo", lcClienteCrear, "CODIGO"));
            if (lcCodigoExistente == lcClienteCrear)
            {
                mensajeError = "El código de cliente " + lcClienteCrear + " ya existe.";
                return false;
            }

            // Otra forma de verificar la existencia del cliente seria utilizando la clase de negocio Cliente 
            // (del namespace sage.ew.cliente).
            //
            Cliente loCliente = new Cliente(lcClienteCrear);
            if (loCliente._Estado == sage.ew.ewbase.ewMante._EstadosMantenimiento.MostrandoRegistro)
            {
                mensajeError = "El código de cliente " + lcClienteCrear + " ya existe.";
                return false;
            }

            // Otra forma equivalente a la anterior seria la siguiente donde no pasamos el código de cliente en el
            // constructor de la clase Cliente sino que creamos el objeto Cliente vacío y le asignamos la propiedad
            // _Codigo posteriormente.
            //
            loCliente = new Cliente();
            loCliente._Codigo = lcClienteCrear;
            if (loCliente._Estado == sage.ew.ewbase.ewMante._EstadosMantenimiento.MostrandoRegistro)
            {
                mensajeError = "El código de cliente " + lcClienteCrear + " ya existe.";
                return false;
            }

            // Y finalmente otra forma de verificar la existencia del cliente podría ser:
            //
            loCliente = new Cliente();
            loCliente._Codigo = lcClienteCrear;
            if (loCliente._Existe_Registro())
            {
                mensajeError = "El código de cliente " + lcClienteCrear + " ya existe.";
                return false;
            }

            // Una vez hemos asegurado que el cliente no existe, vamos a la creación del cliente.
            //
            loCliente = new Cliente();
            loCliente._Codigo = lcClienteCrear;
            if (loCliente._Estado != sage.ew.ewbase.ewMante._EstadosMantenimiento.MostrandoRegistro)
            {
                // En primer lugar hay que declarar los datos obligatorios de la ficha del cliente.
                //
                loCliente._Nombre = "Nombre del cliente " + lcClienteCrear;
                loCliente._NIF = "41453124V";
                loCliente._RazonComercial = "Razón comercial del cliente " + lcClienteCrear;

                // Añadir datos de contacto, se guardan en GESTION!CLIENTES y también como primer registro de 
                // dirección en GESTION!ENV_CLI.
                //
                loCliente._Direccion = "Direccion predeterminada del cliente " + lcClienteCrear;
                loCliente._CodPost = "08040";
                loCliente._Poblacion = "Población predeterminada del cliente " + lcClienteCrear;
                loCliente._Provincia = "Provincia predeterminada del cliente " + lcClienteCrear;
                loCliente._Pais = "034";

                // Datos de contacto, se guardan en GESTION!CONTLF_CLI
                //
                loCliente._Contacto = "Contacto principal del cliente " + lcClienteCrear;
                loCliente._Telefono = "98 12 43 123";
                loCliente._Email = "emailcontactoprin@email.com";

                loCliente._TipoCliente = Cliente.TipoCliente.Nacional;
                loCliente._Moneda = "000";
                loCliente._Email = "emailnormal@email.com";
                loCliente._EmailFacturacion = "emailfacturacion@email.com";
                loCliente._PaginaWeb = "http://www.sage.es";

                // Añadir datos del banco predeterminado. Se guardan an GESTION!BANC_CLI
                //
                // Ejemplo para cuenta bancaria ficticia (es inventada) ES58 2100 0433 6423 3123 1231
                //
                loCliente._BancoPredet_Nombre = "Nombre banco principal del cliente  " + lcClienteCrear;
                loCliente._BancoPredet_Direccion = "Dirección banco principal del cliente  " + lcClienteCrear;
                loCliente._BancoPredet_Codpos = "08040";
                loCliente._BancoPredet_Poblacion = "Población banco principal del cliente  " + lcClienteCrear;
                loCliente._BancoPredet_TipoCta = "IBAN";
                loCliente._BancoPredet_Iban = "ES58";
                loCliente._BancoPredet_Codban = "2100";
                loCliente._BancoPredet_Succur = "0433";
                loCliente._BancoPredet_Digcon = "64";
                loCliente._BancoPredet_CtaCuenta = "2331231231";
                loCliente._BancoPredet_CuentaIban = "21000433642331231231";
                loCliente._BancoPredet_Swift = "";

                // Añadir un segundo banco (no predeterminado). Se guardará un segundo registro para el cliente en
                // GESTION!BANC_CLI
                //
                // Ejemplo para otra cuenta bancaria ficticia (inventada) ES21 0900 4123 4931 2312 4234
                //
                // La clave es de Cliente.DatosBancarios es _Cliente, _Codigo, al hacer el _NewItem() ya asigna valor a
                // _Cliente y a _Codigo
                //
                Cliente.DatosBancarios.DatoBancario loBanco = loCliente._TRelDatosBancarios._NewItem();
                loBanco._Orden = false;          // Este segundo banco no es el predeterminado.
                loBanco._Banco = "Nombre banco secundario del cliente  " + lcClienteCrear;
                loBanco._Direccion = "Dirección banco secundario del cliente  " + lcClienteCrear;
                loBanco._CodPos = "08000";
                loBanco._Poblacion = "Población banco secundario del cliente  " + lcClienteCrear;
                loBanco._TipoCta = "IBAN";
                loBanco._Iban = "ES21";
                loBanco._CtaBanco = "0900";
                loBanco._CtaSucur = "4123";
                loBanco._DigCon = "49";
                loBanco._CtaCuenta = "3123124234";
                loBanco._CuentaIban = "09004123493123124234";
                loBanco._Swift = "";
                loBanco._Cuenta = "ES21-0900-4123-4931-2312-4234";



                // Añadir dos direcciones de envío adicionales a la dirección predeterminada que se declaró al principio.
                //
                // Se guardan en GESTION!ENV_CLI
                //
                // La clave es de Cliente.Direcciones es _Cliente, _Linia, al hacer el _NewItem() ya asigna valor a
                // _Cliente y a _Linia
                //
                // Primera dirección.
                //
                Cliente.Direcciones.Direccion loDireccion = loCliente._TRelDirecciones._NewItem();
                loDireccion._Direccion = "Dirección secundaria 2 del cliente " + lcClienteCrear;
                loDireccion._CodPos = "08040";
                loDireccion._Poblacion = "Población secundaria 2 del cliente " + lcClienteCrear;
                loDireccion._Provincia = "Provincia secundaria 2 del cliente " + lcClienteCrear;
                loDireccion._Pais = "034";
                loDireccion._Nombre = "Nombre contacto dirección 2 del cliente " + lcClienteCrear;
                loDireccion._Telefono = "973 12 43 12";
                loDireccion._Fax = "973 43 23 43";
                loDireccion._Tipo = 2;    // 1-Sin especificar, 2-Facturación, 3-Envíos, 4-Remesa SEPA, 5-Comunicados
                loDireccion._Horario = "08:00-14:00 15:00-20:00";

                // Segunda dirección.
                //
                loDireccion = loCliente._TRelDirecciones._NewItem();
                loDireccion._Direccion = "Dirección secundaria 3 del cliente " + lcClienteCrear;
                loDireccion._CodPos = "08000";
                loDireccion._Poblacion = "Población secundaria 3 del cliente " + lcClienteCrear;
                loDireccion._Provincia = "Provincia secundaria 3 del cliente " + lcClienteCrear;
                loDireccion._Pais = "034";
                loDireccion._Nombre = "Nombre contacto dirección 3 del cliente " + lcClienteCrear;
                loDireccion._Telefono = "971 54 87 18";
                loDireccion._Fax = "971 33 13 44";
                loDireccion._Tipo = 3;    // 1-Sin especificar, 2-Facturación, 3-Envíos, 4-Remesa SEPA, 5-Comunicados
                loDireccion._Horario = "08:00-13:00 16:00-20:30";



                // Añadir dos días de giros. Se guardan en GESTION!GIRO_CLI.
                //
                // La clave es de Cliente.Giros es _Cliente, _Linia, al hacer el _NewItem() ya asigna valor a
                // _Cliente y a _Linia
                //
                // Primer giro.
                //
                Cliente.Giros.Giro loGiro = loCliente._TRelGiros._NewItem();
                loGiro._Giro = 15;        // Giro a 15 días.
                loGiro._Porcentaje = 25;  // Girar el 25% del importe de la factura.

                // Segundo giro.
                //
                loGiro = loCliente._TRelGiros._NewItem();
                loGiro._Giro = 30;        // Giro a 30 días.
                loGiro._Porcentaje = 75;  // Girar el 75% del importe de la factura.


                // Añadir un periodo de vacaciones. Se guardan en GESTION!VACA_CLI.
                //
                // La clave es de Cliente.Vacaciones es _Cliente, _Linia, al hacer el _NewItem() ya asigna valor a
                // _Cliente y a _Linia
                //
                Cliente.Vacaciones.Vacacion loPeriodoVaca = loCliente._TRelVacaciones._NewItem();
                loPeriodoVaca._Inicio = "01/07";
                loPeriodoVaca._Final = "31/07";


                // Añadir una cuota. Se guardan en COMUNES!CUOTAS y los meses en que se paga la cuota en COMUNES!CUO_MES.
                //
                // La clave es de Cuotas es _Empresa, _Cliente, _Linia, al hacer el _NewItem() ya asigna valor a
                // _Empresa, _Cliente y a _Linia
                //
                Cuotas.Cuota loCuota = loCliente._TRelCuotas._NewItem();
                loCuota._FechaIni = new DateTime(2023, 1, 1);
                loCuota._FechaFin = null;
                loCuota._Concepto = "01";
                loCuota._Descripcion = "Descripción de la cuota";
                loCuota._Importe = 130.00M;
                loCuota._ImporteDiv = 130.00M;
                loCuota._Csb19 = true;
                loCuota._CambioDeTipoCuota(1); // 1-Mensual, 2-Trimestral, 3-Semestral, 4-Anual, 5-Otros


                // Guardar el cliente y todos los datos asociados en la base de datos.
                //
                llOk = loCliente._Save();
                if (!llOk)
                    mensajeError = "No se ha podido crear el cliente " + lcClienteCrear + ". Mensaje de error: " + loCliente._Error_Message;
            }

            return llOk;
        }
    }
}


