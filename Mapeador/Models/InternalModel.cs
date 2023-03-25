using Tools.Attributes;

namespace Mapeador.Models
{
    public class InternalModel
    {
        public string Nombre { get; set; }


        [CustomResponse(Parent = "ApellidosPaternoMaterno")]
        public string Apellidos { get; set; }


        [CustomResponse(Parent = "Tin", Child = "Root")]
        public string Rfc { get; set; }
    }
}
