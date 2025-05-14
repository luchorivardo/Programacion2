using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientAnimalApp
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int IdTipo { get; set; }
        public string TipoNombre { get; set; }
        public int DuenoId { get; set; }
        public string NombreDueno { get; set; }
    }

    public class CrearAnimalDTO
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }
        public int IdTipo { get; set; }
        public int DuenoId { get; set; }
    }

    public class CrearDuenoDTO
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    public class CrearAtencionDTO
    {
        public string MotivoConsulta { get; set; }
        public string Tratamiento { get; set; }
        public string Medicamentos { get; set; }
        public DateTime FechaAtencion { get; set; }
        public int AnimalId { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void MostrarAnimal(AnimalDTO animal)
        {
            Console.WriteLine($"Nombre: {animal.Nombre}\tEdad: {animal.Edad}\tRaza: {animal.Raza}");
        }

        static async Task<Uri> CrearAnimalAsync(CrearAnimalDTO animal)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/animal", animal);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        static async Task<Uri> CrearDuenioAsync(CrearDuenoDTO Dunio)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/dueno", Dunio);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        static async Task<Uri> CrearAtencionAsync(CrearAtencionDTO Atencion)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/atencion", Atencion);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }


        static async Task<List<AnimalDTO>> GetAnimalesAsync()
        {
            List<AnimalDTO> animales = null;
            HttpResponseMessage response = await client.GetAsync("api/animal");
            if (response.IsSuccessStatusCode)
            {
                animales = await response.Content.ReadAsAsync<List<AnimalDTO>>();
            }
            return animales;
        }
        static async Task<AnimalDTO> GetAnimalPorIdAsync(int id)
        {
            AnimalDTO animal = null;
            HttpResponseMessage response = await client.GetAsync($"api/animal/{id}");
            if (response.IsSuccessStatusCode)
            {
                animal = await response.Content.ReadAsAsync<AnimalDTO>();
            }
            return animal;
        }
        static async Task<HttpStatusCode> ActualizarAnimalAsync(int id, CrearAnimalDTO animal)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/animal/{id}", animal);
            return response.StatusCode;
        }

        static async Task<HttpStatusCode> EliminarAnimalAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/animal/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7178/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            bool salir = false;

            while (!salir)
            {
                try
                {
                    Console.WriteLine("Seleccione una opción: ");
                    Console.WriteLine("1 - Crear un animal");
                    Console.WriteLine("2 - Mostrar todos los animales");
                    Console.WriteLine("3 - Mostrar un animal por ID");
                    Console.WriteLine("4 - Eliminar un animal por ID");
                    Console.WriteLine("5 - Actualizar un animal por ID");
                    Console.WriteLine("6 - Crear un Dueño");
                    Console.WriteLine("7 - Crear una Atencion");
                    Console.WriteLine("0 - Salir");
                    Console.Write("Opción: ");

                    string entrada = Console.ReadLine();

                    if (int.TryParse(entrada, out int opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                var nuevo = new CrearAnimalDTO
                                {
                                    Nombre = "Firulais",
                                    Edad = 5,
                                    Sexo = "Macho",
                                    Raza = "Labrador",
                                    IdTipo = 1,
                                    DuenoId = 3
                                };

                                var urlAnimal = await CrearAnimalAsync(nuevo);
                                Console.WriteLine($"Animal creado en: {urlAnimal}");
                                break;

                            case 2:
                                var animales = await GetAnimalesAsync();
                                foreach (var a in animales)
                                {
                                    Console.WriteLine($"ID: {a.Id} - Nombre: {a.Nombre} - Edad: {a.Edad}");
                                }
                                break;

                            case 3:
                                Console.Write("Ingrese el ID del animal: ");
                                string idStr3 = Console.ReadLine();
                                if (int.TryParse(idStr3, out int idAnimal3))
                                {
                                    var animal = await GetAnimalPorIdAsync(idAnimal3);
                                    if (animal != null)
                                    {
                                        MostrarAnimal(animal);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Animal no encontrado.");
                                    }
                                }
                                break;

                            case 4:
                                Console.Write("Ingrese el ID del animal a eliminar: ");
                                string idStr4 = Console.ReadLine();
                                if (int.TryParse(idStr4, out int idAnimal4))
                                {
                                    var statusDelete = await EliminarAnimalAsync(idAnimal4);
                                    Console.WriteLine($"Eliminado (HTTP Status = {(int)statusDelete})");
                                }
                                break;

                            case 5:
                                Console.Write("Ingrese el ID del animal a actualizar: ");
                                string idStr5 = Console.ReadLine();
                                if (int.TryParse(idStr5, out int idAnimal5))
                                {
                                    var animal = await GetAnimalPorIdAsync(idAnimal5);
                                    if (animal != null)
                                    {
                                        var actualizado = new CrearAnimalDTO
                                        {
                                            Nombre = animal.Nombre,
                                            Edad = animal.Edad + 1,
                                            Sexo = animal.Sexo,
                                            Raza = animal.Raza,
                                            IdTipo = animal.IdTipo,
                                            DuenoId = animal.DuenoId
                                        };

                                        var status = await ActualizarAnimalAsync(idAnimal5, actualizado);
                                        Console.WriteLine($"Actualizado (HTTP Status = {(int)status})");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Animal no encontrado.");
                                    }
                                }
                                break;

                            case 6:
                                var duenio = new CrearDuenoDTO
                                {
                                    Nombre = "Lucho",
                                    Apellido = "Rivardo",
                                    Dni = "45507871"                                    
                                };

                                var urlDuenio = await CrearDuenioAsync(duenio);
                                Console.WriteLine($"Animal creado en: {urlDuenio}");
                            break;

                            case 7:
                                var atencion = new CrearAtencionDTO
                                {
                                     MotivoConsulta = "castracion",
                                     Tratamiento = "cirujia",
                                     Medicamentos = "paracetamol",
                                     FechaAtencion = DateTime.Now,
                                     AnimalId = 5
                                };

                                var urlAtencion = await CrearAtencionAsync(atencion);
                                Console.WriteLine($"Animal creado en: {urlAtencion}");
                                break;

                            case 0:
                                Console.WriteLine("Saliendo del programa...");
                                salir = true;
                                break;

                            default:
                                Console.WriteLine("Opción no válida.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Debe ingresar un número.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.ReadLine();

           


            // Crear animal


            // Obtener el animal
            //var animal = await ObtenerAnimalAsync(url.PathAndQuery);
            //MostrarAnimal(animal);



            //// Actualizar
            //Console.WriteLine("Actualizando edad...");
            //nuevo.Edad = 6;
            //var statusPut = await ActualizarAnimalAsync(animal.Id, nuevo);
            //Console.WriteLine($"Actualizado (HTTP Status = {(int)statusPut})");

            //// Obtener nuevamente
            //animal = await ObtenerAnimalAsync($"api/animal/{animal.Id}");
            //MostrarAnimal(animal);

            //// Eliminar
            //var statusDelete = await EliminarAnimalAsync(animal.Id);
            //Console.WriteLine($"Eliminado (HTTP Status = {(int)statusDelete})");
        }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.ReadLine();
        }
    }
