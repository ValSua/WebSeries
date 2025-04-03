const express = require('express');
const path = require('path');
const app = express();

// Nombre de tu proyecto Angular (la carpeta dentro de dist)
const distFolder = 'web-series';

// Sirve los archivos estáticos
app.use(express.static(path.join(__dirname, 'dist', distFolder)));

// Redirige todas las solicitudes a index.html para soportar el routing de Angular
app.get('*', (req, res) => {
  res.sendFile(path.join(__dirname, 'dist', distFolder, 'index.html'));
});

// Puerto dinámico asignado por Azure o 8080 para desarrollo local
const port = process.env.PORT || 8080;

app.listen(port, () => {
  console.log(`App running on port ${port}`);
});