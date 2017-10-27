using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleGIS.Vorwands.Client.Responses
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    public class VorwandFull
    {
        public string CreatedName { get; set; }
        public long ModifiedBy { get; set; }
        public bool CanCreateCardInInfoRussia { get; set; }
        public long BranchId { get; set; }
        public string Address { get; set; }
        public string BranchName { get; set; }
        public string CloseDateUtc { get; set; }
        public Card[] Cards { get; set; }
        public long CreatedBy { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public string CreationDateUtc { get; set; }
        public bool HasContactEmail { get; set; }
        public bool IsRegional { get; set; }
        public bool IsErrorState { get; set; }
        public string ModificationDateUtc { get; set; }
        public string PlanDateUtc { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string ModifiedName { get; set; }
        public string OriginType { get; set; }
        public string Resolution { get; set; }
        public string Priority { get; set; }
        public bool SentRequestToInfoRussia { get; set; }
        public string SourceUrl { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public string Status { get; set; }
        public Vorwand[] Vorwands { get; set; }
    }

    public class Card
    {
        public long CardCode { get; set; }
        public AnotherVorwand[] AnotherVorwands { get; set; }
        public string CardName { get; set; }
    }

    public class AnotherVorwand
    {
        public string Status { get; set; }
        public string LinkName { get; set; }
        public long VorwandId { get; set; }
    }

    public class Vorwand
    {
        public string LinkName { get; set; }
        public string Status { get; set; }
        public long BranchId { get; set; }
        public long LinkedTo { get; set; }
        public string Type { get; set; }
        public long VorwandId { get; set; }
    }
}

