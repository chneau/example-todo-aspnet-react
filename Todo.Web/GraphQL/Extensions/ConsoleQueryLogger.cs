using HotChocolate.Types;
using HotChocolate.Execution.Instrumentation;
using StackExchange.Profiling;
using HotChocolate.Execution;
using System.Diagnostics;
using HotChocolate.Language;
using System.Text;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Todo.Web.GraphQL.GraphQL.Extensions
{
    public class ConsoleQueryLogger : DiagnosticEventListener
    {
        private static Stopwatch _queryTimer = default!;
        private readonly ILogger<ConsoleQueryLogger> _logger;
        public ConsoleQueryLogger(ILogger<ConsoleQueryLogger> logger)
        {
            _logger = logger;
        }

        public override IActivityScope ExecuteRequest(IRequestContext context)
        {
            return new RequestScope(_logger, context);
        }

        private class RequestScope : IActivityScope
        {
            private readonly IRequestContext _context;
            private readonly ILogger<ConsoleQueryLogger> _logger;
            public RequestScope
                (ILogger<ConsoleQueryLogger> logger,
                     IRequestContext context)
            {
                _logger = logger;
                _context = context;
                _queryTimer = new Stopwatch();
                _queryTimer.Start();
            }

            public void Dispose()
            {
                if (_context.Document is not null)
                {
                    StringBuilder stringBuilder =
                        new(_context.Document.ToString(true));
                    stringBuilder.AppendLine();
                    if (_context.Variables != null)
                    {
                        var variablesConcrete =
                            _context.Variables!.ToList();
                        if (variablesConcrete.Count > 0)
                        {
                            stringBuilder.
                                AppendFormat($"Variables {Environment.NewLine}");
                            try
                            {
                                foreach (var variableValue in _context.Variables!)
                                {
                                    static string PadRightHelper
                                        (string existingString, int lengthToPadTo)
                                    {
                                        if (string.IsNullOrEmpty(existingString))
                                            return "".PadRight(lengthToPadTo);
                                        if (existingString.Length > lengthToPadTo)
                                            return existingString.Substring(0, lengthToPadTo);
                                        return existingString + " ".PadRight(lengthToPadTo - existingString.Length);
                                    }
                                    stringBuilder.AppendFormat(
                                        $"  {PadRightHelper(variableValue.Name, 20)} :  {PadRightHelper(variableValue.Value.ToString(), 20)}: {variableValue.Type}");
                                    stringBuilder.AppendFormat($"{Environment.NewLine}");
                                }
                            }
                            catch
                            {
                                // all input type records will land here.
                                stringBuilder.Append("  Formatting Variables Error. Continuing...");
                                stringBuilder.AppendFormat($"{Environment.NewLine}");
                            }
                        }
                    }
                    _queryTimer.Stop();
                    stringBuilder.AppendFormat(
                        $"Ellapsed time for query is {_queryTimer.Elapsed.TotalMilliseconds:0.#} milliseconds.");
                    _logger.LogInformation(stringBuilder.ToString());
                }
            }
        }
    }
}
