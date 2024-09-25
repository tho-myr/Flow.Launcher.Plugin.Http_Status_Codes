using System.Collections.Generic;
using System.Linq;

namespace Flow.Launcher.Plugin.Http_Status_Codes
{
    public class Main : IPlugin
    {
        internal PluginInitContext Context;

        /// <summary>
        /// Processes the query input and returns a list of results.
        /// </summary>
        /// <param name="query">The query input from the user.</param>
        /// <returns>A list of results matching the query.</returns>
        public List<Result> Query(Query query)
        {
            var results = new List<Result>();

            if (IsStatusCodeQuery(query.Search, out int statusCode))
            {
                AddStatusCodeResult(results, statusCode);
            }
            else
            {
                AddDescriptionResults(results, query.Search);
            }

            return SortResults(results);
        }

        /// <summary>
        /// Determines if the query input is a valid HTTP status code.
        /// </summary>
        /// <param name="query">The query input from the user.</param>
        /// <param name="statusCode">The parsed status code if the query is valid.</param>
        /// <returns>True if the query is a valid status code, otherwise false.</returns>
        private bool IsStatusCodeQuery(string query, out int statusCode)
        {
            return int.TryParse(query, out statusCode) && HttpStatusCodes.Codes.ContainsKey(statusCode);
        }

        /// <summary>
        /// Adds a result for a valid HTTP status code query.
        /// </summary>
        /// <param name="results">The list of results to add to.</param>
        /// <param name="statusCode">The valid HTTP status code.</param>
        private void AddStatusCodeResult(List<Result> results, int statusCode)
        {
            var statusInfo = HttpStatusCodes.Codes[statusCode];
            results.Add(new Result
            {
                Title = $"{statusCode} - {statusInfo.Description}",
                SubTitle = statusInfo.Link,
                Action = c =>
                {
                    Context.API.OpenUrl(statusInfo.Link);
                    return true;
                },
                IcoPath = "Images/icon.png"
            });
        }

        /// <summary>
        /// Adds results for queries that match descriptions of HTTP status codes.
        /// </summary>
        /// <param name="results">The list of results to add to.</param>
        /// <param name="query">The query input from the user.</param>
        private void AddDescriptionResults(List<Result> results, string query)
        {
            var matchingCodes = HttpStatusCodes.Codes
                .Where(kvp => kvp.Value.Description.Contains(query, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingCodes.Any())
            {
                results.AddRange(matchingCodes.Select(kvp => new Result
                {
                    Title = $"{kvp.Key} - {kvp.Value.Description}",
                    SubTitle = kvp.Value.Link,
                    Action = c =>
                    {
                        Context.API.OpenUrl(kvp.Value.Link);
                        return true;
                    },
                    IcoPath = "Images/icon.png"
                }));
            }
            else
            {
                results.Add(new Result
                {
                    Title = "No matching HTTP Status Codes found :(",
                    SubTitle = $"Query: {query}",
                    Action = c =>
                    {
                        Context.API.ShowMsg("No matching HTTP Status Codes found", "Please enter a valid HTTP status code or description.");
                        return true;
                    },
                    IcoPath = "Images/icon.png"
                });
            }
        }

        /// <summary>
        /// Sorts the results by status code and appends non-status code results at the end.
        /// </summary>
        /// <param name="results">The list of results to sort.</param>
        /// <returns>A sorted list of results.</returns>
        private List<Result> SortResults(List<Result> results)
        {
            var sortedResults = results
                .Where(r => int.TryParse(r.Title.Split(' ')[0], out _))
                .OrderBy(r => int.Parse(r.Title.Split(' ')[0]))
                .ToList();

            sortedResults.AddRange(results.Where(r => !int.TryParse(r.Title.Split(' ')[0], out _)));

            return sortedResults;
        }

        /// <summary>
        /// Initializes the plugin with the given context.
        /// </summary>
        /// <param name="context">The plugin initialization context.</param>
        public void Init(PluginInitContext context)
        {
            Context = context;
        }
    }
}