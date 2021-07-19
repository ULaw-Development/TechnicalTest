using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ulaw.ApplicationProcessor.Models;
using ULaw.ApplicationProcessor;
using ULaw.ApplicationProcessor.Enums;
using ULaw.ApplicationProcessor.Models;

namespace ULaw.ApplicationProcessor.Tests
{

    [TestClass]
    public class ApplicationSubmissionTests
    {
        private const string OfferEmailForFirstLawDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law degree at grade: 1st.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForTwoOneLawDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law degree at grade: 2:1.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForFirstLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law and Business degree at grade: 1st.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForTwoOneLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law and Business degree at grade: 2:1.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";

        private const string FurtherInfoEmailResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application for our course reference: ABC123 starting on 22 September 2019, we are writing to inform you that we are currently assessing your information and will be in touch shortly.<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string RejectionEmailForAnyThirdDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.<br> Yours sincerely,<p/> The Admissions Team,</body></html>";

        private ApplicationModel _application;
        private UserModel _user;
        private Application thisSubmission;

        [TestInitialize]
        public void Setup() 
        {
            _user = new UserModel( "Mr", "Test", "Tester", new DateTime( 1991, 08, 14 ), false );
            _application = new ApplicationModel("Law", "ABC123", new DateTime(2019, 9, 22), _user);
            thisSubmission = new Application( _application );
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawDegree()
        {

            _application.DegreeGrade = DegreeGradeEnum.first;
            _application.DegreeSubject = DegreeSubjectEnum.law;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForFirstLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawAndBusinessDegree()
        {

            _application.DegreeGrade = DegreeGradeEnum.first;
            _application.DegreeSubject = DegreeSubjectEnum.lawAndBusiness;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForFirstLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstEnglishDegree()
        {

            _application.DegreeGrade = DegreeGradeEnum.first;
            _application.DegreeSubject = DegreeSubjectEnum.English;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawDegree()
        {

            _application.DegreeGrade = DegreeGradeEnum.twoOne;
            _application.DegreeSubject = DegreeSubjectEnum.law;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneMathsDegree()
        {


            _application.DegreeGrade = DegreeGradeEnum.twoOne;
            _application.DegreeSubject = DegreeSubjectEnum.maths;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawAndBusinessDegree()
        {

            _application.DegreeGrade = DegreeGradeEnum.twoOne;
            _application.DegreeSubject = DegreeSubjectEnum.lawAndBusiness;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoEnglishDegree()
        {

            _application.DegreeGrade = DegreeGradeEnum.twoTwo;
            _application.DegreeSubject = DegreeSubjectEnum.English;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoLawDegree()
        {

            _application.DegreeGrade = DegreeGradeEnum.twoTwo;
            _application.DegreeSubject = DegreeSubjectEnum.law;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithThirdDegree()
        {

            _application.DegreeGrade = DegreeGradeEnum.third;
            _application.DegreeSubject = DegreeSubjectEnum.maths;

            string emailHtml = thisSubmission.Process();
            Assert.AreEqual(emailHtml, RejectionEmailForAnyThirdDegreeResult);
        }
    }
  
}
