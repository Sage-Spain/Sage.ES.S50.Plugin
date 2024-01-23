# Sage.ES.S50.Plugin

<h2>Instalación del add-on</h2>
<p>Para poder instalar el add-on y ver todo el código fuente se deben seguir los siguientes pasos:</p>
<ul>
  <li>Desde el botón CODE descargar el fichero .ZIP con todo el código</li>
  <li>Descomprimir en una carpeta temporal</li>
  <li>Ejecutar Sage 50 y acceder a la opción del menú del usuario "Aplicaciones y servicios conectados"</li>
  <li>Buscar la tarjeta "Add-on personalizado" y pulsar el botón de "Instalar"</li>
  <li>Aparecerá un formulario donde solicitará un fichero con extensión .addon</li>
  <li>Este fichero tiene por nombre EJEMADQV.addon y se puede localizar en la carpeta INSTALADOR del fichero descomprimido</li>
</ul>
<p>Una vez realizado estos pasos y existirá la base de datos y el add-on instalado en Sage 50</p>

<h2>Instalación del código fuente</h2>
<p>Dentro del fichero comprimido existe una carpeta llamada <b>EjemAddons</b>. Se puede copiar directamente en la carpeta MODULOS del servidor de Sage 50. 
Después desde Visual Studio se puede abrir el fichero de la solución EjemAddons.sln</p> 

<h2>Ejecución por defecto del código fuente</h2>
<p>Para poder ejecutar el add-on de ejemplo en una instalación de Sage 50, la aplicación debe tener la siguiente estructura de carpetas:</p>
<ul>
  <li>Tener una instalación de Sage 50 en una carpeta llamada Sage50</li>
  <li>Dentro de la carpeta Sage50 debe haber una carpeta llamada Sage50Serv (carpeta del servidor Sage 50)</li>
  <li>Dentro de la carpeta Sage50 debe haber una carpeta llamada Sage50Term (carpeta del terminal Sage 50)</li>
  <li>Se debe utilizar el proceso de instalación para que realice la instalación de la base de datos del add-on de ejemplos</li>
</ul>

<h2>Ejecución del código fuente en un Sage 50 con carpetas personalizadas</h2>
<p>En caso de que exista un Sage 50 en una carpeta diferente de Sage50 para poder arrancar el proyecto desde Visual Studio se deben configurar 
las siguientes variables del fichero program.cs del proyecto Main:</p>

<ul>
  <li>rutaSage50Serv --> Ruta donde se encuentra el servidor de Sage 50. El valor por defecto es: c:\sage50\sage50serv\</li>
  <li>rutaSage50Term --> Ruta donde se encuentra el terminal de Sage 50. El valor por defecto es: c:\sage50\sage50term\</li>
</ul>

<h2>Configuración del usuario y password para ejecutar Sage 50 desde Visual Studio</h2>
<p>Para poder ejecutar el add-on se establece <b><u>en la variable usuario</u></b> el usuario de conexión de Sage 50. Esto significa que este usuario debe estar creado como usuario dentro de Sage 50. 
En caso que en el fichero Program.cs del proyecto Main se cambie el usuario y se establezca un usuario inexistente dará error y Sage 50 no arrancará desde Visual Studio.</p>
<p>El mismo proceso se realiza para el password de arranque. En este punto es el password del usuario de Sage 50.</p>

<h2>Rutas donde se debe instalar el proyecto</h2>
<p>Se puede descargar el código de ejemplo y una vez descomprimido debes copiar la carpeta "EjemAddons" dentro de la carpeta Modulos del servidor de Sage 50.</p>

<h2>Notas adicionales</h2>
<ul>
  <li>Proyecto EjemAddons: este proyecto está preparado para versiones de Sage 50.7820.0 o inferiores</li>
  <li>Proyecto EjemAddons7830: este proyecto está preparado para versiones de Sage 50 50.7830.0 o superiores (en esta versión ya están cambiadas las referencias y se utiliza el nuevo sistema de referencias)</li>
</ul>
