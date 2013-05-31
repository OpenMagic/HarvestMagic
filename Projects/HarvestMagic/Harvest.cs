using CommonMagic.DataAnnotations;

namespace HarvestMagic
{
    public class Harvest
    {
        private readonly HarvestAccount _Account;

        public Harvest(HarvestAccount account)
        {
            _Account = account.Validate();
            _Account.Freeze();
        }
    }
}
