using sage.ew.db;
using sage.ew.DiagnosticoAutomatico;
using sage.ew.DiagnosticoAutomatico.Diagnosticos;
using sage.ew.global;
using System.Collections.Generic;

namespace sage.ew.EjemAddons.Diagnostico
{
    /// <summary>
    /// Clase ejemplo de prueba diagnostico. 
    /// Esta clase hereda de PruebaDiagnostica, deberemos sobrescribir el método Ejecutar donde realizamos las comprobaciones.
    /// Al heredar de PruebaDiagnostica nos aparecerá en el apartado "Consola de administración"->"Pruebas automatizadas"
    /// El nombre de la librería tiene de ser "sage.pruebasauto.*.dll"
    /// </summary>
    public class EjemploPrueba
        : PruebaDiagnostica
    {

        /// <summary>
        /// Constructor de la clase heredando de a base, donde definiremos los parámetros:
        /// TipoCategoriaPruebaDiagnostica: Categoría de la prueba
        /// Nombre: Nombre de la prueba
        /// Descripción: Explicación de la prueba que realiza la clase.
        /// </summary>
        public EjemploPrueba()
            : base(TipoCategoriaPruebaDiagnostica.Addons, "Ejemplo Prueba", "Clase de ejemplo de prueba automatizada.")
        {

        }


        /// <summary>
        /// Método que se ejecutará al realizar las pruebas diagnosticas, deberemos devolver un listado con los resultados de las pruebas realizadas. 
        /// </summary>
        /// <returns>Listado de IResultadoPruebaDiagnostica con los resultados de las pruebas</returns>
        public override IEnumerable<IResultadoPruebaDiagnostica> Ejecutar()
        {
            string lcSql;

            //Ejemplo de consulta a realizar: lista de clientes que no tienen código de vendedor asignado
            lcSql = $@"
                    SELECT CODIGO AS CLIENTE, NOMBRE FROM {DB.SQLDatabase("GESTION", "CLIENTES")} 
                    WHERE VENDEDOR = '' ORDER BY CODIGO";


            //Utilizando el método EvaluarQueryPorNumeroRegistros devolvemos una lista con los resultados de la prueba, este método ejecuta la consulta y comprueba si el número de registros coincide con el valor pasado por parámetro.
            //En este caso solamente devolveremos un IResultadoPruebaDiagnostica pero podríamos devolver más de uno si nos interesase.
            return new List<IResultadoPruebaDiagnostica>() { EvaluarQueryPorNumeroRegistros(lcSql, 0) } as IEnumerable<IResultadoPruebaDiagnostica>;
        }

    }
}
