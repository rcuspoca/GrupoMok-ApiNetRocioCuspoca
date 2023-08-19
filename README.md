# APINetMok
1. Se crea una API llamada APINetMok para un sistema de préstamos, con 3 controladores llamados Estudiante.Controller, Libro.Controller y Prestamo.Controller, donde a cada uno se le aplica el CRUD con métodos de petición: GET, POST, PUT, DELETE.
2.  El desarrollo está basado en un sistema de préstamo de libros, donde se usan 4 tablas llamadas Estudiante, Libro, Prestamo, TipoIdentificacion.
3. La tabla Prestamo tiene dependencia de la tabla Estudiante y Libro.
4. Se usa el ORM(Object Relational Mapping) : EntityFramework instalando el paquete Microsoft.EntityFrameworkCore.SqlServer.
5. Se usa una arquitectura híbrida MVC y hexagonal, donde tiene los siguientes componenentes: Dominio, Infraestructura, Modelo, Negocios, Controladores.
6. Se aplican principios SOLID como:
   5.1. Simple Responsability: las clases y métodos tienen su propio objetivo y funcionalidad, no se mezcla lógica de otra funcionalidad.
   Open/closed: Las clases y métodos quedan abiertas para su extensión, evitando realizando modificaciones a lo existente.
   Liskov Substitution: Se usa las clases padre como EstudianteModel, LibroModel, PrestamoModel cuyos atributos se heredan para las clases Dto.
   Interface Segregation: Se crean interfaces de tal forma que cada una tenga su propia responsabilidad y no se implementen métodos que no necesita.
   Dependency Inversion: Se aplica la inyección de dependencias que permite instanciar clases y suministrar las dependencias enviando parámetros a través del constructor.
7.
8. Se crea una segunda API llamada ApiExternaMok, para realizar la consulta de los tipos de documento de la identificación del estudiante.
   
   
   
   
El estado del proyecto, que es particularmente importante si el proyecto está todavía en desarrollo. ...
Los requisitos del entorno de desarrollo para la integración.
Una guía para la instalación y el funcionamiento.

