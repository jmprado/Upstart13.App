using System;

namespace Upstart13.BeerApp.ViewModel
{
    public class MethodModel
    {
        public int MethodId { get; set; }
        public int MethodTypeId { get; set; }
        public string MethodTypeName
        {
            get
            {
                return Enum.GetName(typeof(MethodTypes), this.MethodTypeId);
            }
        }
        public int BeerId { get; set; }
        public string TemperatureUnit { get; set; }
        public int TemperatureValue { get; set; }
        public int Duration { get; set; }

        public enum MethodTypes
        {
            MashTemp = 1,
            Fermentation = 2,
            Twist = 3
        }
    }
}