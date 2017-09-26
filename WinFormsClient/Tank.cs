using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient {
    class Tank {
        public int X { get; set; }
        public int Y { get; set; }
        //цвет танка
        public Color Color { get; set; }
        //видиомть танка
        public static int TankVisible { get; set; }
        //число клеток
        public static int CountCell { get; set; }

        public enum Orientation {
            Direct = 0, Right, Back, Left
        }
        public Orientation Orient { get; set; }


        //оборона танка
        public void Defense(Color[,] field,  out int x, out int y, bool attack = false) {
            int x1 = (X - TankVisible) >= 0 ? X - TankVisible : 0;
            int xN = (X + TankVisible) < CountCell ? X + TankVisible : CountCell - 1;
            int y1 = (Y - TankVisible) >= 0 ? Y - TankVisible : 0;
            int yN = (Y + TankVisible) < CountCell ? Y + TankVisible : CountCell - 1;
            x = y = -1;

            for (int i = x1; i <= xN; i++)
                for (int j = y1; j <= yN; j++) {
                    if (field[i, j] != Color && field[i, j] != Color.White) {
                       
                        //танк на одной линии с противником
                        if (i == X) {
                            if (j < Y) {
                                if (Orient == Orientation.Left) {
                                    x = i;
                                    y = j;
                                }
                                else Orient = (Orient == Tank.Orientation.Direct)
                                    ? Orient = Tank.Orientation.Left
                                    : Orient - 1;
                            }
                            else if (j > Y) {
                                if (Orient == Orientation.Right) {
                                    x = i;
                                    y = j;
                                }
                                else Orient = (Orient == Tank.Orientation.Direct)
                                    ? Orient = Tank.Orientation.Left
                                    : Orient - 1;
                            }
                            return;
                        }

                        //танк на одной линии с противником
                        if (j == Y) {
                            if (i < X) {
                                if (Orient == Orientation.Direct) {
                                    x = i;
                                    y = j;
                                }
                                else Orient = (Orient == Tank.Orientation.Direct)
                                    ? Orient = Tank.Orientation.Left
                                    : Orient - 1;
                            }
                            if (i > X) {
                                if (Orient == Orientation.Back) {
                                    x = i;
                                    y = j;
                                }
                                else Orient = (Orient == Tank.Orientation.Direct)
                                    ? Orient = Tank.Orientation.Left
                                    : Orient - 1;
                            }
                            
                            return; 
                        }

                        //танк не на одной линии
                        if (Math.Abs(i - X) < Math.Abs(j - Y)) {
                            //танк движется вверх
                            if (i < X) {
                                if (Orient == Orientation.Back || Orient == Orientation.Direct) {  
                                    if(field[X-1, Y] == Color.White) {
                                        X--;
                                        field[X, Y] = Color;
                                        field[X+1, Y] = Color.White;
                                    }
                                }      
                                else Orient --;
                                return;
                            }
                            //танк движется вниз
                            if (i > X) {
                                if (Orient == Orientation.Back || Orient == Orientation.Direct) {
                                    if (field[X + 1, Y] == Color.White) {
                                        X++;
                                        field[X, Y] = Color;
                                        field[X-1, Y] = Color.White;
                                    }
                                }
                                else Orient --;
                                return;
                            }
                        }

                        //танк не на одной линии
                        else {
                            //танк движется вверх
                            if (j < Y) {
                                if (Orient == Orientation.Left || Orient == Orientation.Right){
                                    if (field[X, Y - 1] == Color.White) {
                                        Y--;
                                        field[X, Y] = Color;
                                        field[X, Y+1] = Color.White;
                                    }
                                }
                                else 
                                    Orient = (Orient == Tank.Orientation.Direct)
                                        ? Orient = Tank.Orientation.Left
                                        : Orient - 1;
                                return;
                            }
                            //танк движется вниз
                            if (j > Y) {
                                if (Orient == Orientation.Left || Orient == Orientation.Right) {
                                    if (field[X, Y + 1] == Color.White) {
                                        Y++;
                                        field[X, Y] = Color;
                                        field[X, Y-1] = Color.White;
                                    }
                                }
                                else 
                                    Orient = (Orient == Tank.Orientation.Direct)
                                        ? Orient = Tank.Orientation.Left
                                        : Orient - 1;
                                return;
                            }
                        }
                    }


                }

            if (attack) {
                if (X - TankVisible < 0) {
                    if (Orient == Orientation.Back || Orient == Orientation.Direct) {
                        if (field[X + 1, Y] == Color.White) {
                            X++;
                            field[X, Y] = Color;
                            field[X-1, Y] = Color.White;
                        }
                    }
                    else Orient--;
                    return;
                }
                if (X + TankVisible > CountCell) {
                    if (Orient == Orientation.Back || Orient == Orientation.Direct) {
                        if (field[X - 1, Y] == Color.White) {
                            X--;
                            field[X, Y] = Color;
                            field[X+1, Y] = Color.White;
                        }
                    }
                    else Orient--;
                    return;
                }
                if (Y - TankVisible < 0) {
                    if (Orient == Orientation.Left || Orient == Orientation.Right) {
                        if (field[X, Y + 1] == Color.White) {
                            Y++;
                            field[X, Y] = Color;
                            field[X, Y-1] = Color.White;
                        }
                    }
                    else
                        Orient = (Orient == Tank.Orientation.Direct)
                            ? Orient = Tank.Orientation.Left
                            : Orient - 1;
                    return;
                }
                if (Y + TankVisible > CountCell) {
                    if (Orient == Orientation.Left || Orient == Orientation.Right) {
                        if (field[X, Y - 1] == Color.White) {
                            Y--;
                            field[X, Y] = Color;
                            field[X, Y+1] = Color.White;
                        }
                    }
                    else
                        Orient = (Orient == Tank.Orientation.Direct)
                            ? Orient = Tank.Orientation.Left
                            : Orient - 1;
                    return;
                }

                if (Color == Color.Blue)
                    if (Orient == Orientation.Back || Orient == Orientation.Direct) {
                        if (field[X - 1, Y] == Color.White) {
                            X--;
                            field[X, Y] = Color;
                            field[X + 1, Y] = Color.White;
                        }
                    }
                    else Orient--;
                else {
                    if (Orient == Orientation.Back || Orient == Orientation.Direct) {
                        if (field[X + 1, Y] == Color.White) {
                            X++;
                            field[X, Y] = Color;
                            field[X - 1, Y] = Color.White;
                        }
                    }
                    else Orient--;
                }
        

            }
        }
    }
}
