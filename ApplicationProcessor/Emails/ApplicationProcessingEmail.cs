using System;
using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;
using ULaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Emails
{
    public class ApplicationProcessingEmail : BaseEmailBuilder, IEmailBuilder
    {
        public ApplicationProcessingEmail( ApplicationModel model ) : base( model )
        {
        }

        protected override void BuildBody( StringBuilder builder )
        {
            builder.Append( string.Format( "<p> Dear {0}, </p>", Model.User.FirstName ) );
            builder.Append( string.Format( "<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", Model.CourseCode, Model.StartDate.ToLongDateString() ) );
            builder.Append( "<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk." );
        }
    }
}
