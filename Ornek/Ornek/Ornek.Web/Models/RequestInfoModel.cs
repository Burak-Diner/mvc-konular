using System.Collections.Generic;

namespace Ornek.Web.Models
{
    public class RequestInfoModel
    {
        public IDictionary<string, string?> Query { get; init; } = new Dictionary<string, string?>();
        public IDictionary<string, string> Headers { get; init; } = new Dictionary<string, string>();
        public string? Path { get; init; }
    }
}
