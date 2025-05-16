# 🧾 Sistema de Facturación - Calvin Klein

Este es un proyecto académico grupal desarrollado en **C# con ASP.NET MVC y Entity Framework**, que simula un sistema de facturación funcional.  
Incluye manejo de productos, clientes, usuarios, facturas y control de stock.

---

## ⚙️ Tecnologías utilizadas

- Lenguaje: C# (.NET Framework)
- Arquitectura: MVC
- ORM: Entity Framework 6
- Motor de base de datos: SQL Server (LocalDB)
- IDE: Visual Studio

---

## 🧑‍💻 Autores del proyecto

Este proyecto fue desarrollado por un equipo de trabajo en conjunto.  


- Óscar Andrés Mónoga Espitia 
- Alejandro Ulate Boraschi  
- David Arturo Brenes Angulo 
- Andrés Solano

---

## 🙋‍♂️ Mi contribución personal

Aunque el proyecto fue grupal, participé activamente en la construcción del sistema.  
Puedo explicar todo su funcionamiento, y mi aporte principal fue:

- Conexión con Entity Framework
- CRUD de entidades (Producto, Usuario, Cliente)
- Autenticación con login y sesión
- Creación del usuario admin automático
- Validación y estructura del sistema

Además, este proyecto me ayudó a **reforzar el trabajo en equipo, mejorar mi comprensión de bases de datos y aplicar buenas prácticas**.

---

## 🛠️ Configuración de la base de datos

Antes de correr el proyecto por primera vez:

1. Abrí la solución en Visual Studio
2. Abrí la Consola del Administrador de Paquetes
3. Ejecutá el comando:

```powershell
Update-Database
```

## 🔐 Acceso al sistema

Al iniciar la aplicación por primera vez, si no existen usuarios, se crea automáticamente un usuario de prueba:

```bash
Usuario: admin  
Contraseña: 1234
