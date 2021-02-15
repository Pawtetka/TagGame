using TagGameBLL.Classes;

namespace TagGameBLL.Interfaces
{
    public interface IFieldInfo
    {
        Field Field { get; set; }
        FieldHistory FieldHistory { get; set; }
    }
}