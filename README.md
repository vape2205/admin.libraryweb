<h1 align="center" id="title">WEBAPP ADMIN LIBRARY</h1>

<p align="center"><img src="https://github.com/vape2205/admin.libraryweb" alt="project-image"></p>

<p id="description">APLICACIÓN WEB ADMINISTRACION DE LIBRERIA</p>

  
  
<h2>🧐 Features</h2>

Caracteristicas

*   Crear libros
*   Eliminar libros
*   Listado de libros

<h2>🛠️ Installation Steps:</h2>

<p>1. Agregar archivo de environment</p>

Crear un archivo .env en la carpeta donde se encuentre el archivo docker-compose

```
# Variables de entorno para la bd 
URL_APIAUTH=http://auth.api:5000
URL_APILIBRARY=http://library.api:6000
WEBAPP_PORT=6003
```

<p>2. Ejecutar Docker Compose</p>

```
docker compose up -d --build
```

<h2>💻 Built with</h2>

Tecnologias usadas en este proyecto:

*   ASP .NET 8