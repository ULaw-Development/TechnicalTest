using System;
using System.Text;
using ULaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Emails
{
    [Obsolete("This is a stub while a template is created, you probably shouldn't be using this")]
    public class EmptyEmail : BaseEmailBuilder
    {
        public EmptyEmail( ApplicationModel model ) : base( model )
        {
        }

        protected override void BuildBody( StringBuilder builder )
        {
            builder.Append( "Empty" );
        }
    }
}
