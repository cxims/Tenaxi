using System;
using System.Collections.Generic;
using System.Text;

namespace MarioObjects.Objects.GameObjects
{
    static class Globals
    {
        public static double deathPositionX = 120.0;
        public static double deathPositionY = 111;

        public static double getDeathPositionX()
        {
            return deathPositionX;
        }

        public static void setDeathPositionX(double a)
        {
            deathPositionX = a;
        }
    }
}
