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
        //private int cellCount;
        //число танков кажждой команды
       // private int tanksCount;
        //видимость танка
        //private int tankVisible;

       // private List<Tank> tanks1;
       // private List<Tank> tanks2;

     //   private int[,] field;
        private const int cellCount = 30;

        private int[,] field = new int[cellCount, cellCount];

        public enum TankColor {
            Blue = 1,
            Red = -1
        }

        //инициализация танков
        public List<Tank> InitTanks(int tanksCount, int tankVisible) {
            Random rand;
            List<Tank> tanks = new List<Tank>();
            rand = new Random(DateTime.Now.Millisecond);
        
            Tank.CountCell = cellCount;
            Tank.TankVisible = tankVisible;
            TankColor tankColor = TankColor.Blue;

            for (int i = 0; i < 2*tanksCount; i++) {
                int x, y;
                bool flag = false;

                if (i >= tanksCount) {
                    tankColor = TankColor.Red;  
                }
                                              
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
                
                Tank t = new Tank() { X = x, Y = y, Orient = (Tank.Orientation)rotate, Color = (int)tankColor};
                tanks.Add(t);
            }
            return tanks;
        }

        //заполнение поля танками
        public int[] FillField(List<Tank> tanks) {
            int [] field2 = new int[cellCount*cellCount];
            
            //заполенение поля танкам
            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++) {
                    field[i, j] = 0;
                    foreach (var tank in tanks) {
                        if (i == tank.X && j == tank.Y)
                            field[i, j] = (int)tank.Orient*tank.Color;
                    }     
                }

            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++)
                    field2[i * cellCount + j] = field[i, j];
            
            return field2;
        }


        public List<Tank> ApplyStrategy(List<Tank> tanks, TankColor tankColor, bool attack) {
            if (tankColor == TankColor.Blue) {
              return Strategy(tanks, tankColor, attack);
            }              
            else {
                return Strategy(tanks, tankColor, attack);
            }
        }

        private List<Tank> Strategy(List<Tank> tanks, TankColor tankColor, bool attack) {
            int[] field2 = FillField(tanks);
            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++)
                    field[i, j] = field2[i * cellCount + j];

            int x, y;
            foreach (var tank1 in tanks.ToList()) {
                if (tank1.Color == (int) tankColor) {
                    tank1.Strategy(out x, out y, field, attack);
                    if (x != -1) {
                        foreach (var tank2 in tanks.ToList())
                            if (tank2.X == x && tank2.Y == y) {
                                tanks.Remove(tank2);
                            }
                    }
                }
               
            }

            return tanks;
        }

  
    }



}
