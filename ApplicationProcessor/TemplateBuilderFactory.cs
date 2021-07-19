using System.Collections.Generic;
using Ulaw.ApplicationProcessor.Emails;
using Ulaw.ApplicationProcessor.Interfaces;
using ULaw.ApplicationProcessor.Enums;
using ULaw.ApplicationProcessor.Models;

namespace ULaw.ApplicationProcessor
{
    public class TemplateBuilderFactory : ITemplateBuilderFactory
    {
        public IEmailBuilder CreateBuilder( ApplicationModel model )
        {
            switch ( model.DegreeGrade )
            {
                case DegreeGradeEnum.TwoTwo:
                    return new ApplicationProcessingEmail( model );
                case DegreeGradeEnum.Third:
                    return new ApplicationRejectedEmail( model );

                case DegreeGradeEnum.First:
                case DegreeGradeEnum.TwoOne:
                    if(model.DegreeSubject == DegreeSubjectEnum.Law || model.DegreeSubject == DegreeSubjectEnum.LawAndBusiness )
                    {
                        decimal depositAmount = 350.00M; //get from API or Database
                        return new OfferProcessingEmail( model, new Dictionary<string, string> { { "deposit", depositAmount.ToString() } } );
                    }
                    else
                    {
                        return new ApplicationProcessingEmail( model );
                    }

                default:
                    return new EmptyEmail( model );
            }
        }
    }
}

