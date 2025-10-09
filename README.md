**Práctica Programada 1 - Sistema Gestor de Números de Teléfono:**

**1.	Integrantes del grupo:**
    ⦁	Valeria Chacón Aragón
    ⦁	Camila Corrales Roca
    ⦁	Diana Ramírez Aguilar
    ⦁	Vivian Michelle Velázquez Rojas

**2.  Link del Repositorio:**
   	https://github.com/Camilacr10/PracticaProgramada1.git

**3.  Especificación básica del proyecto:**
   	Práctica basada 100% en el código de la clase.
   	La arquitectura está compuesta por capas como MVC (PracticaProgramada1), Capa de Datos (PracticaProgramada1DAL) y Capa de Negocio (PracticaProgramada1BBL), con sus respectivas
    carpetas.Todas las funcionalidades del Sistema Gestor de Números de Teléfono (listar, detalles, crear, editar y eliminar) están terminadas.

      ** ⦁  Arquitectura y tipos de proyectos:**
           	El proyecto cuenta con una arquitectura por capas, conformada por:
           		o PracticaProgramada1 (MVC): contiene los controladores, vistas y la estructura principal del sistema.
           		o PracticaProgramada1DAL (Capa de Datos): incluye la entidad y el repositorio con las operaciones CRUD.
           		o PracticaProgramada1BBL (Capa de Negocio): maneja la lógica del sistema, los servicios, los Dtos y el mapeo con AutoMapper.
           	Cada capa está organizada dentro de su respectivos proyectos y con sus carpetas correspondientes para mantener el orden y facilitar la comprensión del proyecto.
        
        **⦁	Paquetes NuGet:**
           	o AutoMapper.
        
        **⦁	Principios SOLID:**
           	Se puede decir que se aplicó los principios de SOLID de la siguiente manera:
           		o S (Responsabilidad Única): Aplicado en la separación de capas (MVC, BBL y DAL), donde cada una cumple una función específica.
           		o O (Abierto/Cerrado): Aplicado en los servicios, que permiten agregar nuevas funciones sin modificar el código existente.
           		o L (Sustitución de Liskov): Aplicado en el uso de interfaces (IClientesRepositorio, IClientesServicio) que permiten cambiar implementaciones sin afectar el sistema.
           		o I (Segregación de Interfaces): Aplicado al crear interfaces separadas para cada tarea, manteniendo el código más ordenado.
           		o D (Inversión de Dependencias): Aplicado al usar inyección de dependencias en el Program.cs para conectar las capas del proyecto.
        
        **⦁	Patrones de diseño:**
           	Se puede decir que se aplicó los patrones de diseño de la siguiente manera:
           		o MVC: aplicado en la capa PracticaProgramada1, donde se manejan los controladores, vistas y modelos.
           		o Repositorios: aplicado en la capa PracticaProgramada1DAL, con las clases IClientesRepositorio y ClientesRepositorio para manejar los datos.
           		o Servicios: aplicado en la capa PracticaProgramada1BBL, con las clases IClientesServicio y ClienteServicio que contienen la lógica del sistema.
           		o Dtos: aplicado en la capa PracticaProgramada1BBL, en la clase ClienteDto para transferir la información entre las capas.
           		o Dependencias: aplicado en la capa PracticaProgramada1, dentro del archivo Program.cs, donde se conectan las capas del proyecto.
           		o AutoMapper: aplicado en la capa PracticaProgramada1BBL, en la clase MapeoClase, para mapear los datos entre entidades y Dtos.
