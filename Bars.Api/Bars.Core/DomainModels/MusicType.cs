namespace Bars.Core.DomainModels
{ 
    public sealed class MusicType
    {
        private readonly int _musicTypeId;
        public int MusicTypeId { get { return _musicTypeId; } }

        private readonly string _name;
        public string Name { get { return _name; } }

        public MusicType(int musicTypeId, string name)
        {
            _musicTypeId = musicTypeId;
            _name = name;
        }
    }
}
