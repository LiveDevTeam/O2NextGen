namespace O2NextGen.SmallTalk.Api.Models
{
    public class SessionModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }

    }

    public class UserModel
    {

    }

    public class DepartmentModel
    {
        public string Name { get; set; }
    }

    public class SessionMessageModel
    {
        public long Id { get; set; }
        public string Message { get; set; }
    }
}
