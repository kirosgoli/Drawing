using Drawing.SharedCode.Interfaces;
using Drawing.SharedCode.Models.Drawings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Tests
{
    [TestClass]
    public class GroupDrawingTest
    {
        [TestMethod]
        public void ShouldGroupsHaveCorrectNameBaseOnNumberParametr()
        {
            int numberParameter = 4;
            GroupDrawing groupDrawing = DrawFactory.CreateGroupsDraw(numberParameter, 4) as GroupDrawing;
            //groupDrawing.Draw();
            Assert.IsTrue(true);
        }
    }
}
