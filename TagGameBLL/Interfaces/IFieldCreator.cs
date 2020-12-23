using TagGameBLL.Classes;

namespace TagGameBLL.Interfaces
{
    public interface IFieldCreator
    {
        void GenerateField(int size, Difficult difficult);
        void DeleteField();
    }
}