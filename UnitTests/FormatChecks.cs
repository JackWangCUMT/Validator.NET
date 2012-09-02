using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorNET;
using ValidatorNET.Enums;

namespace UnitTests
{
    [TestClass]
    public class FormatChecks
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PostalCodeFormatCheck()
        {
            Assert.AreEqual(true, Validator.CheckPostalCode("75008", PostalFormat.France));
            Assert.AreEqual(true, Validator.CheckPostalCode("02801", PostalFormat.Germany));
            Assert.AreEqual(true, Validator.CheckPostalCode("102-8166", PostalFormat.Japan));
            Assert.AreEqual(true, Validator.CheckPostalCode("847283", PostalFormat.China));

            // American 9 digit zip code
            Assert.AreEqual(true, Validator.CheckPostalCode("33701-4313", PostalFormat.America));

            // American 5 digit zip code
            Assert.AreEqual(true, Validator.CheckPostalCode("55416", PostalFormat.America));
            Assert.AreEqual(true, Validator.CheckPostalCode("4200", PostalFormat.Denmark));
            Assert.AreEqual(true, Validator.CheckPostalCode("384230", PostalFormat.India));
            Assert.AreEqual(true, Validator.CheckPostalCode("1792", PostalFormat.Swiss));
            Assert.AreEqual(true, Validator.CheckPostalCode("984283", PostalFormat.Russian));
            Assert.AreEqual(true, Validator.CheckPostalCode("5343", PostalFormat.Australia));
            Assert.AreEqual(true, Validator.CheckPostalCode("K1A0B1", PostalFormat.Canada));
            Assert.AreEqual(true, Validator.CheckPostalCode("SW1A 0AA", PostalFormat.UnitedKingdom));
            Assert.AreEqual(true, Validator.CheckPostalCode("04552-050", PostalFormat.Brazil));
            Assert.AreEqual(true, Validator.CheckPostalCode("3823 AB", PostalFormat.Dutch));

            // Better than nothing
            Assert.AreEqual(true, Validator.CheckPostalCode("test1234", PostalFormat.Invariant));
        }

        [TestMethod]
        public void PhoneNumberFormatCheck()
        {
            Assert.AreEqual(true, Validator.CheckPhoneNumber("0494778899", PhoneFormat.France));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("(022)22 22 22", PhoneFormat.Germany));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("03-1323-2334", PhoneFormat.Japan));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("234-14242424", PhoneFormat.China));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("555-383-3344", PhoneFormat.America));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("493 3227341", PhoneFormat.India));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("972-367087", PhoneFormat.Spain));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("+44 333 333 333", PhoneFormat.UnitedKingdom));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("(23)343-4343", PhoneFormat.Brazil));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("+31(0)235256677", PhoneFormat.Dutch));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("(02)12341234", PhoneFormat.Australia));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("2342523452", PhoneFormat.Israel));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("(038)8383748", PhoneFormat.NewZealand));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("+7(916)9985670", PhoneFormat.Russia));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("22737458", PhoneFormat.Invariant));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("023-55116", PhoneFormat.Sweden));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("3486543653", PhoneFormat.Italy));
            Assert.AreEqual(true, Validator.CheckPhoneNumber("20293822", PhoneFormat.Denmark));
        }

        [TestMethod]
        public void SSNFormatCheck()
        {
            Assert.AreEqual(true, Validator.CheckSocialSecurityNumber("19238433928394829X", SocialSecurityNumberFormat.China));
            Assert.AreEqual(true, Validator.CheckSocialSecurityNumber("145470191", SocialSecurityNumberFormat.America));
            Assert.AreEqual(true, Validator.CheckSocialSecurityNumber("120384-2833", SocialSecurityNumberFormat.Denmark));
            Assert.AreEqual(true, Validator.CheckSocialSecurityNumber("1 81 04 95 201 569 62", SocialSecurityNumberFormat.France));
        }

        [TestMethod]
        public void CheckURI()
        {
            Assert.AreEqual(true, Validator.CheckUri("http://ianqvist.dk/"));
            Assert.AreEqual(true, Validator.CheckUri("http://ianqvist.com"));
            Assert.AreEqual(true, Validator.CheckUri("http://ianqvist.dk/page.aspx"));
            Assert.AreEqual(true, Validator.CheckUri("http://ianqvist.dk/page.aspx?var=value"));
            Assert.AreEqual(true, Validator.CheckUri("http://ianqvist.dk/page.aspx?var=value&var2=value2"));
            Assert.AreEqual(true, Validator.CheckUri("http://www.ianqvist.dk/"));
            Assert.AreEqual(false, Validator.CheckUri("contoso.com/path???/file"));
        }

        [TestMethod]
        public void CheckEmail()
        {
            Assert.AreEqual(true, Validator.CheckEmail("ian@qvist.dk"));
            Assert.AreEqual(true, Validator.CheckEmail("a1@a.aa"));
            Assert.AreEqual(false, Validator.CheckEmail("@ad.dk"));
            Assert.AreEqual(false, Validator.CheckEmail("asd@.dk"));
            Assert.AreEqual(false, Validator.CheckEmail("asd@asd."));
        }
    }
}