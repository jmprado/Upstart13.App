using System.Collections.Generic;

namespace Upstart13.BeerApp.ViewModel
{
    public class BeerModel
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string FirstBrewed { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Abv { get; set; }
        public decimal? Ibu { get; set; }
        public decimal? TargetFg { get; set; }
        public decimal? TargetOg { get; set; }
        public decimal? Ebc { get; set; }
        public decimal? Srm { get; set; }
        public decimal? Ph { get; set; }
        public int? AttenuationLevel { get; set; }
        public string BrewerTips { get; set; }
        public string ContributedBy { get; set; }

        public IEnumerable<FoodPairingModel> ListFoodPairing { get; set; }
        public IEnumerable<IngredientModel> Ingredient { get; set; }
        public IEnumerable<MethodModel> Method { get; set; }
        public IEnumerable<VolumeModel> Volume { get; set; }
    }
}
