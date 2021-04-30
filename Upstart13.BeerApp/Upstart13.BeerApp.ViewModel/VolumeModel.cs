using System;

namespace Upstart13.BeerApp.ViewModel
{
    public class VolumeModel
    {
        public int VolumeId { get; set; }
        public int VolumeTypeId { get; set; }
        public string VolumeTypeName
        {
            get { return Enum.GetName(typeof(VolumeTypes), this.VolumeTypeId); }
        }
        public int BeerId { get; set; }
        public string VolumeUnit { get; set; }
        public int? VolumeValue { get; set; }

        public enum VolumeTypes
        {
            Volume = 1,
            BoilVolume = 2
        }
    }
}