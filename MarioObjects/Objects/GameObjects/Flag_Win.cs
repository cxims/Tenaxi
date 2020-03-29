using System;
using System.Collections.Generic;
using System.Text;
using MarioObjects.Objects.BaseObjects;
using MarioObjects.Objects.Utils;

namespace MarioObjects.Objects.GameObjects
{
    public class Flag_Win : StaticGraphicObject
    {
        public static LevelEditorObject GetLEObject()
        {
            return new LevelEditorObject(16, 32, 1, 0, ObjectType.OT_Exit, null);
        }

        public static Flag_Win SetLEObject(LevelEditorObject le)
        {
            return new Flag_Win(le.x, le.y);
        }

        public Flag_Win(int x, int y)
        {
            OT = ObjectType.OT_Exit;
            this.x = x;
            this.y = y;
            SetWidthHeight();
            width = 16;

        }
    }

}
