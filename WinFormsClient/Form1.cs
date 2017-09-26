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

namespace WinFormsClient {
    public partial class Form1 : Form {
  
        public Form1() {
            InitializeComponent();
            this.Width = countCell * (sizeCell + 1) + 250;
            this.Height = countCell * (sizeCell + 1) + 50;
            InitTanks(ref tanks1, color:Color.Blue);
            InitTanks(ref tanks2, color:Color.Red);
            InitField();
            UpdateField();
        }

        

        private void btnStartGame_Click(object sender, EventArgs e) {
            //Tank.Attack(tanks1, tanks2);
         /*   if (rbP1Defense.Checked)
                Strategy(tanks2, tanks1);
            else {
                Strategy(tanks2, tanks1, attack:true);
            }*/
            if (rbP2Defense.Checked)
                Strategy(tanks1, tanks2);
            else {
                Strategy(tanks1, tanks2, attack: true);
            }

            UpdateField();

        }

        private void button1_Click(object sender, EventArgs e) {
           // Tank.MoveRotateTank(tanks1);
           // Tank.MoveRotateTank(tanks2);
            UpdateField();
        }


    }
}