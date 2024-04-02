namespace AC1
{
    class Program
    {
        public static void Main()
        {
            const int totalScores = 5;
            const string MsgWelcome = "Bienvenido a 'Intergalactic Exploration Missions'.";
            const string MsgWrongEntry = "Algun atributo no estaba en el formato correcto. Vuelve a intentarlo.";
            const string MsgEnterScore = "Introduce los siguientes atributos para cada sistema de puntuación: ";
            const string MsgEnterName = "Nombre de la persona: ";
            const string MsgEnterMission = "Nombre de la misión: ";
            const string MsgEnterScorePoints = "Cantidad de puntos: ";

            List<Score> scoreList = new List<Score>();

            Console.WriteLine(MsgWelcome);

            for (int i = 0; i < totalScores; i++)
            {
                string name = "", mission = "";
                int score = 0;

                Console.WriteLine(MsgEnterScore);

                bool validScore = false;

                while (!validScore)
                {
                    try
                    {
                        Console.Write(MsgEnterName);
                        name = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write(MsgEnterMission);
                        mission = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write(MsgEnterScorePoints);
                        score = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        Score actScore = new Score(name, mission, score);

                        validScore = true;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.WriteLine(MsgWrongEntry);
                        Console.ResetColor();
                    }
                }

                scoreList.Add(new Score(name, mission, score));
            }

            List<Score> orderedList = Helper.OrderByPlayerAndMission(scoreList);

            foreach (Score score in orderedList)
            {
                Console.WriteLine(score);
            }
        }
    }
}