using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plattform_partizipatives_neophytenmanagement.Models
{
    public enum NegotiationStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    public class Negotiation
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public User InitiatedByUser { get; set; }
        public FarmerHelpRequest FarmerHelpRequest { get; set; }
        public HelperHelpOffer HelperHelpOffer { get; set; }
        public NegotiationStatus FarmerStatus { get; set; }
        public NegotiationStatus HelperStatus { get; set; }
    }
}