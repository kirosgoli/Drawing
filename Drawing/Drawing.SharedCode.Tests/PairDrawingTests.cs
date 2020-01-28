using Drawing.SharedCode.Models.Drawings;
using Drawing.SharedCode.Sources;
using Drawing.SharedCode.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            PairDrawing drawing = (PairDrawing)DrawFactory.CreatePairsDraw(source);
            drawing.Draw();
            Assert.AreEqual(drawing.Pairs.Count(), source.GetTeams().Count() / 2);
        }

        [TestMethod]
        public void DrawWithCountryValidation_And_ItsPossible()
        {
            //for (int i = 0; i < 1000; i++)
            //{
            //    TeamsContainerSource source = new TeamsContainerSource();
            //    source.AddTeam(new Models.Team { Name = "Barcelona", Country = "Spain" });
            //    source.AddTeam(new Models.Team { Name = "Real Madrid", Country = "Spain" });
            //    source.AddTeam(new Models.Team { Name = "Juventus", Country = "Italy" });
            //    source.AddTeam(new Models.Team { Name = "Bayern Munchen", Country = "Germany" });
            //    PairDrawing drawing = (PairDrawing)DrawFactory.CreatePairsDraw(source, new List<ITeamValidation> { new CountryValidation() });
            //    try
            //    {
            //        drawing.Draw();
            //        Assert.IsTrue(true);
            //    }
            //    catch (System.Exception ex)
            //    {
            //        Assert.Fail();
            //    }
            //}


            for (int i = 0; i < 1000; i++)
            {
                TeamsContainerSource source = new TeamsContainerSource();
                source.AddTeam(new Models.Team { Name = "Barcelona", Country = "Spain" });
                source.AddTeam(new Models.Team { Name = "Real Madrid", Country = "Spain" });
                source.AddTeam(new Models.Team { Name = "Juventus", Country = "Italy" });
                source.AddTeam(new Models.Team { Name = "Bayern Munchen", Country = "Germany" });
                source.AddTeam(new Models.Team { Name = "Valencia", Country = "Spain" });
                source.AddTeam(new Models.Team { Name = "Real Betis", Country = "Spain" });
                source.AddTeam(new Models.Team { Name = "Manchaster City", Country = "England" });
                source.AddTeam(new Models.Team { Name = "Liverpool. CF", Country = "England" });
                PairDrawing drawing = (PairDrawing)DrawFactory.CreatePairsDraw(source, new List<ITeamValidation> { new CountryValidation() });
                try
                {
                    drawing.Draw();
                    Assert.IsTrue(true);
                }
                catch (System.Exception ex)
                {
                    Assert.Fail();
                }
            }

        }

        [TestMethod]
        public void DrawWithCountryValidation_And_Its_Not_Possible()
        {
            for (int i = 0; i < 1000; i++)
            {
                TeamsContainerSource source = new TeamsContainerSource();
                source.AddTeam(new Models.Team { Name = "Barcelona", Country = "Spain" });
                source.AddTeam(new Models.Team { Name = "Real Madrid", Country = "Spain" });
                source.AddTeam(new Models.Team { Name = "Valencia", Country = "Spain" });
                source.AddTeam(new Models.Team { Name = "Real Betis", Country = "Spain" });
                PairDrawing drawing = (PairDrawing)DrawFactory.CreatePairsDraw(source, new List<ITeamValidation> { new CountryValidation() });
                try
                {
                    drawing.Draw();
                    Assert.Fail();
                }
                catch (System.Exception ex)
                {
                    Assert.IsTrue(true);
                }
            }


        }
    }
}