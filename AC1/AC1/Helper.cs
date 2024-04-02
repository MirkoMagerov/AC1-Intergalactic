namespace AC1
{
    public static class Helper
    {
        public static List<Score> GenerateUniqueRanking(List<Score> scores)
        {
            List<Score> result = OrderByPlayerAndMission(scores);

            return result;
        }

        public static List<Score> OrderByPlayerAndMission(List<Score> scores)
        {
            List<Score> result = scores.OrderBy(score => score.Player)
                                       .ThenBy(score => score.Mission)
                                       .ThenByDescending(score => score.Scoring)
                                       .ToList();

            return result;
        }

        public static bool IsBetweenRange(int val, int min, int max)
        {
            return val >= min && val <= max;
        }
    }
}
