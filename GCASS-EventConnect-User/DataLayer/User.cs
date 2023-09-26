namespace GCASS_EventConnect_User.DataLayer
{
    public class User
    {
        public Guid id { get; set; }

        public String username { get; set; }

        public String password { get; set; }

        public int type { get; set; }

        public DateTime createdTime { get; set; }

        public Guid updatedBy { get; set; }

        public DateTime updatedTime { get; set; }
    }
}
