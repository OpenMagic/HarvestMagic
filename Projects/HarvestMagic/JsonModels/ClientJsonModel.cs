using NullGuard;

namespace HarvestMagic.JsonModels
{
    [NullGuard(ValidationFlags.Methods)]
    public class ClientJsonModel
    {
        public HarvestMagic.Models.Client client { get; set; }
    }
}
