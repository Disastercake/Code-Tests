
namespace ExspiravitExMachina
{
    public class Ghost
    {
        public string NameInLife { get { return _nameInLife; } }
        private string _nameInLife = string.Empty;

        public string NameInDeath { get { return $"Dead {_nameInLife}"; } }

        private int _spookiness = 5;
        public int Spookiness { get { return _spookiness; } }

        public Ghost(string nameInLife, int spookiness)
        {
            _nameInLife = nameInLife;
            _spookiness = spookiness;
        }
    }
}
