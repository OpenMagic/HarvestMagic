using CommonMagic.DataAnnotations;

namespace HarvestMagic
{
    public class Harvest
    {
        private readonly HarvestAccount account;

        public Harvest(HarvestAccount account)
        {
            this.account = account.Validate();
        }
    }
}
