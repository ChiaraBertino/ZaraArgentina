# Primera Entrega — Dashboard Zara Argentina

Tecnologías:
-SQL Server
- Node.js + Express
- React + Vite

## Qué corresponde a la primera entrega

1.Modelo canónico de la base de datos.
2. Sistema de inicio de sesión funcionando, validando las credenciales contra SQL Server.
3. Diseño completo de la interfaz de usuario.

## Estructura de la base

Entidades principales del dashboard:
-Provincias
- Tiendas
- Categorías
- Productos
- Ventas / DetalleVenta

Además:
-Usuarios: autenticación.
- MetasTienda: preparada para la semaforización de la segunda entrega.

Drill Down previsto:
Provincia → Tienda → Detalle de venta.

## Cómo ejecutar

### 1) SQL Server
Ejecutar `database/ZaraArgentina.sql` en SQL Server Management Studio.

### 2) Backend
Entrar a `backend/`.
Copiar `.env.example` como `.env` y completar las credenciales de SQL Server.

Luego:
npm install
npm start

El backend queda en http://localhost:3001

### 3) Crear usuario de prueba
Con el backend funcionando, enviar un POST a:
http://localhost:3001/api/setup-user

Body JSON:
{
    "usuario": "admin",
  "password": "123456"
}

Esto genera el hash con bcrypt y lo guarda en SQL Server.

### 4) Frontend
Entrar a `frontend/`.

npm install
npm run dev

Abrir la dirección que indique Vite (normalmente http://localhost:5173).

Login de prueba:
usuario: admin
contraseña: 123456

## Importante
Los datos numéricos mostrados en algunas pantallas del frontend son datos de demostración para el diseño de la primera entrega. En la segunda entrega se reemplazan por consultas SQL reales y visualizaciones conectadas a la base.
