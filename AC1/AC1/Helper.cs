namespace AC1
{
    public static class Helper
    {
        public List<Score> GenerateUniqueRanking(List<Score> scores)
        {
            List<Score> result = new List<Score>();

            foreach(Score score in scores)
            {
                
            }
        }

        public static bool IsBetweenRange(int val, int min, int max)
        {
            return val >= min && val <= max;
        }
    }
}
