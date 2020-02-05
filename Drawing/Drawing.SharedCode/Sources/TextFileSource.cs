using Drawing.SharedCode.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Drawing.SharedCode.Sources
{
    public class TextFileSource : ITeamsSource
    {
        private const int NAME_INDEX = 0;
        private const int COUNTRY_INDEX = 1;
        private string path;
        private string recordSeparator;
        private string fieldSeparator;
        private List<Team> teams;
        private string[] rawTeamRecords;

        public TextFileSource(string path, string recordSeparator, string fieldSeparator)
        {
            this.path = path;
            this.recordSeparator = recordSeparator;
            this.fieldSeparator = fieldSeparator;
        }

        public IEnumerable<Team> GetTeams()
        {
            teams = new List<Team>();
            OpenAndReadFile();

            for (int i = 0; i < rawTeamRecords.Length; i++)
            {
                if (string.IsNullOrEmpty(rawTeamRecords[i]))
                    continue;
                string[] rawTeamFields = rawTeamRecords[i].Split(fieldSeparator.ToCharArray());
                Team team = new Team()
                {
                    Name = rawTeamFields[NAME_INDEX],
                    Country = rawTeamFields[COUNTRY_INDEX]
                };
                teams.Add(team);
            }
            if (teams.Count == 0)
                throw new Exception("Cannot parse teams from text");

            return teams;
        }

        private void OpenAndReadFile()
        {
            if (!File.Exists(this.path))
                throw new Exception("File doesn't exists.");
            string allText = File.ReadAllText(this.path);
            try
            {
                rawTeamRecords = allText.Split(recordSeparator.ToCharArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot split to records.", ex);
            }
        }
    }
}