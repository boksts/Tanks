using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace WcfServer {
    
    public class FieldTanks : IFieldTanks {
        //число клеток
        private const int cellCount = 30;
        //расчетное поле
        private int[,] field = new int[cellCount, cellCount];

        //цвет танка
        public enum TankColor {
            Blue = 1,
            Red = -1
        }

        //инициализация танков
        public List<Tank> InitTanks(int tanksCount, int tankVisible) {
            Random rand;
            List<Tank> tanks = new List<Tank>();
            rand = new Random(DateTime.Now.Millisecond);

            Tank.CellCount = cellCount;
            Tank.TankVisible = tankVisible;
            TankColor tankColor = TankColor.Blue;

            for (int i = 0; i < 2 * tanksCount; i++) {
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

                Tank t = new Tank() { X = x, Y = y, Orient = (Tank.Orientation)rotate, Color = (int)tankColor };
                tanks.Add(t);
            }
            return tanks;
        }

        //заполнение поля танками
        public int[] FillField(List<Tank> tanks) {
            int[] field2 = new int[cellCount * cellCount];

            //заполенение поля танкам
            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++) {
                    field[i, j] = 0;
                    foreach (var tank in tanks) {
                        if (i == tank.X && j == tank.Y)
                            field[i, j] = (int)tank.Orient * tank.Color;
                    }
                }

            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++)
                    field2[i * cellCount + j] = field[i, j];

            return field2;
        }

        //стратегия
        public List<Tank> ApplyStrategy(List<Tank> tanks, TankColor tankColor, string player, bool attack) {
            int[] field2 = FillField(tanks);
            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++)
                    field[i, j] = field2[i * cellCount + j];

            int x, y;
            foreach (var tank1 in tanks.ToList()) {
                if (tank1.Color == (int) tankColor) {
                    tank1.Strategy(out x, out y, field, attack);
                    //если танк подбит
                    if (x != -1) {
                        foreach (var tank2 in tanks.ToList())
                            if (tank2.X == x && tank2.Y == y) {
                                tanks.Remove(tank2);
                            }
                    }
                }

                //заполнение журнала
                using (TankContext db = new TankContext()) {
                    TankDetail tank = new TankDetail {
                        X = tank1.X,
                        Y = tank1.Y,
                        Color = (tank1.Color==-1)?"Красный":"Синий",
                        Orient = Orient(tank1),
                        Player = player,
                        Strategy = (attack) ? "Aтака" : "Оборона",
                    };

                    db.TankDetails.Add(tank);
                    db.SaveChanges();
                }
            }
            return tanks;
        }

        //доступ к журналу
        public List<TankDetail> SelectTankDetails(bool delete) {
            //очистка журнала
            if (delete)
                ClearTankJournal();

            using (TankContext db = new TankContext()) {
                return db.TankDetails.ToList();
            }
        }


        //очистка журнала
        private void ClearTankJournal() {
            using (TankContext db = new TankContext()) {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [TankDetails]");
            }
        }

        //ориентация танка для записи в журнал
        private string Orient(Tank tank) {
            string str = "";

            switch (tank.Orient) {
                case Tank.Orientation.Direct:
                    str = "Прямо";
                    break;
                case Tank.Orientation.Back:
                    str = "Назад";
                    break;
                case Tank.Orientation.Left:
                    str = "Влево";
                    break;
                case Tank.Orientation.Right:
                    str = "Вправо";
                    break;
            }

            return str;
        }
    }

}