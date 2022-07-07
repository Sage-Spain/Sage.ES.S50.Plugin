using sage.ew.db;
using sage.ew.DiagnosticoAutomatico;
using sage.ew.DiagnosticoAutomatico.Diagnosticos;
using sage.ew.global;
using System.Collections.Generic;

namespace sage.ew.EjemAddons.Diagnostico
{
    /// <summary>
    /// Clase de prueba diagnostico para ver los asientos con moneda diferente de empresa que su cambio excede la desviación estándar 
    /// Esta clase hereda de PruebaDiagnostica, deberemos sobrescribir el método Ejecutar donde realizamos las comprobaciones.
    /// Al heredar de PruebaDiagnostica nos aparecerá en el apartado "Consola de administración"->"Pruebas automatizadas"
    /// </summary>
    public class DesviacionCambio
        : PruebaDiagnostica
    {

        /// <summary>
        /// Método que se ejecutará al realizar las pruebas diagnosticas, deberemos devolver un listado con los resultados de las pruebas realizadas. 
        /// Por ejemplo en este proceso realizaremos una consulta para obtener los registros de asientos con divisa diferente a la de la empresa y su cambio exceda por tres la desviación estándar.
        /// </summary>
        /// <returns>Listado de IResultadoPruebaDiagnostica con los resultados de las pruebas</returns>
        public override IEnumerable<IResultadoPruebaDiagnostica> Ejecutar()
        {
            string lcSql;

            //Creamos la consulta que nos devolverá los registros que no cumplem con la desviación estándar    
            lcSql = $@"
                    SELECT NUMERO, ASI FROM {DB.SQLDatabase("GESTION", "ASIENTOS")} a INNER JOIN (
                    SELECT DIVISA, AVG(CAMBIO) - (3 * STDEVP(CAMBIO)) a , AVG(CAMBIO) + (3 * STDEVP(CAMBIO)) b  FROM {DB.SQLDatabase("GESTION", "ASIENTOS")}
                    WHERE EMPRESA = {DB.SQLString(EW_GLOBAL._Empresa._Codigo)} AND DIVISA <> {DB.SQLString(EW_GLOBAL._Empresa._Moneda)} GROUP BY DIVISA ) g 
                    ON a.DIVISA <> {DB.SQLString(EW_GLOBAL._Empresa._Moneda)} AND (a.CAMBIO > b OR a.CAMBIO < a) AND a.EMPRESA = {DB.SQLString(EW_GLOBAL._Empresa._Codigo)} ORDER BY FECHA asc 
                    ";

            //Utilizando el método EvaluarQueryPorNumeroRegistros devolvemos una lista con los resultados de la prueba, este método ejecuta la consulta y comprueba si el número de registros coincide con el valor pasado por parámetro.
            //En este caso solamente devolveremos un IResultadoPruebaDiagnostica pero podríamos devolver más de uno si nos interesase.
            return new List<IResultadoPruebaDiagnostica>() { EvaluarQueryPorNumeroRegistros(lcSql, 0) } as IEnumerable<IResultadoPruebaDiagnostica>; 
        }

        /// <summary>
        /// Constructor de la clase heredando de a base, donde definiremos los parámetros:
        /// TipoCategoriaPruebaDiagnostica: Categoría de la prueba
        /// Nombre: Nombre de la prueba
        /// Descripción: Explicación de la prueba que realiza la clase.
        /// </summary>
        public DesviacionCambio() 
            : base(TipoCategoriaPruebaDiagnostica.Addons, "Desviación cambio", "Se comprueba que el cambio de los asientos en divisa que tengan moneda diferente a la de la empresa excede la desviación media.")
        {

        }
    }
}
