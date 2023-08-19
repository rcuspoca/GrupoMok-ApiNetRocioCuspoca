# APINetMok
1. Se crea una API principal llamada APINetMok para un sistema de préstamos, con 3 controladores llamados Estudiante.Controller, Libro.Controller y Prestamo.Controller, donde a cada uno se le aplica el CRUD con métodos de petición: GET, POST, PUT, DELETE.
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
7. Se crea una segunda API llamada ApiExternaMok, para realizar la consulta de los tipos de documento de la identificación del estudiante.
8. La Api: ApiExternaMok es invocada por la Api: APINetMok, al momento de crear un estudiante, realiza la consulta del IdTipoDocumento a través del TipoIdentificacion con el
   siguiente llamado:  TipoIdentificacionModel tipoIdentificacion = await _servicioExternoApi.GetTipoDocumentoByAbreviatura(estudiante.TipoIdentificacion).
9. Para instanciar la segunda Api, se configura el appsetting.json con este parámetros: "ServicioExternoApi": {
    "LocalUrl": "https://localhost:7269/TipoDocumento/" }   y en el archivo setup.cs se realiza inyección de dependencia del servicio externo, usando esta instrucción: services.AddScoped<IServicioExternoApi, ServicioExternoApi>().
10. La comunicación entre las dos Apis se realiza por HTTP, usando estas instrucciones:
11. public static async Task<T> GetAsync<T>(string url)
        {
            T data;

            using (HttpClient client = new())
            {                
                using HttpResponseMessage response = await client.GetAsync(url);
                using HttpContent content = response.Content;
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return data;
                }
            }
            object o = new();
            return (T)o;
        }
   12. Las dos APIs se encuentran funcionando en modo local del ambiente de desarrollo, es necesario desplegarlas para su correcto funcionamiento.
   13. Para realizar una prueba de integración completa, se debe ejecutar el script adjunto en el repositorio para la creación de la base de datos llamada PRU_MOK,
   realizar las modificaciones en el archivo appsettings.json con base en el ambiente que se instale, exponer la APi Principal APINetMok y ApiExternaMok, para que así pueda ser consumida Api Externa.
   


