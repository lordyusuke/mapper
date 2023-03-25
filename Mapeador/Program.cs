using Mapeador.Models;
using Tools.Mapper;

namespace Mapeador
{
    class Program
    {
        static void Main()
        {
            ExternalModel ext = new ExternalModel
            {
                Nombre = "Arturo",
                ApellidosPaternoMaterno = "Alamilla",
                Tin = new ExternalChildModel { Root = "Arturo Alamilla" }
            };
            var intModel = Mapper.Map<InternalModel, ExternalModel>(ext);
        }
    }
}
