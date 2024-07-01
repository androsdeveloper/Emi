
Todas las secciones se implementaron en un sólo proyecto

Cómo poner a correr el código?
El visual Studio se debe ejecutar en modo administrador y se debe hacer un Rebuild a la solución.
El código tiene un migration donde en la migración se inserta en la base de datos información previa para fcilitar la revisión de la prueba, la información a insertar se encuentra en el proyecto Repository, en la carpeta Migrations/20240630223239_initial.cs, la inserción de los datos iniciales
lo pueden ver desde la línea 124.
Sólo es ejecutar en el package console el comando Update-Database. Si agregan una migración pueden eliminar el custom code para insertar la información.

Los endpoints los pueden ver y ejecutar en el Swagger.

El tema de la autenticación se está manejando en una lista estática, por lo que si registran usuarios y paran la aplicación se eliminarían de la memoria. Los demás Endpoints si se insertan en base de datos.

El primer Endpoint que deben ejecutar es: 
