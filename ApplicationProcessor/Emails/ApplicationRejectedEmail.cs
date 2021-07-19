using System;
using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;
using ULaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Emails
{
    public class ApplicationRejectedEmail : BaseEmailBuilder, IEmailBuilder
    {
        public ApplicationRejectedEmail( ApplicationModel model ) : base( model )
        {
        }

        protected override void BuildBody( StringBuilder builder )
        {
            builder.AppendFormat( "<p> Dear {0}, </p>", Model.User.FirstName );
            builder.Append( "<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion." );
            builder.Append( "<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk." );
        }
    }
}
