using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class UserErrorResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("hint")]
        public string Hint { get; set; }

        [JsonPropertyName("next_steps")]
        public List<string> NextSteps { get; set; }

        [JsonPropertyName("docs_url")]
        public string DocsUrl { get; set; }

        [JsonPropertyName("_meta")]
        public Meta Meta { get; set; }
    }

    public class UserCreatedResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("_meta")]
        public Meta Meta { get; set; }
    }
    public class UserUpdatedResponse
    {
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("_meta")]
        public Meta Meta { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("powered_by")]
        public string PoweredBy { get; set; }

        [JsonPropertyName("docs_url")]
        public string DocsUrl { get; set; }

        [JsonPropertyName("upgrade_url")]
        public string UpgradeUrl { get; set; }

        [JsonPropertyName("example_url")]
        public string ExampleUrl { get; set; }

        [JsonPropertyName("variant")]
        public string Variant { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("cta")]
        public Cta Cta { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }
    }

    public class Cta
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
