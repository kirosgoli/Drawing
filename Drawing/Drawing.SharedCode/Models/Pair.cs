namespace Drawing.SharedCode.Models
{
    public class Pair
    {
        public Team HomeTeam { get; internal set; }
        public Team AwayTeam { get; internal set; }

        public override string ToString()
        {
            //Todo
            //W zależności od kraju
            //return PairFormatter.Format(HomeTeam, AwayTeam);
            return $"{HomeTeam.Name} vs {AwayTeam.Name}";
        }
    }
}