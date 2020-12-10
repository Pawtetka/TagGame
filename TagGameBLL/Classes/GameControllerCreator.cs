using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    public abstract class GameControllerCreator
    {
        public abstract GameController CreateController(IFieldInfo fieldInfo);
    }
}
