using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sage.ew.articulo;
using sage.ew.db;
using sage.ew.global;
using sage.ew.global.Diccionarios;
using sage.ew.objetos.UserControls;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase de ejemplo de creación de artículo con lo siguiente:
    /// 
    /// Datos mínimos del artículo, por ejemplo, el nombre, tipo de IVA, marca y familia.
    /// 2 códigos de barras.
    /// 2 códigos EAN peso.
    /// 2 referencias de proveedores.
    /// 1 precio de una tarifa de venta.
    /// </summary>
    public class EjemArticuloCreacion
    {
        /// <summary>
        /// Ejemplo de creación de un artículo.
        /// </summary>
        private bool creacion(ref string mensajeError)
        {
            bool llOk = true;
            string lcArticuloCrear = "TESTART";
            mensajeError = "";

            // Supongamos que queremos crear un artículo de código TESTART

            // Antes de crear el artículo debemos asegurarnos de que el artículo no exista ya en la base de datos.
            //
            // Formas de verificar la existencia del artículo hay varias.
            //
            // Una forma de verificar si el artículo ya existe sería mediante consulta SQL al servidor de datos.
            //
            string lcCodigoExistente = Convert.ToString(DB.SQLValor("articulo", "codigo", lcArticuloCrear, "CODIGO"));
            if (lcCodigoExistente == lcArticuloCrear)
            {
                mensajeError = "El código de artículo " + lcArticuloCrear + " ya existe.";
                return false;
            }

            // Otra forma de verificar la existencia del artículo seria utilizando la clase de negocio Articulo 
            // (del namespace sage.ew.articulo).
            //
            Articulo loArticulo = new Articulo(lcArticuloCrear);
            if (loArticulo._Estado == ew.ewbase.ewMante._EstadosMantenimiento.MostrandoRegistro)
            {
                mensajeError = "El código de artículo " + lcArticuloCrear + " ya existe.";
                return false;
            }

            // Otra forma equivalente a la anterior seria la siguiente donde no pasamos el código de artículo en la
            // constructor de la clase Articulo sino que creamos el objeto Articulo vacío y le asignamos la propiedad
            // _Codigo posteriormente.
            //
            loArticulo = new Articulo();
            loArticulo._Codigo = lcArticuloCrear;
            if (loArticulo._Estado == ew.ewbase.ewMante._EstadosMantenimiento.MostrandoRegistro)
            {
                mensajeError = "El código de artículo " + lcArticuloCrear + " ya existe.";
                return false;
            }

            // Y finalmente otra forma de verificar la existencia del artículo podría ser:
            //
            loArticulo = new Articulo();
            loArticulo._Codigo = lcArticuloCrear;
            if (loArticulo._Existe_Registro())
            {
                mensajeError = "El código de artículo " + lcArticuloCrear + " ya existe.";
                return false;
            }

            // Una vez hemos asegurado que el artículo no existe, vamos a la creación del artículo.
            //
            loArticulo = new Articulo();
            loArticulo._Codigo = lcArticuloCrear;
            if (loArticulo._Estado != ew.ewbase.ewMante._EstadosMantenimiento.MostrandoRegistro)
            {
                // En primer lugar hay que declarar los datos obligatorios de la ficha del artículo.
                //
                loArticulo._Nombre = "Nombre del artículo " + lcArticuloCrear;
                loArticulo._Marca = new string('0', Convert.ToInt32(EW_GLOBAL._GetLenCampo(KeyDiccionarioLenCampos.wn_marcas)));
                loArticulo._Familia = new string('0', Convert.ToInt32(EW_GLOBAL._GetLenCampo(KeyDiccionarioLenCampos.wn_familia)));
                loArticulo._TipoIVA = "03";



                // Añadir dos códigos de barras al artículo.
                // Primero verificamos que el código de barras que queremos añadir no exista ya.
                // Al estar creando un nuevo artículo no debería existir pero hacemos el control igualmente.
                //
                // La clave de loArticulo._Barras está formada por _Articulo y por _Barras, hacemos la búsqueda por estas
                // propiedades.
                //
                Dictionary<string, object> loDicCamposBusqueda = new Dictionary<string, object>();
                loDicCamposBusqueda.Add("_Articulo", lcArticuloCrear);
                loDicCamposBusqueda.Add("_Barras", "123123123213213");
                Articulo.Barras.Barra loCodigoBarras = loArticulo._Barras._GetItem(loDicCamposBusqueda);
                if (loCodigoBarras == null)
                {
                    loCodigoBarras = loArticulo._Barras._NewItem();
                    loCodigoBarras._Articulo = lcArticuloCrear;
                    loCodigoBarras._Barras = "123123123213213";
                }

                loDicCamposBusqueda.Clear();
                loDicCamposBusqueda.Add("_Articulo", lcArticuloCrear);
                loDicCamposBusqueda.Add("_Barras", "453124312563431");
                loCodigoBarras = loArticulo._Barras._GetItem(loDicCamposBusqueda);
                if (loCodigoBarras == null)
                {
                    loCodigoBarras = loArticulo._Barras._NewItem();
                    loCodigoBarras._Articulo = lcArticuloCrear;
                    loCodigoBarras._Barras = "453124312563431";
                }



                // Añadir dos EAN peso al artículo.
                // Primero verificamos que el EAN que queremos añadir no exista ya.
                //
                // La clave de loArticulo._EANPesos está formada por _Articulo y por _Codigos, hacemos la búsqueda por estas
                // propiedades.
                //
                loDicCamposBusqueda.Clear();
                loDicCamposBusqueda.Add("_Articulo", lcArticuloCrear);
                loDicCamposBusqueda.Add("_Codigo", "1234123");
                Articulo.EANPesos.EANPeso loEANPeso = loArticulo._EANPesos._GetItem(loDicCamposBusqueda);
                if (loEANPeso == null)
                {
                    loEANPeso = loArticulo._EANPesos._NewItem();
                    loEANPeso._Articulo = lcArticuloCrear;
                    loEANPeso._Codigo = "1234123";
                    loEANPeso._Posicion = 8;
                    loEANPeso._Longitud = 9;
                    loEANPeso._Decimales = 2;
                    loEANPeso._Tipo = 0;
                }

                loDicCamposBusqueda.Clear();
                loDicCamposBusqueda.Add("_Articulo", lcArticuloCrear);
                loDicCamposBusqueda.Add("_Codigo", "4343422");
                loEANPeso = loArticulo._EANPesos._GetItem(loDicCamposBusqueda);
                if (loEANPeso == null)
                {
                    loEANPeso = loArticulo._EANPesos._NewItem();
                    loEANPeso._Articulo = lcArticuloCrear;
                    loEANPeso._Codigo = "4343422";
                    loEANPeso._Posicion = 8;
                    loEANPeso._Longitud = 9;
                    loEANPeso._Decimales = 1;
                    loEANPeso._Tipo = 1;
                }




                // Añadir dos referencias de proveedores al artículo.
                // Primero verificamos que la referencia no exista ya.
                //
                // La clave de loArticulo._Referencias está formada por _Articulo, _Proveedor, _Talla, _Color, _Moneda,
                // hacemos la búsqueda por estas propiedades.
                //
                loDicCamposBusqueda.Clear();
                loDicCamposBusqueda.Add("_Articulo", lcArticuloCrear);
                loDicCamposBusqueda.Add("_Proveedor", "40000001");
                loDicCamposBusqueda.Add("_Talla", "");
                loDicCamposBusqueda.Add("_Color", "");
                loDicCamposBusqueda.Add("_Moneda", "000");

                Articulo.Referencias.Referencia loReferencia = loArticulo._Referencias._GetItem(loDicCamposBusqueda);
                if (loReferencia == null)
                {
                    loReferencia = loArticulo._Referencias._NewItem();
                    loReferencia._Articulo = lcArticuloCrear;
                    loReferencia._Proveedor = "40000001";
                    loReferencia._Talla = "";
                    loReferencia._Color = "";
                    loReferencia._Moneda = "000";
                }
                loReferencia._Referencia = "B54334AFD";
                loReferencia._Cambio = 1.0M;
                loReferencia._Pcompra = 1000.00M;
                loReferencia._Dto1 = 10.00M;
                loReferencia._SubTotalCoste = 90.00M;
                loReferencia._Predet = true;
                loReferencia._Fecha_Ult = DateTime.Today.Date;

                loDicCamposBusqueda.Clear();
                loDicCamposBusqueda.Add("_Articulo", lcArticuloCrear);
                loDicCamposBusqueda.Add("_Proveedor", "40000002");
                loDicCamposBusqueda.Add("_Talla", "");
                loDicCamposBusqueda.Add("_Color", "");
                loDicCamposBusqueda.Add("_Moneda", "000");

                loReferencia = loArticulo._Referencias._GetItem(loDicCamposBusqueda);
                if (loReferencia == null)
                {
                    loReferencia = loArticulo._Referencias._NewItem();
                    loReferencia._Articulo = lcArticuloCrear;
                    loReferencia._Proveedor = "40000002";
                    loReferencia._Talla = "";
                    loReferencia._Color = "";
                    loReferencia._Moneda = "000";

                }
                loReferencia._Referencia = "AA345345";
                loReferencia._Cambio = 1.0M;
                loReferencia._Pcompra = 1500.00M;
                loReferencia._Dto1 = 25.00M;
                loReferencia._SubTotalCoste = 1125.00M;
                // Solo una de las referencias puede ser la predeterminada.
                loReferencia._Predet = false;
                loReferencia._Fecha_Ult = DateTime.Today.Date;



                // Añadir precio de venta a una tarifa de venta, por ejemplo, la predterminada que viene en el CD de código TD.
                //
                // Recordar que al crear el artículo, se crean automáticamente tantos registros en la tabla GESTION!PVP
                // como tarifas de venta haya en GESTION!TARIFAS.
                //
                // La clave de loArticulo._Precios está formada por _Articulo, _Tarifa, hacemos la búsqueda por estas
                // propiedades.
                //
                loDicCamposBusqueda.Clear();
                loDicCamposBusqueda.Add("_Articulo", lcArticuloCrear);
                loDicCamposBusqueda.Add("_Tarifa", "TD");
                Articulo.Precios.Precio loPrecio = loArticulo._Precios._GetItem(loDicCamposBusqueda);
                if (loPrecio == null)
                {
                    loPrecio = loArticulo._Precios._NewItem();
                    loPrecio._Articulo = lcArticuloCrear;
                    loPrecio._Tarifa = "TD";
                }
                loPrecio._Pvp = 1000.00M;


                // Guardar el artículo y todos los datos asociados en la base de datos.
                //
                llOk = loArticulo._Save();
                if (!llOk)
                    mensajeError = "No se ha podido crear el artículo " + lcArticuloCrear + ". Mensaje de error: " + loArticulo._Error_Message;
            }

            return llOk;
        }
    }
}

