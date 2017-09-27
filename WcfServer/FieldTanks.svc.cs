using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace WcfServer {
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class FieldTanks: IFieldTanks {
        //количество клеток
        private int cellCount;
        //число танков кажждой команды
        private int tanksCount;
        //видимость танка
        private int tankVisible;

        private List<Tank> tanks1;
        private List<Tank> tanks2;

        private int[,] field;

        public enum TankColor {
            Blue = 1,
            Red = -1
        }

        public void InitField(int _cellCount, int _tanksCount, int _tankVisible) {
            tanksCount = _tanksCount;
            tankVisible = _tankVisible;
            cellCount = _cellCount;
            field = new int[cellCount, cellCount];
        }


        //инициализация танков
        public void InitTanks(TankColor tankColor) {
            Random rand;
            List<Tank> tanks = new List<Tank>();

            if (tankColor == TankColor.Blue) {
                rand = new Random(DateTime.Now.Second);
                tanks1 = new List<Tank>();
            }
                
            else {
                rand = new Random(DateTime.Now.Millisecond);
                tanks2 = new List<Tank>();
            }

            Tank.CountCell = cellCount;
            Tank.TankVisible = tankVisible;

            for (int i = 0; i < tanksCount; i++) {
                int x, y;
                bool flag = false;
                
                do {
                    //позиция на поле
                    if (tankColor == TankColor.Blue) {
                        x = rand.Next(0, 15);
                    }
                       
                    else {
                        x = rand.Next(15, 30);             
                    }
                    y = rand.Next(0, 30);
                    foreach (var tank in tanks) {
                        if (tank.X == x && tank.Y == y)
                            flag = true;
                    }
                } while (flag);

                //ориентация
                int rotate = rand.Next(1, 4);

                Tank t = new Tank() { X = x, Y = y, Orient = (Tank.Orientation)rotate,Color = (int)tankColor};
                tanks.Add(t);

                if (tankColor == TankColor.Blue) {
                    tanks1 = tanks;
                }
                else {
                    tanks2 = tanks;
                }
            }
        }

        //заполнение поля танками
        public int[] FillField() {
            int [] field2 = new int[cellCount*cellCount];
            //заполенение поля танкам
            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++) {
                    field[i, j] = 0;
                    foreach (var tank in tanks1) {
                        if (i == tank.X && j == tank.Y)
                            field[i, j] = (int)tank.Orient;
                    }
                    foreach (var tank in tanks2) {
                        if (i == tank.X && j == tank.Y)
                            field[i, j] = -(int)tank.Orient;
                    }
                }

            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++)
                    field2[i * cellCount + j] = field[i, j];
            return field2;
        }


        public void ApplyStrategy(TankColor tankColor, bool attack = false) {
            if (tankColor == TankColor.Blue) {
                Strategy(tanks1, tanks2, attack);
            }              
            else {
                Strategy(tanks2, tanks1, attack);
            }
        }

        private void Strategy(List<Tank> tanks1, List<Tank> tanks2, bool attack) {
            int x, y;
            foreach (var tank1 in tanks1) {
                tank1.Strategy(out x, out y, field, attack);
                if (x != -1) {
                    foreach (var tank2 in tanks2.ToList())
                        if (tank2.X == x && tank2.Y == y) {
                            tanks2.Remove(tank2);
                            field[x, y] = 0;
                        }
                }
            }
        }

  
    }



}
