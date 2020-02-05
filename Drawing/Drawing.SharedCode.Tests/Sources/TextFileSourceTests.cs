using Drawing.SharedCode.Models;
using Drawing.SharedCode.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Tests.Sources
{
    [TestClass]
    public class TextFileSourceTests
    {
        [TestMethod]
        public void ReadingTwoTeams()
        {
            TextFileSource source = new TextFileSource(@"Files/Teams.txt", Environment.NewLine, ";");
            List<Team> teams = source.GetTeams().ToList();
            Assert.AreEqual(2, teams.Count);
            Assert.AreEqual("Liverpool", teams[0].Name);
            Assert.AreEqual("France", teams[1].Country);
        }
    }
}