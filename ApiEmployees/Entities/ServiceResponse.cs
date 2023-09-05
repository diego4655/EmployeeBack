namespace ApiEmployees.Entities
{
    public class ServiceResponse
    {
        public object Data { get; set; }
        public string Exception { get; set; }
        public string Message { get; set; }
        public string status { get; set; }
    }
}