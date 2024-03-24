using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plattform_partizipatives_neophytenmanagement.Models
{
    public class HelperHelpOffer
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string Location { get; set; }

        public double DistanceFromLocation { get; set; }

        public int WorkVolume { get; set; }

        public int NumberOfHelpers { get; set; }
    }
}