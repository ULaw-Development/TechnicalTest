using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;
using ULaw.ApplicationProcessor.Enums;
using ULaw.ApplicationProcessor.Models;

namespace ULaw.ApplicationProcessor
{

    public class Application //Unsure if this is the user's application itself, or the application program. 
    {
        public Application( ApplicationModel application, ITemplateBuilderFactory emailBuilderFactory )
        {
            Model = application;
            EmailBuilderFactory = emailBuilderFactory;
        }

        public ApplicationModel Model { get; }
        public ITemplateBuilderFactory EmailBuilderFactory { get; }

        public string Process()
        {

            IEmailBuilder emailBuilder = EmailBuilderFactory.CreateBuilder( Model );
            return emailBuilder.Build();


            var result = new StringBuilder( "<html><body><h1>Your Recent Application from the University of Law</h1>" );

            if ( Model.DegreeGrade == DegreeGradeEnum.TwoTwo )
            {
                result.Append( string.Format( "<p> Dear {0}, </p>", Model.User.FirstName ) );
                result.Append( string.Format( "<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", Model.CourseCode, Model.StartDate.ToLongDateString() ) );
                result.Append( "<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk." );
                result.Append( "<br/> Yours sincerely," );
                result.Append( "<p/> The Admissions Team," );
            }
            else
            {
                if ( Model.DegreeGrade == DegreeGradeEnum.Third )
                {
                    result.Append( string.Format( "<p> Dear {0}, </p>", Model.User.FirstName ) );
                    result.Append( "<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion." );
                    result.Append( "<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk." );
                    result.Append( "<br> Yours sincerely," );
                    result.Append( "<p/> The Admissions Team," );
                }
                else
                {
                    if ( Model.DegreeSubject == DegreeSubjectEnum.Law || Model.DegreeSubject == DegreeSubjectEnum.LawAndBusiness )
                    {
                        decimal depositAmount = 350.00M;

                        result.Append( string.Format( "<p> Dear {0}, </p>", Model.User.FirstName ) );
                        result.Append( string.Format( "<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", Model.CourseCode, Model.StartDate.ToLongDateString() ) );
                        result.Append( string.Format( "<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", Model.DegreeSubject.ToDescription(), Model.DegreeGrade.ToDescription() ) );
                        result.Append( string.Format( "<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{0} deposit fee to secure your place.", depositAmount.ToString() ) );
                        result.Append( string.Format( "<br/> We look forward to welcoming you to the University," ) );
                        result.Append( string.Format( "<br/> Yours sincerely," ) );
                        result.Append( string.Format( "<p/> The Admissions Team," ) );
                    }
                    else
                    {
                        result.Append( string.Format( "<p> Dear {0}, </p>", Model.User.FirstName ) );
                        result.Append( string.Format( "<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", Model.CourseCode, Model.StartDate.ToLongDateString() ) );
                        result.Append( "<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk." );
                        result.Append( "<br/> Yours sincerely," );
                        result.Append( "<p/> The Admissions Team," );
                    }
                }
            }

            result.Append( string.Format( "</body></html>" ) );

            return result.ToString();
        }

    }
}

