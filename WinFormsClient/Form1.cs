using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient {
    public partial class Form1 : Form {
        //количество клеток
        private readonly int countCell = 30;
        //размер клетки
        private readonly int sizeCell = 20;
        //число танков кажждой команды
        private readonly int tanksCount = 5;
        //видимость танка
        private readonly int tankVisible = 5;
        private List<Tank> tanks1;
        private List<Tank> tanks2;
        private PictureBox[] tnBlue;
        private PictureBox[] tnRed;

        //танк
        class Tank {
            public int X { get; set; }
            public int Y { get; set; }
            public bool Flag { get; set; }
             public enum Orientation {
                Direct = 0, Right, Back, Left
            }
            public Orientation Orient { get; set; }
           
        }


        public Form1() {
            InitializeComponent();
            this.Width = countCell * (sizeCell + 1) + 250;
            this.Height = countCell * (sizeCell + 1) + 50;
            InitTanks(ref tanks1,blue:true);
            InitTanks(ref tanks2, blue: false);
            InitField();
            UpdateField();
        }

        //инициализация танка
        private void InitTanks(ref List<Tank> tanks, bool blue) {
            Random rand = new Random(DateTime.Now.Millisecond);
            tanks = new List<Tank>();
            for (int i = 0; i < tanksCount; i++) {
                int x, y;
                bool flag = false;
                
                do {
                    //позиция на поле
                    if(blue)
                        x = rand.Next(15,30);
                    else {
                        x = rand.Next(0, 15); 
                    }
                    y = rand.Next(0,30);              
                    foreach (var tank in tanks) {
                       if (tank.X == x && tank.Y == y)
                           flag = true ;
                    }
                } while (flag);
                     
                //ориентация
                int rotate = rand.Next(0, 3);
                Tank t = new Tank() { Flag = true, X = x, Y = y, Orient = (Tank.Orientation)rotate };
                tanks.Add(t);          
            }      
        }
        
        //инициализация поля
        public void InitField() {
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
                tnBlue[0] = new PictureBox(){Image = Image.FromFile("tn_blue.jpg")};
                tnBlue[1] = new PictureBox() { Image = Image.FromFile("tn_blue.jpg") };
                tnBlue[1].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                tnBlue[2] = new PictureBox() { Image = Image.FromFile("tn_blue.jpg") };
                tnBlue[2].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                tnBlue[3] = new PictureBox() { Image = Image.FromFile("tn_blue.jpg") };
                tnBlue[3].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            //ориентации красных танков
            tnRed = new PictureBox[4];
            for (int i = 0; i < 4; i++) {
                tnRed[0] = new PictureBox() { Image = Image.FromFile("tn_red.jpg") };
                tnRed[1] = new PictureBox() { Image = Image.FromFile("tn_red.jpg") };
                tnRed[1].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                tnRed[2] = new PictureBox() { Image = Image.FromFile("tn_red.jpg") };
                tnRed[2].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                tnRed[3] = new PictureBox() { Image = Image.FromFile("tn_red.jpg") };
                tnRed[3].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

        }

        //заполнение поля танками
        private void UpdateField() {
            //заполенение поля танками
            for (int i = 0; i < dgvGameField.ColumnCount; i++)
                for (int j = 0; j < dgvGameField.RowCount; j++)
                    dgvGameField.Rows[i].Cells[j].Value = Image.FromFile("white.jpg");
           
            foreach (var tank in tanks1) {
                dgvGameField.Rows[tank.X].Cells[tank.Y].Value = tnRed[(int)tank.Orient].Image;
            }
            foreach (var tank in tanks2) {
                dgvGameField.Rows[tank.X].Cells[tank.Y].Value = tnBlue[(int)tank.Orient].Image;
            }                      
        }

        //поражение танка противника в области видимости
        private void Attack(List<Tank> tanks1, List<Tank> tanks2) {
            foreach (var tank1 in tanks1) {
                foreach (var tank2 in tanks2.ToList()) {
                    switch (tank1.Orient) {
                        case Tank.Orientation.Direct:
                            if (tank1.Y == tank2.Y)
                                if (Math.Abs(tank1.X - tank2.X) <= tankVisible && tank1.X - tank2.X > 0)
                                    tanks2.Remove(tank2);
                           break;

                        case Tank.Orientation.Right:
                            if (tank1.X == tank2.X)
                                if (Math.Abs(tank1.Y - tank2.Y) <= tankVisible && tank1.Y - tank2.Y < 0)
                                    tanks2.Remove(tank2);
                            break;
                        case Tank.Orientation.Back:
                            if (tank1.Y == tank2.Y)
                                if (Math.Abs(tank1.X - tank2.X) <= tankVisible && tank1.X - tank2.X < 0)
                                    tanks2.Remove(tank2);
                            break;
                        case Tank.Orientation.Left:
                            if (tank1.X == tank2.X)
                                if (Math.Abs(tank1.Y - tank2.Y) <= tankVisible && tank1.Y - tank2.Y > 0)
                                    tanks2.Remove(tank2);
                            break;
                    }
                }
            }
        }

        //перемещение и поворот танка
        private void MoveRotateTank(List<Tank> tank) {
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < tank.Count; i++) {
                int move = rand.Next(-1, 1);
                int rotate =  rand.Next(-5, 5);
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
                                if (tank[i].X != countCell - 1)
                                    tanks1[i].X++;
                                break;
                            case Tank.Orientation.Left:
                                if (tank[i].Y != countCell - 1)
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
                                if (tank[i].X != countCell - 1)
                                    tank[i].X++;
                                break;
                            case Tank.Orientation.Right:
                                if (tank[i].Y != countCell - 1)
                                    tank[i].Y++;
                                break;
                        }
                        break;
                }
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e) {
            Attack(tanks1, tanks2);
            UpdateField();

        }

        private void button1_Click(object sender, EventArgs e) {
            MoveRotateTank(tanks1);
            MoveRotateTank(tanks2);
            UpdateField();
        }


    


    }
}
