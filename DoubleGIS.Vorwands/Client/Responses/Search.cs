using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleGIS.Vorwands.Client.Responses
{
    public class ResultItem
    {
        [DisplayName("Название")]
        public string Title { get; set; }

        public int AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; }
        public string Branch { get; set; }
        public int BranchId { get; set; }
        public object CardCode { get; set; }
        public string CardCodeString { get; set; }
        public string CardTitle { get; set; }
        public DateTime CreationDateUtc { get; set; }
        public DateTime CloseDateUtc { get; set; }
        public bool HasAttachments { get; set; }
        public bool HasLinkedVorwands { get; set; }
        public bool HasLinkedFeature { get; set; }
        public int Id { get; set; }
        public DateTime PlanDateUtc { get; set; }
        public string Priority { get; set; }
        public string Resolution { get; set; }
        public string Status { get; set; }


        public string Type { get; set; }
        public double LinkedLat { get; set; }
        public double LinkedLon { get; set; }
    }

    public class Paging
    {
        public List<ResultItem> ResultItems { get; set; }
        public int Total { get; set; }
        public int From { get; set; }
        public int PageSize { get; set; }
        public bool IgnorePaging { get; set; }
    }

    public class VorwandSearchResult
    {
        public Paging Paging { get; set; }
    }
}
