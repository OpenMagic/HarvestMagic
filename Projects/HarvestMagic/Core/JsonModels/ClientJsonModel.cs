using NullGuard;

namespace HarvestMagic.Core.JsonModels
{
    [NullGuard(ValidationFlags.Methods)]
    internal class ClientJsonModel
    {
        public HarvestMagic.Client Client { get; set; }
    }
}
