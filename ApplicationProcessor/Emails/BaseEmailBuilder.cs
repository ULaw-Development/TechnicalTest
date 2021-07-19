using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;
using ULaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Emails
{
    /// <summary>
    /// In an ideal world these emails would come from a template engine (such as RazorLite) and the tests check 
    /// that the correct template was called and there are separate tests for checking a template renders correctly.
    /// </summary>
    public abstract class BaseEmailBuilder : IEmailBuilder
    {
        protected readonly Dictionary<string, string> TemplateParams;

        protected ApplicationModel Model { get; }

        public BaseEmailBuilder( ApplicationModel model, Dictionary<string, string> templateParams = null )
        {
            Model = model;
            TemplateParams = templateParams;
        }

        public string Build(  )
        {
            StringBuilder builder = new StringBuilder();
            builder.Append( Header );
            BuildBody( builder );
            builder.Append( Footer );
            return builder.ToString();
        }

        protected virtual string Header { get { return "<html><body><h1>Your Recent Application from the University of Law</h1>"; } }
        protected virtual string Footer { get { return "<br/> Yours sincerely,<p/> The Admissions Team,</body></html>"; } }



        protected abstract void BuildBody( StringBuilder builder );

    }
}