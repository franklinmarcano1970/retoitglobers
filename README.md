# Reto itglobers

## Paso para instalar:
* Pasos
    * Restaurar backup de base de datos: vtex_test.bak.
    * Modificar el archivo "appsettings.json", la cadena de conexión.
        *  "ConnectionStrings": {
    "ModelContext": "Server=.;Database=vtex_test;Trusted_Connection=True;"
  }
    * Clonar el repositorio de: git clone https://github.com/franklinmarcano1970/retoitglobers.git
    * Abri la solucion de la carpeta "BackEnd", llamada:"vtex.app.sln".

## Arquitectura del proyecto.
* La aplicación esta construida en .NetCore 5, orientadas a microservicios Api Rest, con un motor de base de datos MSSqlServer.
* Los microservicios estan asegurados, mediante un api-key, que debe ser enviado por la cabecera de la petición, de igual manera se tiene control de los dominios permitidos y metodos http, permitidos en la aplicación.
* Se implemente el manejo de Cache por tiempo, para dar mejor perfomance en las consultas, el ejemplo lo pueden ver el controlado "EditorialControler", servicio "GetAllEditorial".
* Tiene Swagger implementado para revisar los serivicios implementados.
