using System.Text.Json.Serialization;

namespace Books.BLL
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortType
    {
        None,
        SortByTitle,
        SortByAuthor,
        SortByYear
    }
}
