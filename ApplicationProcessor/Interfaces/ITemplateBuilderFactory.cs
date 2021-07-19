using System.Collections.Generic;
using ULaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Interfaces
{
    public interface ITemplateBuilderFactory
    {
        IEmailBuilder CreateBuilder( ApplicationModel model );
    }
}