﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Upstart13.BeerApp.Entities
{
    public partial class IngredientType
    {
        public IngredientType()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public int IngredienteTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}