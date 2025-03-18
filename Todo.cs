using System.Text.Json.Serialization;
class Todo
{

    [JsonPropertyName("userId")]
    public int UserID { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
}