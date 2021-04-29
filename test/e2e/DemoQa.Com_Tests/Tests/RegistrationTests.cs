using Xbehave;
using Xunit;
using Xunit.Abstractions;

namespace DemoQa.Com_Tests.Tests
{
    // <summary>
    // All mandatory details must be entered
    // A picture must be uploaded
    // On success a popup will be displayed detailing all information entered
    // Validation will be displayed on any mandatory fields that have not been
    // entered correctly
    // </summary>
    [Collection("E2E Test Collection")]
    public class RegistrationTests
    {
        private readonly ITestOutputHelper _output;
        private readonly E2ETestFixture _fixture;
        
        public RegistrationTests(E2ETestFixture fixture, ITestOutputHelper output)
        {
            _output = output;
            _fixture = fixture;
        }

        [Scenario]
        [InlineData("Jane", "Smith", "user@domain.com", "Female", "0123456789", "1 Oct 2001", "Sports",
            "1 The Road, The Place, The Town, NE1 1DD", "profile.jpg")]
        [InlineData("Jon", "Doe", "user@domain.com", "Male", "0123456789", "1 Oct 2001", "Reading",
            "2 The Road, The Place, The Town, NE1 1DD", "profile.jpg")]
        [InlineData("Sam", "Jones", "user@domain.com", "Other", "0123456789", "1 Oct 2001", "Music",
            "3 The Road, The Place, The Town, NE1 1DD", "profile.jpg")]
        public void StudentCanRegisterAndSubmit(string forename, string surname, string email, string gender,
            string phoneNumber, string dob, string hobby, string address, string profile)
        {
            _fixture.DemoQaPages.PageStudentRegistrationForm().NavigateTo();

            // could be an example of a given here but there's not really any initial
            // system context you can specify here so it doesn't really work
            "Given a student has no existing account"
                .x(() => { });

            "When the student registers completing all mandatory fields"
                .x(() =>
                {
                    _fixture.DemoQaPages.PageStudentRegistrationForm()
                        .SendStudentName(forename, surname)
                        .SendEmail(email)
                        .SelectGender(gender)
                        .SendPhoneNumber(phoneNumber)
                        // deliberate bug in the dob field, I strongly against automating
                        // complex controls like this
                        .SendDateOfBirth(dob)
                        .SelectHobby(hobby)
                        .SendCurrentAddress(address)
                        .UploadPicture(_fixture.TestFileLocation(profile))
                        .Submit();
                });

            "Then the student is able to register"
                .x(() =>
                {
                    Assert.True(_fixture
                        .DemoQaPages.PageStudentRegistrationForm().RegistrationCompleteModalOpen());
                });
        }

        [Scenario]
        public void StudentAttemptsToRegisterWithMissingMandatoryFields()
        {
            _fixture.DemoQaPages.PageStudentRegistrationForm().NavigateTo();

            "Given a student has no existing account"
                .x(() => { });

            "When the student attempts to register with missing mandatory information"
                .x(() => { _fixture.DemoQaPages.PageStudentRegistrationForm().Submit(); });

            "Then the student is unable to register"
                .x(() =>
                {
                    Assert.False(_fixture.DemoQaPages
                        .PageStudentRegistrationForm().RegistrationCompleteModalOpen());
                });
        }
    }
}
