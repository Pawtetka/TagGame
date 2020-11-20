using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameBLL.Classes
{
    abstract public class GameController
    {
        protected FieldInfo _fieldInfo;

        public GameController()
        {
            _fieldInfo = FieldInfo.GetInstance();
        }

        /*public void SelectCell(int raw, int column)
        {
            if (_fieldInfo.Field.GetSelectedCell() != null)
            {
                _fieldInfo.Field.GetSelectedCell().IsSelected = false;
            }
            _fieldInfo.Field.GetCell(raw, column).IsSelected = true;
            SaveFieldState();
        }*/

        abstract public void MoveCell(Direction moveDirection);

        public void SaveFieldState()
        {
            _fieldInfo.FieldHistory.AddState(_fieldInfo.Field.SaveState());
        }

        public void UndoFieldState()
        {
            _fieldInfo.Field.RestoreState(_fieldInfo.FieldHistory.PopState());
        }

    }
}
