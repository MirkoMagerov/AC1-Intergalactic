using System.Text.RegularExpressions;

namespace AC1
{
    public class Score
    {
        private string _player;
        private string _mission;
        private int _scoring;

        public Score(string player, string mission, int scoring)
        {
            Player = player;
            Mission = mission;
            Scoring = scoring;
        }

        public string Player
        {
            get { return _player; }
            set
            {
                Regex onlyLettersAndNumbers = new Regex(@"^[a-zA-Z]+$");
                if (onlyLettersAndNumbers.IsMatch(value))
                {
                    _player = value;
                }
                else
                {
                    throw new ArgumentException("El valor de Player solo puede contener letras y números.");
                }
            }
        }

        public string Mission
        {
            get { return _mission; }
            set
            {
                string[] consonantesGriegas = [ "Beta", "Gamma", "Delta", "Zeta", "Theta", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Pi", "Rho", "Sigma", "Tau", "Phi", "Chi", "Psi" ];
                bool contieneConsonanteGriega = consonantesGriegas.Any(c => value.Contains(c));

                if (contieneConsonanteGriega)
                {
                    Regex correctMissionFormat = new Regex(@"-\d{3}$");
                    if (correctMissionFormat.IsMatch(value))
                    {
                        _mission = value;
                    }
                    else
                    {
                        throw new ArgumentException("La misión debe acabar en un guión seguido de 3 números.");
                    }
                }
                else
                {
                    throw new ArgumentException("La misión debe contener el nombre de una consonante griega.");
                }
            }
        }

        public int Scoring
        {
            get { return _scoring; }
            set
            {
                const int MinValue = 0, MaxValue = 500;
                if (Helper.IsBetweenRange(value, MinValue, MaxValue))
                {
                    _scoring = value;
                }
                else
                {
                    throw new ArgumentException("El scoring debe estar entre 0 y 500.");
                }
            }
        }

        public override string ToString()
        {
            return $"Nombre de la persona: {Player}\nNombre de la misión: {Mission}\nCantidad de puntos: {Scoring}";
        }
    }
}
