using System.Collections.Generic;

namespace ADarkAlley.Data
{
    public class Level
    {
        public string Name;
        public int ID;
        public List<LevelObject> Objects;
    }

    public class LevelObject
    {
        public int X;
        public int Y;
        public int ObjectID;
    }
}