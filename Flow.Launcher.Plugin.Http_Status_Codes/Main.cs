using System.Collections.Generic;
using System.Linq;

namespace Flow.Launcher.Plugin.Http_Status_Codes {
    public class Main : IPlugin {
        private PluginInitContext _context;

        private readonly Result _noResult = new Result {
            Title = "No HTTP status codes matched the query :(",
            IcoPath = "Images/icon.png"
        };

        public void Init(PluginInitContext context) {
            _context = context;
        }

        public List<Result> Query(Query query) {
            return GetResults(query.Search);
        }

        private List<Result> GetResults(string query) {
            var results = new List<Result>();
            var matchingCodes = HttpStatusCodes.Codes
                .Where(kvp => kvp.Value.Description.Contains(query, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingCodes.Any()) {
                results.AddRange(matchingCodes.Select(CreateResult));
            }
            else {
                results.Add(_noResult);
            }

            return results;
        }

        private Result CreateResult(KeyValuePair<int, (string Description, string Link)> kvp) {
            return new Result {
                Title = kvp.Value.Description,
                SubTitle = kvp.Value.Link,
                Action = c => {
                    _context.API.OpenUrl(kvp.Value.Link);
                    return true;
                },
                IcoPath = "Images/icon.png"
            };
        }
    }
}