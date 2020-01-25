using Drawing.SharedCode.Models.Drawings;
using Drawing.SharedCode.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Tests
{
    [TestClass]
    public class PairDrawingTests
    {
        public object TeamContainerSource { get; private set; }

        [TestMethod]
        public void ShouldBeNDiveded2PairsForNTeams()
        {
            TeamsContainerSource source = new TeamsContainerSource();
            source.AddTeam(new Models.Team { Name = "Barcelona" });
            source.AddTeam(new Models.Team { Name = "Real Madrid" });
            source.AddTeam(new Models.Team { Name = "Juventus" });
            source.AddTeam(new Models.Team { Name = "Bayern Munchen" });
            PairDrawing drawing= (PairDrawing)DrawFactory.CreatePairsDraw(source);
            drawing.Draw();
            Assert.AreEqual(drawing.Pairs.Count(), source.GetTeams().Count()/2);
        }
    }
}
