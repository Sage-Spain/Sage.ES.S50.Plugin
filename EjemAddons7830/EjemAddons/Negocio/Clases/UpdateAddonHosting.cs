using sage.ew.interficies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase que utilizamos para actualizar el add-on de forma automática en una versión Máster o una release de librerías
    /// El proceso es automático y transparente para el usuario final.
    /// ** NOTA IMPORTANTE: la subida al FTP es responsabilidad del desarrollador. No hay una actualización automática desde el proceso de creación del paquete de instalación.
    /// </summary>
    public class UpdateAddonHosting : IAccesAddonUrl
    {
        /// <summary>
        /// Dirección web donde se encuentra el último instalador del add-on.
        /// Ejemplo --> "ftp://miftp.hosting.com"
        /// </summary>
        public string _Url { get; set; } = "";

        /// <summary>
        /// Nombre de usuario que se utiliza para acceder a la URL especificada.
        /// Ejemplo --> "Jose"
        /// </summary>
        public string _User { get; set; } = "";

        /// <summary>
        /// Password que se utiliza para acceder con este usuario dentro del FTP donde se encuentra el paquete de instalación del add-on.
        /// Ejemplo --> "updateAddons@2022"
        /// </summary>
        public string _Password { get; set; } = "";
        
        /// <summary>
        /// Carpeta donde se encuentra el fichero (EJEMADQV.addon) para instalar.
        /// Ejemplo --> "addons"
        /// </summary>
        public string _Carpeta { get; set; }
    }
}
