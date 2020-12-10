using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public class BonusGameControllerCreator : GameControllerCreator
    {
        public override GameController CreateController(IFieldInfo fieldInfo)
        {
            return new BonusGameController(fieldInfo);
        }
    }
}
