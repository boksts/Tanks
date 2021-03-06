﻿using System;
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
using WinFormsClient.RemoteService;

namespace WinFormsClient {
    public partial class Form1 : Form {
        private int cellCount = 30;
        private int cellSize = 20;
        private int tankVisible;
        private int tanksCount;
        private int strokeCount = 0;

        private PictureBox[] tnBlue;
        private PictureBox[] tnRed;
        private FieldTanksClient fieldTanksClient;
        private int[] field;
        List<string> players;
  
        private dynamic tanks;
    
        //основная форма
        public Form1() {
            InitializeComponent();
            this.Width = cellCount * (cellSize + 1) + 250;
            this.Height = cellCount * (cellSize + 1) + 50;
            InitField();
            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++) 
                        dgvGameField.Rows[i].Cells[j].Value = Image.FromFile(@"Pictures\white.jpg");

            fieldTanksClient = new FieldTanksClient();
            //очистить журнал игры
            fieldTanksClient.SelectTankDetails(true);
        }

        //инициализация основных параметров
        private void Init() {          
            tanksCount = int.Parse(nudTanksCount.Text);
            tankVisible = int.Parse(nudTankVisible.Text);
            //список игроков
            players = new List<string>();
            players.Add(tbPlayer1Name.Text);
            players.Add(tbPlayer2Name.Text);
           
            //инициализация танков на поле         
            tanks = fieldTanksClient.InitTanks(tanksCount, tankVisible);

            UpdateField();
        }

        //инициализация отрисовки поля
        private void InitField() {

            //размеры поля (грида)
            dgvGameField.Width = dgvGameField.Height = cellCount * cellSize + 3;

            //для возможности добавление картинок в ячейки
            for (int i = 0; i < cellCount; i++) {
                dgvGameField.Columns.Add(new DataGridViewImageColumn());
                if (i != cellCount - 1)
                    dgvGameField.Rows.Add();
            }

            //размер ячеек
            for (int i = 0; i < dgvGameField.ColumnCount; i++) {
                dgvGameField.Columns[i].Width = dgvGameField.Rows[i].Height = cellSize;
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

        //обновление отрисовки поля
        private void UpdateField() {
             field = fieldTanksClient.FillField(tanks);

            for (int i = 0; i < cellCount; i++)
                for (int j = 0; j < cellCount; j++) {
                    if (field[i*cellCount+j] == 0) {
                         dgvGameField.Rows[i].Cells[j].Value = Image.FromFile(@"Pictures\white.jpg");
                    }     
                    else {
                        //синие танки
                        if (field[i * cellCount + j] > 0) {
                            dgvGameField.Rows[i].Cells[j].Value = tnBlue[Math.Abs(field[i * cellCount + j]) - 1].Image;
                        }
                        //красные танки
                        else {
                            dgvGameField.Rows[i].Cells[j].Value = tnRed[Math.Abs(field[i * cellCount + j]) - 1].Image;
                        }
                    }
                }
        }

        //сделать ход
        private void btnStrokeCount_Click(object sender, EventArgs e) {
            if (rbP1Defense.Checked)
                tanks = fieldTanksClient.ApplyStrategy(tanks, FieldTanksTankColor.Blue, players[0], attack: false);
            else {
                tanks = fieldTanksClient.ApplyStrategy(tanks, FieldTanksTankColor.Blue, players[0], attack: true);
            }
            UpdateField();
            if (rbP2Defense.Checked)
                tanks = fieldTanksClient.ApplyStrategy(tanks, FieldTanksTankColor.Red, players[1], attack: false);
            else {
                tanks = fieldTanksClient.ApplyStrategy(tanks, FieldTanksTankColor.Red, players[1], attack: true);
            }
            UpdateField();

            strokeCount++;
            lblStrokeCount.Text = "Всего сделано ходов " + strokeCount;
            btnGameJournal.Enabled = true;
        }

        private void btnGameStart_Click(object sender, EventArgs e) {
            Init();
            nudTankVisible.Enabled = nudTanksCount.Enabled = false;
            btnGameStart.Enabled = false;
            btnStrokeCount.Enabled = true;
        }

        //отобразить журнал
        private void btnbtnGameJournal_Click(object sender, EventArgs e) {
            GameJournal gameJournalForm = new GameJournal(); ;
            gameJournalForm.Init(fieldTanksClient);
            gameJournalForm.Show();
        }


    }
}