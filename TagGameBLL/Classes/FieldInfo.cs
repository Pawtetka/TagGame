using TagGameBLL.Interfaces;

namespace TagGameBLL.Classes
{
    public class FieldInfo : IFieldInfo
    {
        public FieldInfo()
        {
            Field = new Field();
            FieldHistory = new FieldHistory();
        }

        public Field Field { get; set; }
        public FieldHistory FieldHistory { get; set; }
    }
}