using System.ComponentModel;

namespace CantinaFacil.Shared.Kernel.Domain.Enums
{
    public enum PerfilEnum
    {
        [Description("Cantina")]
        CANTINA = 1,

        [Description("Tutor")]
        TUTOR = 2,

        [Description("Estudante")]
        ESTUDANTE = 3
    }
}
