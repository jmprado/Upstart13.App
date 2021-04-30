using System;

namespace Upstart13.BeerApp.ViewModel
{
    public class IngredientModel
    {
        public int IngredientId { get; set; }
        public int IngredienteTypeId { get; set; }
        public string IngredientTypeName
        {
            get
            {
                return Enum.GetName(typeof(IngredientTypes), this.IngredienteTypeId);
            }
        }

        public int BeerId { get; set; }
        public string Name { get; set; }
        public string AmountUnit { get; set; }
        public decimal AmountValue { get; set; }
        public string Add { get; set; }
        public string Attribute { get; set; }

        public enum IngredientTypes
        {
            Malt = 1,
            Hops = 2,
            Yeast = 3
        }
    }
}