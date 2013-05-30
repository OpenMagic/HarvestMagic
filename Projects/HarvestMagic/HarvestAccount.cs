using System.ComponentModel.DataAnnotations;
using CommonMagic.DataAnnotations;

namespace HarvestMagic
{
    /// <summary>
    /// Details of your harvest account to access the API.
    /// </summary>
    public class HarvestAccount
    {
        [Required]
        [Uri]
        public string Uri { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
