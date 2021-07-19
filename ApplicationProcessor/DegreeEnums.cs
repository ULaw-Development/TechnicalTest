using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection; 

namespace ULaw.ApplicationProcessor.Enums
{
    public enum DegreeGradeEnum : int
    {
        [DescriptionAttribute("1st")]
        First,
        [DescriptionAttribute("2:1")]
        TwoOne,
        [DescriptionAttribute("2:2")]
        TwoTwo,
        [DescriptionAttribute("3rd")]
        Third
    }
    
    public enum DegreeSubjectEnum : int
    {
        [DescriptionAttribute("Law")]
        Law,
        [DescriptionAttribute("Law and Business")]
        LawAndBusiness,
        [DescriptionAttribute("Maths")]
        Maths,
        [DescriptionAttribute("English")]
        English
    }

}
