namespace GCASS_EventConnect_Event.DataAccess
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string DescripTion { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public string Location { get; set; }
        public int Status { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_time { get; set; }
        public string Updated_by { get; set; }
        public DateTime Updated_time { get; set; }

    }
}
