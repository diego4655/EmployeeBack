namespace ApiEmployees.Util
{
    public class EnvironmentVariables
    {
        public static string EmployeesUrl => Environment.GetEnvironmentVariable("EmployeesUrl");
        public static string FailedStatus => Environment.GetEnvironmentVariable("FailedStatus");
        public static string SuccessStatus => Environment.GetEnvironmentVariable("SuccessStatus");
    }
}