using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    abstract public class CreaturesDwelling : Building
    {
        public CreaturesDwelling(String Name, String Description, String FileName, String CreatureName, String CreatureFileName)
            : base(Name, Description, FileName)
        {
            _CreatureName = CreatureName;
            _CreatureFileName = CreatureFileName;
        }
        public String CreatureName { get => _CreatureName; }
        public String CreatureFileName { get => _CreatureFileName; }
        abstract public Resources RecruitmentCost { get; }
        protected String _CreatureName;
        protected String _CreatureFileName;
    }
}
