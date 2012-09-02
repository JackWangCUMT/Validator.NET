using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorNET;

namespace UnitTests
{
    [TestClass]
    public class AttackChecks
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
        public void XssAttackCheck()
        {
            int attackVector = Validator.CheckForXss("<ScRiPt     lAnguage=JavaScript>alert(document.cookie); var hextest=%74%65%73%74; &lt;/sCrIpt&gt;");
            Assert.AreEqual(540, attackVector);
        }

        [TestMethod]
        public void SqlInjectionCheck()
        {
            int attackVector = Validator.CheckForSqlInjection("';         DrOP users    --");
            Assert.AreEqual(70, attackVector);
        }
    }
}