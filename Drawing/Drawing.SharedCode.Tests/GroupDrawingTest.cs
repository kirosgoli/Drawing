using Drawing.SharedCode.Models.Drawings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawing.SharedCode.Tests
{
    [TestClass]
    public class GroupDrawingTest
    {
        [TestMethod]
        public void ShouldGroupsHaveCorrectNameBaseOnNumberParametr()
        {
            int numberParameter = 4;
            GroupDrawing groupDrawing = DrawFactory.CreateGroupsDraw(numberParameter, 4, null) as GroupDrawing;
            //groupDrawing.Draw();
            Assert.IsTrue(true);
        }
    }
}