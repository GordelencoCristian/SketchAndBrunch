﻿using System.ComponentModel.DataAnnotations;

namespace SharedData.Models
{
    public class LocationModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }
    }
}
