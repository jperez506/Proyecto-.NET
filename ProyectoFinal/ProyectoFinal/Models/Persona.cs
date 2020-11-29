using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Api.Models
{
    public class Persona
    {
        public Persona()
        {
            RiesgoFinanciero =  new Random().Next(1, 4);
        }

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Salario { get; set; }
        public string Provincia { get; set; }
        /// <summary>
        /// 1 = mujer
        /// 0 = hombre
        /// </summary>
        public bool Genero { get; set; }
        public int Edad { get; set; }
        /// <summary>
        /// numero random del 1 al 3
        /// </summary>
        public int RiesgoFinanciero { get; set; }

    }
}
