using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient {
    class Tank {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Flag { get; set; }
        //видиомть танка
        public static int TankVisible { get; set; }
        //число клеток
        public static int CountCell { get; set; }

        public enum Orientation {
            Direct = 0, Right, Back, Left
        }
        public Orientation Orient { get; set; }


        //поражение танка противника в области видимости
        public static void Attack(List<Tank> tanks1, List<Tank> tanks2) {
            foreach (var tank1 in tanks1) {
                foreach (var tank2 in tanks2.ToList()) {
                    switch (tank1.Orient) {
                        case Tank.Orientation.Direct:
                            if (tank1.Y == tank2.Y)
                                if (Math.Abs(tank1.X - tank2.X) <= TankVisible && tank1.X - tank2.X > 0)
                                    tanks2.Remove(tank2);
                            break;

                        case Tank.Orientation.Right:
                            if (tank1.X == tank2.X)
                                if (Math.Abs(tank1.Y - tank2.Y) <= TankVisible && tank1.Y - tank2.Y < 0)
                                    tanks2.Remove(tank2);
                            break;
                        case Tank.Orientation.Back:
                            if (tank1.Y == tank2.Y)
                                if (Math.Abs(tank1.X - tank2.X) <= TankVisible && tank1.X - tank2.X < 0)
                                    tanks2.Remove(tank2);
                            break;
                        case Tank.Orientation.Left:
                            if (tank1.X == tank2.X)
                                if (Math.Abs(tank1.Y - tank2.Y) <= TankVisible && tank1.Y - tank2.Y > 0)
                                    tanks2.Remove(tank2);
                            break;
                    }
                }
            }
        }

        //перемещение и поворот танка
        public static void MoveRotateTank(List<Tank> tank) {
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < tank.Count; i++) {
                int move =  rand.Next(-1, 1);
                int rotate = rand.Next(-5, 5);
                switch (rotate) {
                    //поворот налево
                    case -1:
                        tank[i].Orient = (tank[i].Orient == Tank.Orientation.Direct)
                            ? tank[i].Orient = Tank.Orientation.Left
                            : tank[i].Orient - 1;
                        break;
                    //поворот направо
                    case 1:
                        tank[i].Orient = (tank[i].Orient == Tank.Orientation.Left)
                            ? tank[i].Orient = Tank.Orientation.Direct
                            : tank[i].Orient + 1;
                        break;
                }

                switch (move) {
                    //движение назад
                    case -1:
                        switch (tank[i].Orient) {
                            case Tank.Orientation.Back:
                                if (tank[i].X != 0)
                                    tank[i].X--;
                                break;
                            case Tank.Orientation.Right:
                                if (tank[i].Y != 0)
                                    tank[i].Y--;
                                break;
                            case Tank.Orientation.Direct:
                                if (tank[i].X != CountCell - 1)
                                    tank[i].X++;
                                break;
                            case Tank.Orientation.Left:
                                if (tank[i].Y != CountCell - 1)
                                    tank[i].Y++;
                                break;
                        }
                        break;

                    //движение вперед
                    case 1:
                        switch (tank[i].Orient) {
                            case Tank.Orientation.Direct:
                                if (tank[i].X != 0)
                                    tank[i].X--;
                                break;
                            case Tank.Orientation.Left:
                                if (tank[i].Y != 0)
                                    tank[i].Y--;
                                break;
                            case Tank.Orientation.Back:
                                if (tank[i].X != CountCell - 1)
                                    tank[i].X++;
                                break;
                            case Tank.Orientation.Right:
                                if (tank[i].Y != CountCell - 1)
                                    tank[i].Y++;
                                break;
                        }
                        break;
                }
            }
        }

        //инициализация танков
        public static void InitTanks(ref List<Tank> tanks, int tanksCount, bool blue) {
            Random rand = new Random(DateTime.Now.Millisecond);
            tanks = new List<Tank>();

            for (int i = 0; i < tanksCount; i++) {
                int x, y;
                bool flag = false;

                do {
                    //позиция на поле
                    if (blue)
                        x = rand.Next(15, 30);
                    else {
                        x = rand.Next(0, 15);
                    }
                    y = rand.Next(0, 30);
                    foreach (var tank in tanks) {
                        if (tank.X == x && tank.Y == y)
                            flag = true;
                    }
                } while (flag);

                //ориентация
                int rotate = rand.Next(0, 3);
                Tank t = new Tank() { Flag = true, X = x, Y = y, Orient = (Tank.Orientation)rotate };
                tanks.Add(t);
            }
        }

    }
}
