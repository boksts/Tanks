namespace WinFormsClient {
    partial class Form1 {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbP2Defense = new System.Windows.Forms.RadioButton();
            this.rbP2Attack = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPlayer2Name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbP1Defense = new System.Windows.Forms.RadioButton();
            this.rbP1Attack = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPlayer1Name = new System.Windows.Forms.TextBox();
            this.btnStrokeCount = new System.Windows.Forms.Button();
            this.dgvGameField = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGameStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudTankVisible = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTanksCount = new System.Windows.Forms.NumericUpDown();
            this.lblStrokeCount = new System.Windows.Forms.Label();
            this.btnGameJournal = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameField)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTankVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTanksCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbP2Defense);
            this.groupBox2.Controls.Add(this.rbP2Attack);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbPlayer2Name);
            this.groupBox2.Location = new System.Drawing.Point(493, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 95);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Игрок 2 (красные)";
            // 
            // rbP2Defense
            // 
            this.rbP2Defense.AutoSize = true;
            this.rbP2Defense.Checked = true;
            this.rbP2Defense.Location = new System.Drawing.Point(96, 66);
            this.rbP2Defense.Name = "rbP2Defense";
            this.rbP2Defense.Size = new System.Drawing.Size(88, 21);
            this.rbP2Defense.TabIndex = 8;
            this.rbP2Defense.TabStop = true;
            this.rbP2Defense.Text = "Оборона";
            this.rbP2Defense.UseVisualStyleBackColor = true;
            // 
            // rbP2Attack
            // 
            this.rbP2Attack.AutoSize = true;
            this.rbP2Attack.Location = new System.Drawing.Point(11, 66);
            this.rbP2Attack.Name = "rbP2Attack";
            this.rbP2Attack.Size = new System.Drawing.Size(68, 21);
            this.rbP2Attack.TabIndex = 7;
            this.rbP2Attack.Text = "Атака";
            this.rbP2Attack.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Имя";
            // 
            // tbPlayer2Name
            // 
            this.tbPlayer2Name.Location = new System.Drawing.Point(47, 34);
            this.tbPlayer2Name.Name = "tbPlayer2Name";
            this.tbPlayer2Name.Size = new System.Drawing.Size(153, 22);
            this.tbPlayer2Name.TabIndex = 5;
            this.tbPlayer2Name.Text = "Петя";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbP1Defense);
            this.groupBox1.Controls.Add(this.rbP1Attack);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPlayer1Name);
            this.groupBox1.Location = new System.Drawing.Point(493, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 93);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Игрок 1 (синие)";
            // 
            // rbP1Defense
            // 
            this.rbP1Defense.AutoSize = true;
            this.rbP1Defense.Checked = true;
            this.rbP1Defense.Location = new System.Drawing.Point(96, 64);
            this.rbP1Defense.Name = "rbP1Defense";
            this.rbP1Defense.Size = new System.Drawing.Size(88, 21);
            this.rbP1Defense.TabIndex = 8;
            this.rbP1Defense.TabStop = true;
            this.rbP1Defense.Text = "Оборона";
            this.rbP1Defense.UseVisualStyleBackColor = true;
            // 
            // rbP1Attack
            // 
            this.rbP1Attack.AutoSize = true;
            this.rbP1Attack.Location = new System.Drawing.Point(11, 64);
            this.rbP1Attack.Name = "rbP1Attack";
            this.rbP1Attack.Size = new System.Drawing.Size(68, 21);
            this.rbP1Attack.TabIndex = 7;
            this.rbP1Attack.Text = "Атака";
            this.rbP1Attack.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Имя";
            // 
            // tbPlayer1Name
            // 
            this.tbPlayer1Name.Location = new System.Drawing.Point(47, 34);
            this.tbPlayer1Name.Name = "tbPlayer1Name";
            this.tbPlayer1Name.Size = new System.Drawing.Size(153, 22);
            this.tbPlayer1Name.TabIndex = 5;
            this.tbPlayer1Name.Text = "Вася";
            // 
            // btnStrokeCount
            // 
            this.btnStrokeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStrokeCount.Enabled = false;
            this.btnStrokeCount.Location = new System.Drawing.Point(518, 390);
            this.btnStrokeCount.Name = "btnStrokeCount";
            this.btnStrokeCount.Size = new System.Drawing.Size(159, 41);
            this.btnStrokeCount.TabIndex = 12;
            this.btnStrokeCount.Text = "Сделать ход";
            this.btnStrokeCount.UseVisualStyleBackColor = true;
            this.btnStrokeCount.Click += new System.EventHandler(this.btnStrokeCount_Click);
            // 
            // dgvGameField
            // 
            this.dgvGameField.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGameField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGameField.ColumnHeadersVisible = false;
            this.dgvGameField.Enabled = false;
            this.dgvGameField.Location = new System.Drawing.Point(12, 12);
            this.dgvGameField.MultiSelect = false;
            this.dgvGameField.Name = "dgvGameField";
            this.dgvGameField.ReadOnly = true;
            this.dgvGameField.RowHeadersVisible = false;
            this.dgvGameField.RowTemplate.Height = 24;
            this.dgvGameField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvGameField.Size = new System.Drawing.Size(274, 222);
            this.dgvGameField.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnGameStart);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.nudTankVisible);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nudTanksCount);
            this.groupBox3.Location = new System.Drawing.Point(493, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 137);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Характеристики танков";
            // 
            // btnGameStart
            // 
            this.btnGameStart.Location = new System.Drawing.Point(31, 92);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(147, 39);
            this.btnGameStart.TabIndex = 4;
            this.btnGameStart.Text = "Начать игру";
            this.btnGameStart.UseVisualStyleBackColor = true;
            this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Область видимости";
            // 
            // nudTankVisible
            // 
            this.nudTankVisible.Location = new System.Drawing.Point(151, 61);
            this.nudTankVisible.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTankVisible.Name = "nudTankVisible";
            this.nudTankVisible.Size = new System.Drawing.Size(48, 22);
            this.nudTankVisible.TabIndex = 2;
            this.nudTankVisible.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество танков";
            // 
            // nudTanksCount
            // 
            this.nudTanksCount.Location = new System.Drawing.Point(151, 32);
            this.nudTanksCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTanksCount.Name = "nudTanksCount";
            this.nudTanksCount.Size = new System.Drawing.Size(48, 22);
            this.nudTanksCount.TabIndex = 0;
            this.nudTanksCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblStrokeCount
            // 
            this.lblStrokeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStrokeCount.AutoSize = true;
            this.lblStrokeCount.Location = new System.Drawing.Point(493, 352);
            this.lblStrokeCount.Name = "lblStrokeCount";
            this.lblStrokeCount.Size = new System.Drawing.Size(145, 17);
            this.lblStrokeCount.TabIndex = 15;
            this.lblStrokeCount.Text = "Всего сделано ходов";
            // 
            // btnGameJournal
            // 
            this.btnGameJournal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGameJournal.Enabled = false;
            this.btnGameJournal.Location = new System.Drawing.Point(520, 454);
            this.btnGameJournal.Name = "btnGameJournal";
            this.btnGameJournal.Size = new System.Drawing.Size(156, 42);
            this.btnGameJournal.TabIndex = 16;
            this.btnGameJournal.Text = "Открыть журнал игры";
            this.btnGameJournal.UseVisualStyleBackColor = true;
            this.btnGameJournal.Click += new System.EventHandler(this.btnbtnGameJournal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 521);
            this.Controls.Add(this.btnGameJournal);
            this.Controls.Add(this.lblStrokeCount);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvGameField);
            this.Controls.Add(this.btnStrokeCount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Танковый бой";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameField)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTankVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTanksCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbP2Defense;
        private System.Windows.Forms.RadioButton rbP2Attack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPlayer2Name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbP1Defense;
        private System.Windows.Forms.RadioButton rbP1Attack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPlayer1Name;
        private System.Windows.Forms.Button btnStrokeCount;
        private System.Windows.Forms.DataGridView dgvGameField;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudTanksCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudTankVisible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStrokeCount;
        private System.Windows.Forms.Button btnGameStart;
        private System.Windows.Forms.Button btnGameJournal;
    }
}

