using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServer {
    public class Tank {
        
        public int X { get; set; }
        public int Y { get; set; }
        //цвет танка
        public int Color { get; set; }
        //видиомть танка
        public static int TankVisible { get; set; }
        //число клеток
        public static int CountCell { get; set; }
        //перемещение танка
        public enum Movement {
            Up = 0, Right, Down, Left
        }
        
        //ориентация танка 
        private Orientation _orient;
        public enum Orientation {
            Direct = 1, Right, Back, Left
        }
        public Orientation Orient {
            get { return _orient; }
            set { _orient = ((int)value == 0) ? Orientation.Left : value; }
        }

        //перемещение танка
        public void Move(Movement move, int[,] field) {
            switch (move) {
                case Movement.Up:
                    if (Orient == Orientation.Back || Orient == Orientation.Direct) {
                        if (field[X - 1, Y] == 0) {
                            X--;
                            field[X, Y] = Color;
                            field[X + 1, Y] = 0;
                        }
                    }
                    else Orient--;
                    break;
                case Movement.Down:
                    if (Orient == Orientation.Back || Orient == Orientation.Direct) {
                        if (field[X + 1, Y] == 0) {
                            X++;
                            field[X, Y] = Color;
                            field[X - 1, Y] = 0;
                        }
                    }
                    else Orient--;
                    break;
                case Movement.Left:
                    if (Orient == Orientation.Left || Orient == Orientation.Right) {
                        if (field[X, Y - 1] == 0) {
                            Y--;
                            field[X, Y] = Color;
                            field[X, Y + 1] = 0;
                        }
                    }
                    else
                        Orient--;
                    break;
                case Movement.Right:
                    if (Orient == Orientation.Left || Orient == Orientation.Right) {
                        if (field[X, Y + 1] == 0) {
                            Y++;
                            field[X, Y] = Color;
                            field[X, Y - 1] = 0;
                        }
                    }
                    else
                        Orient--;
                    break;
            }
        }

        //оборона танка и защита
        public void Strategy(out int x, out int y, int[,] field, bool attack) {
            int vis = 0;
            do {
                vis++;
                int x1 = (X - vis) >= 0 ? X - vis : 0;
                int xN = (X + vis) < CountCell ? X + vis : CountCell - 1;
                int y1 = (Y - vis) >= 0 ? Y - vis : 0;
                int yN = (Y + vis) < CountCell ? Y + vis : CountCell - 1;
                x = y = -1;

                //оборона
                for (int i = x1; i <= xN; i++)
                    for (int j = y1; j <= yN; j++) {
                        if ((field[i, j] * Color)<0 && field[i, j] != 0) {
                            //танк на одной линии с противником
                            if (i == X) {
                                if (j < Y) {
                                    if (Orient == Orientation.Left) { x = i; y = j; }
                                    else Orient--;
                                }
                                else if (j > Y) {
                                    if (Orient == Orientation.Right) { x = i; y = j; }
                                    else Orient--;
                                }
                                return;
                            }
                            //танк на одной линии с противником
                            if (j == Y) {
                                if (i < X) {
                                    if (Orient == Orientation.Direct) { x = i; y = j; }
                                    else Orient--;
                                }
                                if (i > X) {
                                    if (Orient == Orientation.Back) { x = i; y = j; }
                                    else Orient--;
                                }
                                return;
                            }

                            //танк не на одной линии
                            if (Math.Abs(i - X) < Math.Abs(j - Y)) {
                                //танк движется вверх
                                if (i < X) Move(Movement.Up, field);
                                //танк движется вниз
                                if (i > X) Move(Movement.Down, field);
                                return;
                            }
                            //танк не на одной линии
                            else {
                                //танк движется вверх
                                if (j < Y) Move(Movement.Left, field);
                                //танк движется вниз
                                if (j > Y) Move(Movement.Right, field);
                                return;
                            }
                        }
                    }
            } while (vis < TankVisible);

            //атака
            if (attack)
                Attack(field);

        }

        public void Attack(int[,] field) {

            if (X - TankVisible < 0) {
                Move(Movement.Down, field);
                return;
            }
            if (X + TankVisible > CountCell) {
                Move(Movement.Up, field);
                return;
            }
            if (Y - TankVisible < 0) {
                Move(Movement.Right, field);
                return;
            }
            if (Y + TankVisible > CountCell) {
                Move(Movement.Left, field);
                return;
            }

            if (Color == -1) Move(Movement.Up, field);
            else Move(Movement.Down, field);
        }
    
    }
}