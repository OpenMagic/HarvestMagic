using NullGuard;

namespace HarvestMagic.JsonModels
{
    [NullGuard(ValidationFlags.Methods)]
    public class ClientJsonModel
    {
        public HarvestMagic.Client client { get; set; }
    }
}
