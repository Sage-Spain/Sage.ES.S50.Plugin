# Sage.ES.S50.Plugin

<h2>Instalación del add-on</h2>
<p>Para poder instalar el add-on y ver todo el código fuente debes seguir los siguientes pasos:</p>
<ul>
  <li>Desde el botón CODE bajarte el fichero .ZIP con todo el código</li>
  <li>Descomprimir en una carpeta temporal</li>
  <li>Ejecutar Sage 50, ir a la opción del menú del usuario. Opción "Aplicaciones y servicios conectados"</li>
  <li>Buscar la tarjeta "Add-on personalizado", pulsar el botón de "Instalar"</li>
  <li>Aparecerá un formulario donde solicitará un fichero con extensión .addon</li>
  <li>Este fichero tiene por nombre EJEMADQV.addon y se puede localizar en la carpeta INSTALADOR del fichero descomprimido</li>
</ul>
<p>Una vez realizado estos pasos tendrás la base de datos y el add-on instalado en Sage 50</p>

<h2>Instalación del código fuente</h2>
<p>Dentro del fichero comprimido tienes una carpeta llamada <b>EjemAddons</b>. Puedes copiarla directamente en la carpeta Modulos del Servidor de Sage 50. 
Después con Visual Studio puedes abrir el fichero de la solución EjemAddons.sln</p> 

<h2>Ejecución por defecto del código fuente</h2>
<p>Para poder ejecutar el add-on de ejemplo en una instalación de Sage 50, Sage 50 debe tener la siguiente estructura de carpetas:</p>
<ul>
  <li>Tener una instalación de Sage 50 en una carpeta llamada Sage50</li>
  <li>Dentro de la carpeta Sage50 debe haber una carpeta llamada Sage50Serv (carpeta servidor Sage 50)</li>
  <li>Dentro de la carpeta Sage50 debe haber una carpeta llamada Sage50Term (carpeta terminal Sage 50)</li>
  <li>Se debe utilizar el proceso de instalación para que realice la instalación de la base de datos del add-on</li>
</ul>

<h2>Ejecución del código fuente en un Sage 50 en carpetas personalizadas</h2>
<p>En caso que tengamos un Sage 50 en una carpeta diferente de Sage50 para poder arrancar el proyecto desde Visual Studio deberemos configurar 
las siguientes variables del fichero program.cs del proyecto Main:</p>

<ul>
  <li>rutaSage50Serv --> ruta donde se encuentra el servidor de Sage 50. El valor por defecto es: c:\sage50\sage50serv\</li>
  <li>rutaSage50Term --> ruta donde se encuentra el terminal de Sage 50. El valor por defecto es: c:\Sage50\sage50term\</li>
</ul>

<h2>Configuración del usuario y password para ejecutar Sage 50 desde Visual Studio</h2>
<p>Para poder ejecutar el add-on se establece <b><u>en la variable usuario</u></b> el usuario de conexión de Sage 50. Esto significa que este usuario debe estar creado como usuario dentro de Sage 50. 
En caso que en el fichero Program.cs del proyecto Main se cambie el usuario y se establezca un usuario inexistente dará error y Sage 50 no arrancará desde Visual Studio</p>
<p>El mismo proceso se realiza para el password de arranque. En este punto es el password del usuario de Sage 50.</p>

<h2>Rutas donde se debe instalar el proyecto</h2>
<p>Puedes bajarte el código de ejemplo y una vez descomprimido debes copiar la carpeta "EjemAddons" dentro de la carpeta Modulos del servidor de Sage 50.</p>
