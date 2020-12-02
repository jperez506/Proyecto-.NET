using ProyectoFinal.Api.Models;
using ProyectoFinal.Data.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Api.Domain
{
    public class PersonaHandler
    {
        private ProyectoFinalContext context;
        public PersonaHandler() 
        {
            this.context = new ProyectoFinalContext();
        }
        /// <summary>
        /// Busca personas
        /// </summary>
        /// <param name="genero">true para mujeres, false para hombres</param>
        /// <param name="edadInicial">menor edad</param>
        /// <param name="edadFinal">mayor edad</param>
        /// <returns>personas encontradas </returns>
        /// 
        public List<Persona> getPersonas(bool genero, int edadInicial, int edadFinal) 
        {
            return context.Personas
                .Where(p => p.Genero == genero && p.Edad >= edadInicial && p.Edad <= edadFinal)
                .ToList();
        }
        public List<Persona> getPersonasConMejorSalario(string provincia) 
        {
            return context.Personas
                .Where(p => p.Provincia == provincia)
                .OrderByDescending(p => p.Salario)
                .Take(100)
                .ToList();
        }

        public int getNumeroRandom() 
        { 
            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, 4); 
            return RandomNumber;
        }

        /// <summary>
        /// Esto es para popular la base de datos, lo ignoramos porfa
        /// </summary>
        /// <param name="cantidad"></param>
        public void PopularLaDB(int cantidad)
        {
            Persona persona;
            var randomizer = new Random();
            var provincias = new Dictionary<int, string> 
            {
                { 1, "SanJose" },
                { 2, "Heredia" },
                { 3, "Alajuela" },
                { 4, "Puntarenas" },
                { 5, "Limon"},
                { 6, "Guanacaste" },
                { 7, "Cartago" },
            };
            for (int i = 0; i < cantidad; i++) 
            {
                persona = new Persona()
                {
                    Nombre = RandomString(7, randomizer),
                    Edad = randomizer.Next(1, 80),
                    Genero = randomizer.Next(0, 2) == 1,
                    Provincia = provincias.GetValueOrDefault(randomizer.Next(1,8), string.Empty),
                    Salario = randomizer.Next(300000, 8000001),
                };
                context.Add(persona);
            }
            context.SaveChanges();
        }
        private string RandomString(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
