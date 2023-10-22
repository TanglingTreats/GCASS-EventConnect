using System.Diagnostics.CodeAnalysis;

namespace GCASS_EventConnect_Event.DataAccess
{
    public class Event
    {
        [NotNull]
        public string Id { get; set; }
        [NotNull]

        public string Title { get; set; }
        public string Type { get; set; }
        public string DescripTion { get; set; }
        [NotNull]
        public DateTime Start_time { get; set; }
        [NotNull]
        public DateTime End_time { get; set; }
        public string Location { get; set; }
        [NotNull]
        public int Status { get; set; }
        [NotNull]
        public string Created_by { get; set; }
        [NotNull]
        public DateTime Created_time { get; set; }
        public string Updated_by { get; set; }
        public DateTime Updated_time { get; set; }

    }
}
