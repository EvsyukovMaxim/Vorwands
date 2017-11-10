using Newtonsoft.Json;


namespace DoubleGIS.Vorwands.Client.Responses
{

    public class CommentsResponse
    {
        [JsonProperty("comments")]
        public Comment[] Comments { get; set; }
    }

    public class Comment
    {
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdById")]
        public long CreatedById { get; set; }

        [JsonProperty("creationDateUtc")]
        public string CreationDateUtc { get; set; }

        [JsonProperty("entityId")]
        public long EntityId { get; set; }

        [JsonProperty("entityType")]
        public string EntityType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("modificationDateUtc")]
        public string ModificationDateUtc { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("modifiedById")]
        public long ModifiedById { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
