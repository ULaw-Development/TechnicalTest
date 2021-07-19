using System;
using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;
using ULaw.ApplicationProcessor;
using ULaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Emails
{
    public class OfferProcessingEmail : BaseEmailBuilder, IEmailBuilder
    {
        public OfferProcessingEmail( ApplicationModel model, Dictionary<string, string> templateParams ) : base( model, templateParams )
        {
        }

        protected override void BuildBody( StringBuilder builder )
        {
            if ( TemplateParams == null || !TemplateParams.ContainsKey( "deposit" ) )
            {
                throw new ArgumentOutOfRangeException( "must supply 'deposit' parameter" );
            }
            string depositAmount = TemplateParams["deposit"];

            builder.AppendFormat( "<p> Dear {0}, </p>", Model.User.FirstName );
            builder.AppendFormat( "<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", Model.CourseCode, Model.StartDate.ToLongDateString() );
            builder.AppendFormat( "<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", Model.DegreeSubject.ToDescription(), Model.DegreeGrade.ToDescription() );
            builder.AppendFormat( "<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{0} deposit fee to secure your place.", depositAmount.ToString() );
            builder.AppendFormat( "<br/> We look forward to welcoming you to the University," );

        }
    }
}
