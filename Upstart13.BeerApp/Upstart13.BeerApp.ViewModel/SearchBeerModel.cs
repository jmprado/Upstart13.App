﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Upstart13.BeerApp.ViewModel
{
    public class SearchBeerModel
    {
        public int AttenuationLevel { get; set; }
        public decimal Ph { get; set; }
        public int Volume { get; set; }
        public string IngredientName { get; set; }
    }
}
