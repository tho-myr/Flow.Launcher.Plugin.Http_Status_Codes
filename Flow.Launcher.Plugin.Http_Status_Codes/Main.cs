using System.Collections.Generic;

namespace Flow.Launcher.Plugin.Http_Status_Codes
{
    public class Main : IPlugin
    {
        internal PluginInitContext Context;

        public List<Result> Query(Query query)
        {
            var result = new Result
            {
                Title = "Hello World from Http Status Codes Plugin",
                SubTitle = $"Query: {query.Search}",
                Action = c =>
                {
                    Context.API.ShowMsg("Hello World from Http Status Codes Plugin", "This is the query: " + query.Search);
                    return true;
                },
                IcoPath = "Images/app.png"
            };
            return new List<Result> { result };
        }

        public void Init(PluginInitContext context)
        {
            Context = context;
        }
    }
}