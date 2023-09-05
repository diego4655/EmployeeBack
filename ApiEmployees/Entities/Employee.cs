namespace ApiEmployees.Entities
{
    public class Employee
    {
        public byte employee_age { get; set; }
        public int? employee_anual_salary { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public byte id { get; set; }
        public string profile_image { get; set; }
    }
}