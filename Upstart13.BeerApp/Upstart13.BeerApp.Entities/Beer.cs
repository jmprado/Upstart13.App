﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Upstart13.BeerApp.Entities
{
    public partial class Beer
    {
        public Beer()
        {
            FoodPairing = new HashSet<FoodPairing>();
            Ingredient = new HashSet<Ingredient>();
            Method = new HashSet<Method>();
            Volume = new HashSet<Volume>();
        }

        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string FirstBrewed { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Abv { get; set; }
        public decimal? Ibu { get; set; }
        public int? TargetFg { get; set; }
        public int? TargetOg { get; set; }
        public int? Ebc { get; set; }
        public int? Srm { get; set; }
        public decimal? Ph { get; set; }
        public int? AttenuationLevel { get; set; }
        public string BrewerTips { get; set; }
        public string ContributedBy { get; set; }

        public virtual ICollection<FoodPairing> FoodPairing { get; set; }
        public virtual ICollection<Ingredient> Ingredient { get; set; }
        public virtual ICollection<Method> Method { get; set; }
        public virtual ICollection<Volume> Volume { get; set; }
    }
}