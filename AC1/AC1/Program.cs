namespace AC1
{
    class Program
    {
        public static void Main()
        {
            const int totalScores = 10;
            const string MsgWelcome = "Bienvenido a 'Intergalactic Exploration Missions'.";
            const string MsgWrongEntry = "Algun atributo no estaba en el formato correcto. Vuelve a intentarlo.";
            const string MsgEnterScore = "Introduce los siguientes atributos para cada sistema de puntuación (Puntuación número {0}): ";
            const string MsgEnterName = "Nombre de la persona: ";
            const string MsgEnterMission = "Nombre de la misión: ";
            const string MsgEnterScorePoints = "Cantidad de puntos: ";
            const string MsgDisplayPuntuations = "------------ Puntuaciones ordenadas ------------";
            const string MsgPuntuation = "Puntuación: ";

            List<Score> scoreList = new List<Score>();

            Console.WriteLine(MsgWelcome);

            for (int i = 0; i < totalScores; i++)
            {
                string name = "", mission = "";
                int score = 0;

                Console.WriteLine();
                Console.WriteLine(MsgEnterScore, i + 1);
                Console.WriteLine();

                bool validScore = false;

                // Mientras salte alguna excepción, no se sale del bucle de crear un Score.
                while (!validScore)
                {
                    try
                    {
                        Console.Write(MsgEnterName);
                        name = Console.ReadLine();

                        Console.Write(MsgEnterMission);
                        mission = Console.ReadLine();

                        Console.Write(MsgEnterScorePoints);
                        score = Convert.ToInt32(Console.ReadLine());

                        Score actScore = new Score(name, mission, score);

                        // Si salta la excepción al crear un nuevo Score, validScore seguirá siendo false.
                        // Si no salta ninguna excpeción, la variable actScore se borra al salir del try y se añade un nuevo Score al salir del bucle.
                        validScore = true;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.WriteLine(MsgWrongEntry);
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }

                scoreList.Add(new Score(name, mission, score));
            }

            Console.WriteLine();

            // Se ordenan las listas por persona, seguido de misión y scoring por orden descendente, y se eliminan los duplicados.
            List<Score> orderedList = Helper.OrderByPlayerAndMission(scoreList);

            Console.WriteLine(MsgDisplayPuntuations);
            Console.WriteLine();

            foreach (Score score in orderedList)
            {
                Console.WriteLine(MsgPuntuation);
                Console.WriteLine(score);
                Console.WriteLine();
            }
        }
    }
}