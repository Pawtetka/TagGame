using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public class StandartGameControllerCreator : GameControllerCreator
    {
        public override GameController CreateController(IFieldInfo fieldInfo)
        {
            return new StandartGameController(fieldInfo);
        }
    }
}