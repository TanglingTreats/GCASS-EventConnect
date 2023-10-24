namespace GCASS_EventConnect_User.DataLayer
{
    public class User
    {
        public Guid id { get; set; }

        public String username { get; set; }

        public String password { get; set; }

        public int type { get; set; }

        public DateTime created_time { get; set; }

        public DateTime updated_time { get; set; }
    }
}
