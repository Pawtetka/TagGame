using TagGameBLL.Interfaces;

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