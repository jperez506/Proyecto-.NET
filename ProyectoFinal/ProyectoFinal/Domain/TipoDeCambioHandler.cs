using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ProyectoFinal.Api.Domain
{
    public class TipoDeCambioHandler
    {
        /// <summary>
        /// Llama al servicio soap para conseguir informacion del tipo de cambio.
        /// </summary>
        /// <param name="fecha">fecha para la consulta</param>
        /// <returns>informacion del banco como <see cref="string"/></returns>
        public string consigueTipoDeCambio(string fecha) 
        {
           
            DateTime date = new DateTime();
            DateTime.TryParseExact(fecha, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
            string formatted = date.ToString("dd/MM/yyyy");
            var requestUrl = $"https://gee.bccr.fi.cr/Indicadores/Suscripciones/WS/wsindicadoreseconomicos.asmx/ObtenerIndicadoresEconomicos?Indicador=317&FechaInicio={formatted}&FechaFinal={formatted}&Nombre=Genesis&SubNiveles=N&CorreoElectronico=ivog28@gmail.com&Token=1VIL5LEVA2";
            XmlTextReader reader = new XmlTextReader(requestUrl);
            List<string> lista = new List<string>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:
                        lista.Add(reader.Value);
                        break;
                }
            }

            return lista[2];
        }
    }
}
