﻿using System;
using System.Collections.Generic;
using System.Text;
using MarioObjects.Objects.BaseObjects;
using System.Drawing;
using MarioObjects.Objects.Utils;

namespace MarioObjects.Objects.GameObjects
{
    public class Mario : AnimatedGraphicObject
    {
        public enum MarioJumpState { J_None, J_Up, JDown };
        public enum MarioMoveState { J_None, J_Right, J_Left, J_Stopping };
        public enum MarioType { MT_Small, MT_Big, MT_Fire };
        public enum MarioDir { MD_Left, MD_Right };
        public Boolean Moving;
        public Boolean Jumping;
        public MarioDir Direction;
        public MarioType Type;
        public MarioJumpState State;
        public MarioMoveState MoveState;
        public Boolean EnterPressed;
        public Boolean Blinking;
        public Boolean BlinkingShow;
        public double deathPositionX;
        public double deathPositionY;
        public int BlinkValue;

        // Y Jumping
        public double StartVelocity;
        public double StartPosition;
        public double CurrentPosition;
        public double OldPosition;
        public double TimeCount;

        //X Moving
        public double XCount;
        public double XAdd;

        public Boolean UpPressed;

        public List<FireBall> FireBalls;
        public int FireBallIndex;


        /// <summary>
        /// Number of coins Mario collected in the current level
        /// </summary>
        public int NumberOfCollectedCoins { get; set; }


        public static LevelEditorObject GetLEObject()
        {
            return new LevelEditorObject(16, 16, 6, 2, ObjectType.OT_Mario, null);
        }
        public static Mario SetLEObject(LevelEditorObject le)
        {
            return new Mario(le.x, le.y);
        }


        public delegate void LevelCompletedDelegate();
        public event LevelCompletedDelegate OnLevelCompleted;

        public delegate void MarioDiedDelegate();
        public event MarioDiedDelegate OnMarioDied;


        public void OnCheckCollisions(Object sender, EventArgs e)
        {
            LevelGenerator.Raise_Event(LevelGenerator.LevelEvent.LE_Check_Collision);
        }
        public void MarioFireBall()
        {
            if (Type != MarioType.MT_Fire)
                return;

            FireBall.FireBallDir D;
            if (!FireBalls[FireBallIndex].Started)
            {
                if (Direction == MarioDir.MD_Right)
                    D = FireBall.FireBallDir.FB_Right;
                else
                    D = FireBall.FireBallDir.FB_Left;


                FireBalls[FireBallIndex].RunFireBall(x, y, FireBall.FireBallType.FT_Mario, D);
                FireBallIndex = (FireBallIndex + 1) % 2;
                Media.PlaySound(Media.SoundType.ST_FireBall);
            }

        }
        public override Rectangle GetObjectRect()
        {
            if (Type == MarioType.MT_Small)
                return new Rectangle(x, y, 16, 16);
            if (Type == MarioType.MT_Big)
                return new Rectangle(x, y, 16, 27);
            if (Type == MarioType.MT_Fire)
                return new Rectangle(x, y, 16, 27);
            else
                return Rectangle.Empty;
        }
        public override void Intersection_None()
        {
            base.Intersection_None();

            if (State == MarioJumpState.J_None)
            {
                State = MarioJumpState.JDown;
                StartPosition = y;
                TimeCount = 0;
                StartVelocity = 0;

            }

        }

        public void MarioDie()
        {
            NumberOfCollectedCoins = 0;
            OnMarioDied?.Invoke();
        }

        public void MarioHandleCollision()
        {
            switch (Type)
            {
                case MarioType.MT_Fire:
                {
                    Type = Mario.MarioType.MT_Big;
                    StartBlinking();
                    SetMarioProperties();
                    break;
                }
                case MarioType.MT_Big:
                {
                    Type = Mario.MarioType.MT_Small;
                    StartBlinking();
                    SetMarioProperties();
                    break;
                }
                case MarioType.MT_Small:
                {
                    MarioDie();
                    break;
                }
            }
        }

        public bool IsBrickExistOnSidesRight()
        {
            Boolean res = false;

            for (int i = 0; i < IntersectsObjects.Count; i++)
                if (IntersectsObjects[i].G != null && (IntersectsObjects[i].G.OT == ObjectType.OT_Brick || IntersectsObjects[i].G.OT == ObjectType.OT_SolidBlock))
                    if (IntersectsObjects[i].C.Dir == CollisionDirection.CD_Right)
                        res = true;

            return res;
        }

        public bool IsBrickExistOnSidesLeft()
        {
            Boolean res = false;

            for (int i = 0; i < IntersectsObjects.Count; i++)
                if (IntersectsObjects[i].G != null && (IntersectsObjects[i].G.OT == ObjectType.OT_Brick || IntersectsObjects[i].G.OT == ObjectType.OT_SolidBlock))
                    if (IntersectsObjects[i].C.Dir == CollisionDirection.CD_Left)
                        res = true;

            return res;
        }
        public override void Intersection(Collision c, GraphicObject g)
        {
            base.Intersection(c, g);
            switch (g.OT)
            {
                case ObjectType.OT_Exit:
                {
                    if (EnterPressed)
                        {
                            EnterPressed = false;
                            //OnLevelCompleted?.Invoke();
                            System.Windows.Forms.MessageBox.Show("You won !");
                            StopMove();
                        }                   
                    break;
                } 
                case ObjectType.OT_Goomba:
                {
                    if (c.Dir == CollisionDirection.CD_Up)
                    {
                        if (((Goomba)g).FallDie == false)    // Jump On Goomba with Up Presses
                        {
                            if (UpPressed)
                                StartJump(true, 0);
                            else
                                StartJump(true, -20);

                            ((Goomba)g).GoombaDie();
                        }
                    }

                    if (c.Dir == CollisionDirection.CD_Left)
                        {
                            deathPositionX = x;
                            deathPositionY = y;
                            StopMove();
                        }
                    break;
                } 

                case ObjectType.OT_MovingBlock:
                    goto case ObjectType.OT_Grass;
                case ObjectType.OT_SolidBlock:
                    goto case ObjectType.OT_Grass;
                case ObjectType.OT_PipeUp:
                    goto case ObjectType.OT_Grass;
                case ObjectType.OT_BlockQuestion:
                    goto case ObjectType.OT_Grass;
                case ObjectType.OT_BlockQuestionHidden:
                    goto case ObjectType.OT_Grass;
                case ObjectType.OT_Brick:
                    goto case ObjectType.OT_Grass;
                case ObjectType.OT_Grass:
                {
                    SetDirections();

                    if (c.Dir == CollisionDirection.CD_TopLeft)
                    {
                        if (g.OT == ObjectType.OT_Brick)
                        {
                            //if (MoveState == MarioMoveState.J_Right)
                            //    x -= (int)XAdd;
                            //if (MoveState == MarioMoveState.J_Left)
                            //    x += (int)XAdd;
                            
                            //Intersection_None();
                        }
                    }
                    if (c.Dir == CollisionDirection.CD_Up)
                    {
                        if (g.OT == ObjectType.OT_MovingBlock)
                        {
                            this.y = g.newy - this.height;
  
                        }
                        else
                        {
                            if (State != MarioJumpState.J_None)
                                this.y = g.newy - this.height;
                        }
                        if (State != MarioJumpState.J_None)
                        {
                            State = MarioJumpState.J_None;
                        }
                        SetDirections();
                    }

                    if (c.Dir == CollisionDirection.CD_Left)
                    {
                        this.x = g.newx - width;
                        //if (g.OT == ObjectType.OT_SolidBlock)
                        //    Intersection_None();
                        if (g.OT == ObjectType.OT_Brick)
                        {
                            //if (MoveState == MarioMoveState.J_Right)
                            //    x -= (int)XAdd;
                            //if (MoveState == MarioMoveState.J_Left)
                            //    x += (int)XAdd;
                            this.x = g.newx - width;
                                
                        }
                    }

                    if (c.Dir == CollisionDirection.CD_Down)
                    {
                        if (State == MarioJumpState.J_Up)
                        {
                            State = MarioJumpState.JDown;
                            StartPosition = y;
                            TimeCount = 0;
                            StartVelocity = 0;
                            if (g.OT == ObjectType.OT_Brick)
                            {
                                if (Type == MarioType.MT_Big || Type == MarioType.MT_Fire)
                                {
                                    ((Block)g).BreakBrick();
                                }
                                else
                                {
                                }

                            }
                        }

                    }
                    if (c.Dir == CollisionDirection.CD_Right)
                    {
                        this.x = g.newx + g.width;
                        //if (g.OT == ObjectType.OT_SolidBlock)
                        //    Intersection_None();
                        //XAdd = 0;    
                    }
                    break;
                } 
            }
        }

        public void SetX(int x)
        {
            if (x > 0)
                Direction = MarioDir.MD_Right;
            else
                Direction = MarioDir.MD_Left;

            if (x == deathPositionX - 80)
            {
                System.Windows.Forms.MessageBox.Show("Je dois sauter");
            }

            this.x += x;
            SetDirections();
            Moving = true;
            //LevelGenerator.Raise_Event(LevelGenerator.LevelEvent.LE_Check_Collision);
        }

        public override void Draw()
        {
            if (BlinkingShow)
            {
                if (ObjectChangedDrawFlag)
                {
                    Graphics xGraph;
                    //xGraph = Graphics.FromImage(Screen.GetScreen);
                    xGraph = Screen.Instance.Background.xGraph;
                    Bitmap b = null;
                    if (Type == MarioType.MT_Small)
                        b = ImageGenerator.GetImage(ObjectType.OT_MarioSmall);
                    if (Type == MarioType.MT_Big)
                        b = ImageGenerator.GetImage(ObjectType.OT_MarioBig);
                    if (Type == MarioType.MT_Fire)
                        b = ImageGenerator.GetImage(ObjectType.OT_MarioFire);

                    //Rectangle dest = new Rectangle(x - Screen.BackgroundScreen.x, y + Screen.BackgroundScreen.y, b.Width / ImageCount, b.Height);
                    Rectangle dest = new Rectangle(x - Screen.BackgroundScreen.x, y - (LevelGenerator.LevelHeight - Screen.BackgroundScreen.height) + Screen.BackgroundScreen.y, width, height);
                    Rectangle src = new Rectangle(16 * ImageIndex, 0, b.Width / 6, b.Height);

                    xGraph.DrawImage(b, dest, src, GraphicsUnit.Pixel);
                }
            }

        }

        public void SetDirections()
        {
            if (State != MarioJumpState.J_None)
            {
                if (Direction == MarioDir.MD_Left)
                    ImageIndex = 4;

                if (Direction == MarioDir.MD_Right)
                    ImageIndex = 5;

            }
            else if (Moving)
            {
                if (Direction == MarioDir.MD_Left)
                    if (ImageIndex == 0)
                        ImageIndex = 1;
                    else
                        ImageIndex = 0;

                if (Direction == MarioDir.MD_Right)
                    if (ImageIndex == 2)
                        ImageIndex = 3;
                    else
                        ImageIndex = 2;
            }
            else
            {
                if (Direction == MarioDir.MD_Right)
                    ImageIndex = 2;

                if (Direction == MarioDir.MD_Left)
                    ImageIndex = 0;
            }

        }

        public void StopJump()
        {
            UpPressed = false;
            if (State != MarioJumpState.J_None)
            {
                State = MarioJumpState.JDown;
                StartPosition = y;
                TimeCount = 0;
                StartVelocity = 0;
            }

        }
        public void StartJump(Boolean Kill, double DefeaultVelocity)
        {
            if (Kill == false)
                UpPressed = true;

            if (State == MarioJumpState.J_None || Kill == true)
            {
                Media.PlaySound(Media.SoundType.ST_Jump);
                State = MarioJumpState.J_Up;
                StartPosition = y;
                OldPosition = y;
                CurrentPosition = y;
                TimeCount = 0;
                if (DefeaultVelocity != 0)
                    StartVelocity = DefeaultVelocity;
                else
                    StartVelocity = -38;
            }

        }

        public double CalcMarioJumpPosition()
        {//http://study.eitan.ac.il/sites/index.php?portlet_id=110529&page_id=13
            return StartPosition + StartVelocity * TimeCount + 4.9 * TimeCount * TimeCount;
        }

        public void OnJumpTick(Object sender, EventArgs e)
        {
            if (State != MarioJumpState.J_None)
            {
                SetDirections();
                TimeCount += (350.0 / 1000.0);
                OldPosition = CurrentPosition;
                CurrentPosition = CalcMarioJumpPosition();
                if (State == MarioJumpState.J_Up)
                    y = (int)(CurrentPosition);
                else
                    y += 6 + (int)TimeCount;

                LevelGenerator.CurrentLevel.Update_ScreensY();

                if (State == MarioJumpState.J_Up)
                    if (CurrentPosition > OldPosition)
                    {
                        State = MarioJumpState.JDown;
                        TimeCount = 0;
                    }

                //LevelGenerator.Raise_Event(LevelGenerator.LevelEvent.LE_Check_Collision);

            }
            else
            {
                TimeCount = 0;
            }
        }

        public void MarioMove(MarioMoveState s)
        {
            MoveState = s;

            if (Direction != MarioDir.MD_Left)
                if (s == MarioMoveState.J_Left)
                    Direction = MarioDir.MD_Left;

            if (Direction != MarioDir.MD_Right)
                if (s == MarioMoveState.J_Right)
                    Direction = MarioDir.MD_Right;

            if (x == deathPositionX - 10)
            {
                UpPressed = true;
                Jumping = true;
                State = MarioJumpState.J_Up;
            }

            // LevelGenerator.Raise_Event(LevelGenerator.LevelEvent.LE_Check_Collision);
        }

        public void StopMove()
        {

            if (MoveState != MarioMoveState.J_Stopping)
            {

                switch (MoveState)
                {
                    case MarioMoveState.J_Left:
                        Direction = MarioDir.MD_Left; break;

                    case MarioMoveState.J_Right:
                        Direction = MarioDir.MD_Right; break;
                }


                MoveState = MarioMoveState.J_Stopping;

                //bug walls
                if (!UpPressed)
                {
                    XCount = 5;
                    XAdd = 0;
                }
            }

        }
        public void OnMoveTick(Object sender, EventArgs e)
        {


            if (y > LevelGenerator.CurrentLevel.height + 50)
            {
                MarioDie();
            }


            if (MoveState != MarioMoveState.J_None && MoveState != MarioMoveState.J_Stopping)
            {
                Moving = true;
                SetDirections();
                //LevelGenerator.Raise_Event(LevelGenerator.LevelEvent.LE_Check_Collision);
                LevelGenerator.CurrentLevel.Update_ScreensX();

                if (XAdd < 3)
                    XAdd += 0.5;
                if (!IsBrickExistOnSidesLeft())
                {
                    if (MoveState == MarioMoveState.J_Right)
                        x += 3 + (int)XAdd;
                }
                if (!IsBrickExistOnSidesRight())
                {

                    if (MoveState == MarioMoveState.J_Left)
                        x -= 3 + (int)XAdd;
                }

                UpPressed = true;


            }
            if (MoveState == MarioMoveState.J_Stopping)
            {
                Moving = true;
                SetDirections();
                LevelGenerator.CurrentLevel.Update_ScreensX();

                XCount = Math.Sqrt(XCount);

                if (Direction == MarioDir.MD_Right)
                    x += (int)XCount;

                if (Direction == MarioDir.MD_Left)
                    x -= (int)XCount;

                if (XCount < 1.05) // when Standing
                {
                    MoveState = MarioMoveState.J_None;
                    Moving = false;
                }
            }


        }

        public override void OnAnimate(object sender, EventArgs e)
        {

            if (Blinking)
            {
                BlinkValue++;
                BlinkingShow = (BlinkValue % 2 == 0);

                if (BlinkValue == 20)
                {
                    Blinking = false;
                    BlinkingShow = true;
                }
            }
        }

        public void SetMarioProperties()
        {
            if (Type == MarioType.MT_Small)
            {
                width = 16;
                height = 16;
                y += 11;
            }
            if (Type == MarioType.MT_Big)
            {
                width = 16;
                height = 27;
                y -= 11;
            }
            if (Type == MarioType.MT_Fire)
            {
                width = 16;
                height = 27;
                y -= 11;
            }
        }

        public void StartBlinking()
        {
            if (Blinking == false)
            {
                Blinking = true;
                BlinkValue = 0;
            }
        }
        public Mario(int x, int y)
            : base(ObjectType.OT_Mario)
        {
            FireBalls = new List<FireBall>();
            for (int i = 0; i < 2; i++)
                FireBalls.Add(new FireBall(0, 0));

            for (int i = 0; i < 2; i++)
                AddObject(FireBalls[i]);

            Type = MarioType.MT_Small;
            SetMarioProperties();

            this.x = x * 16;
            this.y = LevelGenerator.LevelHeight - 16 * y - height;
            Visible = true;
            UpPressed = false;
            Blinking = false;
            BlinkingShow = true;
            NumberOfCollectedCoins = 0;


            Moving = true;
            Jumping = false;
            Direction = MarioDir.MD_Right;
            EnterPressed = true;


            State = MarioJumpState.J_None;
            MoveState = MarioMoveState.J_Right;

            TimerGenerator.AddTimerEventHandler(TimerType.TT_100, OnAnimate);
            TimerGenerator.AddTimerEventHandler(TimerType.TT_50, OnJumpTick);
            TimerGenerator.AddTimerEventHandler(TimerType.TT_50, OnMoveTick);
            TimerGenerator.AddTimerEventHandler(TimerType.TT_50, OnCheckCollisions);

        }

    }


}
