using System;
using System.Collections.Generic;
using System.Text;
using MarioObjects.Objects.BaseObjects;
using MarioObjects.Objects.Utils;

namespace MarioObjects.Objects.GameObjects
{
    public class Monster : MoveableAnimatedObject
    {
        public Boolean FallDie;
        public double deathPositionMarioX;
        public double deathPositionMarioY;

        public static LevelEditorObject GetLEObject()
        {
            return new LevelEditorObject(16, 16, 4, 1, ObjectType.OT_Goomba, null);
        }

        public static Monster SetLEObject(LevelEditorObject le)
        {
            return new Monster(le.x, le.y);
        }

        public override void Intersection(Collision c, GraphicObject g)
        {
            base.Intersection(c, g);

            switch (g.OT)
            {
                case ObjectType.OT_BlockQuestion:
                    {
                        int a = 1;
                    } break;
                case ObjectType.OT_Goomba:
                    {
                        DirX *= -1;
                        OnWalk(null, null);
                        ((Monster)g).DirX *= -1;
                        ((Monster)g).OnWalk(null, null);
                    } break;
                case ObjectType.OT_Mario:
                    {
                        Character m = (Character)g;
                        if (c.Dir != CollisionDirection.CD_Down)
                        {
                            if (!m.Blinking)
                            {
                                m.MarioHandleCollision();
                                deathPositionMarioX = m.x;
                                deathPositionMarioY = m.y;
                            }
                        }

                    } break;
            }
        }

        public void GoombaFallDie()
        {
            if (FallDie == false)
            {
                FallDie = true;

            }
        }
        public void GoombaDie()
        {
            Animated = false;
            Live = false;
        }
        public override void OnWalk(object sender, EventArgs e)
        {
            if (!FallDie)
                base.OnWalk(sender, e);
            else
            {
                Animated = false;
                ImageIndex = 3;
                newy += 3;

                if (newy >= LevelGenerator.CurrentLevel.height)
                {
                    Visible = false;
                }

            }


        }
        public Monster(int x, int y)
            : base(ObjectType.OT_Goomba)
        {
            AnimatedCount = 2;
            this.x = x;
            this.y = y;
            SetWidthHeight();
            FallDie = false;

            TimerGenerator.AddTimerEventHandler(TimerType.TT_50, this.OnWalk);
            TimerGenerator.AddTimerEventHandler(TimerType.TT_100, this.OnAnimate);
        }
        public override void Draw()
        {
            base.Draw();
        }
        public override void OnAnimate(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (Live)
                    base.OnAnimate(sender, e);
                else
                {
                    if (ImageIndex != 2)
                        ImageIndex = 2; //Die Picture
                    else
                    {
                        Visible = false; //Next Time,Visible False
                    }
                }
            }
        }
    }

}
