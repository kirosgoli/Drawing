using Drawing.SharedCode.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawing.SharedCode.Tests
{
    [TestClass]
    public class GroupNameCreatorTests
    {
        [TestMethod]
        public void CreateNameForLowerGroupNumber()
        {
            Assert.AreEqual("A", GroupNameCreator.CreateGroupNameFromNumber(1));
            Assert.AreEqual("E", GroupNameCreator.CreateGroupNameFromNumber(5));
            Assert.AreEqual("O", GroupNameCreator.CreateGroupNameFromNumber(15));
            Assert.AreEqual("Z", GroupNameCreator.CreateGroupNameFromNumber(26));
        }

        [TestMethod]
        public void CreateNameForBiggerGroupNumber()
        {
            Assert.AreEqual("AA", GroupNameCreator.CreateGroupNameFromNumber(27));
            Assert.AreEqual("BB", GroupNameCreator.CreateGroupNameFromNumber(54));
            Assert.AreEqual("ALL", GroupNameCreator.CreateGroupNameFromNumber(1000));
        }
    }
}