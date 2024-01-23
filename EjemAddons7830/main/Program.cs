using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using sage._50;
using sage.ew.functions;

namespace main
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// Documentación asociada al SDK de Sage 50: https://descargas.sage.es/Sage50/Documentacion_html/html/
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // *********************************************************************************************
            // **** D A T O S  D E  C O N F I G U R A C I Ó N  D E  A R R A N Q U E  D E L  A D D - O N **** 
            // definiciones de rutas de Sage 50 donde se encuentra la instalación:
            string rutaSage50Serv = @"c:\sage50\sage50serv\";
            string rutaSage50Term = @"c:\Sage50\sage50term\";

            // NOTAS:
            //  En caso que la compilación del proyecto de error revisar que las referencias de las librerías
            //  que apuntan a la carpeta a (rutaSage50Serv)\Librerias sean correctas.

            // definimos el usuario y el password que se utilizará para conectarse a Sage 50.
            string usuario = "SUPERVISOR";
            string password = "1";
            // *********************************************************************************************

            // copiar la libreria del add-on
            // Este método se utiliza para que tanto en la carpeta [Nº de versión] como en la instalación del terminal
            // tengan las últimas librerías del add-on.
            FUNCTIONS._CopiarLibreriasAddons(rutaSage50Serv, rutaSage50Term); 

            // Sage 50 se conecta a la base de datos mediante el fichero config.ini 
            // Debe haber una ruta de terminal de Sage 50 valida, un usuario y password de Sage 50
            if (!main_s50.Connect(rutaSage50Term, usuario, password))
            {
                MessageBox.Show($@"Error en la conexión de Sage 50. Por favor valide la siguiente información:{Environment.NewLine}{Environment.NewLine} Ruta del terminal: {rutaSage50Term}{Environment.NewLine} Usuario: {usuario}{Environment.NewLine} Password: {password}", "SDK Sage 50", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // presentación del Desktop de Sage 50
            main_s50._Show();
        }
    }
}
