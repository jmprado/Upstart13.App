﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Upstart13.BeerApp.Entities
{
    public partial class FoodPairing
    {
        public int FoodPairingId { get; set; }
        public int? BeerId { get; set; }
        public string Food { get; set; }

        [ForeignKey("BeerId")]
        public virtual Beer Beer { get; set; }
    }
}