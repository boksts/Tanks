using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient {
    partial class Form1{
        //количество клеток
        protected readonly int countCell = 30;
        //размер клетки
        protected readonly int sizeCell = 20;
        //число танков кажждой команды
        private readonly int tanksCount = 3;
        //видимость танка
        private readonly int tankVisible = 5;

        private PictureBox[] tnBlue;
        private PictureBox[] tnRed;
        
        private List<Tank> tanks1;
        private List<Tank> tanks2;

        private Color[,] field;

        //инициализация танков
        private void InitTanks(ref List<Tank> tanks, Color color) {
            Random rand;
            if (color == Color.Blue)
                 rand = new Random(DateTime.Now.Second);
            else {
                 rand = new Random(DateTime.Now.Millisecond);
            }
            
            tanks = new List<Tank>();
            Tank.CountCell = countCell;
            Tank.TankVisible = tankVisible;

            for (int i = 0; i < tanksCount; i++) {
                int x, y;
                bool flag = false;

                do {
                    //позиция на поле
                    if (color == Color.Blue)
                        x = rand.Next(15, 30);
                    else {
                        x = rand.Next(0, 30);
                    }
                    y = rand.Next(0, 30);
                    foreach (var tank in tanks) {
                        if (tank.X == x && tank.Y == y)
                            flag = true;
                    }
                } while (flag);

                //ориентация
                int rotate = rand.Next(0, 3);
                Tank t = new Tank() { X = x, Y = y, Orient = (Tank.Orientation)rotate, Color = color};
                tanks.Add(t);
            }
        }

        //инициализация поля
        public void InitField() {

            field = new Color[countCell, countCell];
            
            //размеры поля (грида)
            dgvGameField.Width = dgvGameField.Height = countCell * sizeCell + 3;

            //для возможности добавление картинок в ячейки
            for (int i = 0; i < countCell; i++) {
                dgvGameField.Columns.Add(new DataGridViewImageColumn());
                if (i != countCell - 1)
                    dgvGameField.Rows.Add();
            }

            //размер ячеек
            for (int i = 0; i < dgvGameField.ColumnCount; i++) {
                dgvGameField.Columns[i].Width = dgvGameField.Rows[i].Height = sizeCell;
            }

            //ориентации синих танков
            tnBlue = new PictureBox[4];
            for (int i = 0; i < 4; i++) {
                tnBlue[0] = new PictureBox() { Image = Image.FromFile(@"Pictures\tn_blue.jpg") };
                tnBlue[1] = new PictureBox() { Image = Image.FromFile(@"Pictures\tn_blue.jpg") };
                tnBlue[1].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                tnBlue[2] = new PictureBox() { Image = Image.FromFile(@"Pictures\tn_blue.jpg") };
                tnBlue[2].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                tnBlue[3] = new PictureBox() { Image = Image.FromFile(@"Pictures\tn_blue.jpg") };
                tnBlue[3].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            //ориентации красных танков
            tnRed = new PictureBox[4];
            for (int i = 0; i < 4; i++) {
                tnRed[0] = new PictureBox() { Image = Image.FromFile(@"Pictures\tn_red.jpg") };
                tnRed[1] = new PictureBox() { Image = Image.FromFile(@"Pictures\tn_red.jpg") };
                tnRed[1].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                tnRed[2] = new PictureBox() { Image = Image.FromFile(@"Pictures\tn_red.jpg") };
                tnRed[2].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                tnRed[3] = new PictureBox() { Image = Image.FromFile(@"Pictures\tn_red.jpg") };
                tnRed[3].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

        }

        //заполнение поля танками
        private void UpdateField() {
            //заполенение поля танками
            for (int i = 0; i < dgvGameField.ColumnCount; i++)
                for (int j = 0; j < dgvGameField.RowCount; j++)
                    dgvGameField.Rows[i].Cells[j].Value = Image.FromFile(@"Pictures\white.jpg");

            foreach (var tank in tanks1) {
                dgvGameField.Rows[tank.X].Cells[tank.Y].Value = tnRed[(int)tank.Orient].Image;

            }
            foreach (var tank in tanks2) {
                dgvGameField.Rows[tank.X].Cells[tank.Y].Value = tnBlue[(int)tank.Orient].Image;
            }

            for (int i = 0; i < countCell; i++)
                for (int j = 0; j < countCell; j++) {
                    field[i, j] = Color.White;
                    foreach (var tank in tanks1) {
                        if (i == tank.X && j == tank.Y)
                            field[i, j] = tank.Color;
                    }
                    foreach (var tank in tanks2) {
                        if (i == tank.X && j == tank.Y)
                            field[i, j] = tank.Color;
                    }
                }

        }


        private void Strategy(List<Tank> tanks1,List<Tank> tanks2, bool attack = false) {
            int x, y;
            foreach (var tank1 in tanks1) {
                tank1.Strategy(out x, out y, field, attack);
                if (x != -1) {
                    foreach (var tank2 in tanks2.ToList())
                        if (tank2.X == x && tank2.Y == y)
                            tanks2.Remove(tank2);
                }
            }

        }

    }
}
