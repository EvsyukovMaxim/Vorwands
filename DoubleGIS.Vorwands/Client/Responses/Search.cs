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

        public int assignedToUserId { get; set; }
        public string assignedToUserName { get; set; }
        public string branch { get; set; }
        public int branchId { get; set; }
        public object cardCode { get; set; }
        public string cardCodeString { get; set; }
        public string cardTitle { get; set; }
        public DateTime creationDateUtc { get; set; }
        public DateTime closeDateUtc { get; set; }
        public bool hasAttachments { get; set; }
        public bool hasLinkedVorwands { get; set; }
        public bool hasLinkedFeature { get; set; }
        public int id { get; set; }
        public DateTime planDateUtc { get; set; }
        public string priority { get; set; }
        public string resolution { get; set; }
        public string status { get; set; }


        public string type { get; set; }
        public double linkedLat { get; set; }
        public double linkedLon { get; set; }
    }

    public class Paging
    {
        public List<ResultItem> ResultItems { get; set; }
        public int total { get; set; }
        public int from { get; set; }
        public int pageSize { get; set; }
        public bool ignorePaging { get; set; }
    }

    public class VorwandSearchResult
    {
        public Paging Paging { get; set; }
    }
}
