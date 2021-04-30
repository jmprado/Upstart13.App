﻿using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Upstart13.BeerApp.ViewModel
{

    public partial class PunkApiBeerModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("first_brewed")]
        public string FirstBrewed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("abv")]
        public double Abv { get; set; }

        [JsonProperty("ibu")]
        public long Ibu { get; set; }

        [JsonProperty("target_fg")]
        public long TargetFg { get; set; }

        [JsonProperty("target_og")]
        public long TargetOg { get; set; }

        [JsonProperty("ebc")]
        public long Ebc { get; set; }

        [JsonProperty("srm")]
        public long Srm { get; set; }

        [JsonProperty("ph")]
        public double Ph { get; set; }

        [JsonProperty("attenuation_level")]
        public long AttenuationLevel { get; set; }

        [JsonProperty("volume")]
        public PunkApiBoilVolume Volume { get; set; }

        [JsonProperty("boil_volume")]
        public PunkApiBoilVolume BoilVolume { get; set; }

        [JsonProperty("method")]
        public PunkApiMethod Method { get; set; }

        [JsonProperty("ingredients")]
        public PunkApiIngredients Ingredients { get; set; }

        [JsonProperty("food_pairing")]
        public List<string> FoodPairing { get; set; }

        [JsonProperty("brewers_tips")]
        public string BrewersTips { get; set; }

        [JsonProperty("contributed_by")]
        public string ContributedBy { get; set; }
    }

    public partial class PunkApiBoilVolume
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public partial class PunkApiIngredients
    {
        [JsonProperty("malt")]
        public List<PunkApiMalt> Malt { get; set; }

        [JsonProperty("hops")]
        public List<PunkApiHop> Hops { get; set; }

        [JsonProperty("yeast")]
        public string Yeast { get; set; }
    }

    public partial class PunkApiHop
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public PunkApiBoilVolume Amount { get; set; }

        [JsonProperty("add")]
        public string Add { get; set; }

        [JsonProperty("attribute")]
        public string Attribute { get; set; }
    }

    public partial class PunkApiMalt
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public PunkApiBoilVolume Amount { get; set; }
    }

    public partial class PunkApiMethod
    {
        [JsonProperty("mash_temp")]
        public List<PunkApiMashTemp> MashTemp { get; set; }

        [JsonProperty("fermentation")]
        public PunkApiFermentation Fermentation { get; set; }

        [JsonProperty("twist")]
        public string Twist { get; set; }
    }

    public partial class PunkApiFermentation
    {
        [JsonProperty("temp")]
        public PunkApiBoilVolume Temp { get; set; }
    }

    public partial class PunkApiMashTemp
    {
        [JsonProperty("temp")]
        public PunkApiBoilVolume Temp { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
}

