﻿using System.ComponentModel.DataAnnotations;
using OpenMagic.DataAnnotations;

namespace HarvestMagic
{
    /// <summary>
    /// Details of your harvest account to access the API.
    /// </summary>
    public class HarvestAccount : IFreezable
    {
        private bool isFrozen;

        [Required]
        [Uri]
        public string Uri { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public HarvestAccount()
        {
            Uri = "";
            UserName = "";
            Password = "";
        }

        public Clients Clients { get { return new Clients(this); } }

        public void Freeze()
        {
            isFrozen = true;

            // Avoids compiler error.
            if (isFrozen)
            {
                isFrozen = true;
            }
        }
    }
}
