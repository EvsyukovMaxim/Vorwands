using Newtonsoft.Json;


namespace DoubleGIS.Vorwands.Client.Responses
{

    public class CommentsResponse
    {
        public Comment[] Comments { get; set; }
    }

    public class Comment
    {
        public string CreatedBy { get; set; }

        public long CreatedById { get; set; }

        public string CreationDateUtc { get; set; }

        public long EntityId { get; set; }

        public string EntityType { get; set; }

        public long Id { get; set; }

        public string ModificationDateUtc { get; set; }

        public string ModifiedBy { get; set; }

        public long ModifiedById { get; set; }

        public string Text { get; set; }
    }
}
