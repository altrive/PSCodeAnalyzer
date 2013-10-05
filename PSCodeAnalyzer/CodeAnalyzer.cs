using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management.Automation;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Management.Automation.Language;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;

namespace PSCodeAnalyzer
{
    public class CodeAnalyzer
    {
        private readonly ITextView _textView;

        internal CodeAnalyzer(ITextView textView)
        {
            Contract.Assert(textView != null);
            this._textView = textView;
        }


        //Analyze current snapshot
        public Result Analyze()
        {
            var snapshot = _textView.TextSnapshot;
            var context = ScriptContext.Parse(snapshot.GetText());
            return new Result
            {
                Context = context,
                TextSnapshot = snapshot
            };
        }

        public Task<Result> AnalyzeAsync()
        {
            var tcs = new TaskCompletionSource<Result>();
            //TODO:Async Support
            var task = tcs.Task.ContinueWith((t) =>
            {
                var result = Analyze();
                tcs.SetResult(result);
            });

            return (Task<Result>)task;
        }

        public class Result
        {
            public ITextSnapshot TextSnapshot { get; set; }
            //public ITextVersion Version { get; set; }


            public ScriptContext Context { get; set; }

            public Result()
            {
            }
        }
    }
}
