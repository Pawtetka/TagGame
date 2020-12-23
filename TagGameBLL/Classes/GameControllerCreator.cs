using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public abstract class GameControllerCreator
    {
        public abstract GameController CreateController(IFieldInfo fieldInfo);
    }
}