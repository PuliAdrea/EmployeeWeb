using System.Text.Json.Serialization;

namespace EmployeeWeb.Models
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("contactNumber")]
        public string ContactNumber { get; set; } = string.Empty;

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("dob")]
        public string Dob { get; set; } = string.Empty;

        [JsonPropertyName("salary")]
        public decimal Salary { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
    }
}
