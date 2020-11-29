using System;
using System.Collections.Generic;

namespace ProyectoFinal.Api.Domain
{
    public class ImageHandler
    {
        Dictionary<string, string> images = new Dictionary<string, string>() {
            { "jpg", @"./Domain/Assets/Venecia.jpg" },
            { "png", @"./Domain/Assets/Hulk.png" }
        };
        public Byte[] GetImagen(string formato)
        {
            if (images.TryGetValue(formato, out string path))
                return System.IO.File.ReadAllBytes(path);
            else
                throw new NotSupportedException($"El formato {formato} no es reconocido por el sistema.");
        }
    }
}
