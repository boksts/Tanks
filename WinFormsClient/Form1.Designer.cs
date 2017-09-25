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
            this.btnStartGame = new System.Windows.Forms.Button();
            this.dgvGameField = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameField)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbP2Defense);
            this.groupBox2.Controls.Add(this.rbP2Attack);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbPlayer2Name);
            this.groupBox2.Location = new System.Drawing.Point(474, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 111);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Игрок 2";
            // 
            // rbP2Defense
            // 
            this.rbP2Defense.AutoSize = true;
            this.rbP2Defense.Checked = true;
            this.rbP2Defense.Location = new System.Drawing.Point(96, 74);
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
            this.rbP2Attack.Location = new System.Drawing.Point(11, 74);
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
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbP1Defense);
            this.groupBox1.Controls.Add(this.rbP1Attack);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPlayer1Name);
            this.groupBox1.Location = new System.Drawing.Point(474, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 111);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Игрок 1";
            // 
            // rbP1Defense
            // 
            this.rbP1Defense.AutoSize = true;
            this.rbP1Defense.Checked = true;
            this.rbP1Defense.Location = new System.Drawing.Point(96, 74);
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
            this.rbP1Attack.Location = new System.Drawing.Point(11, 74);
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
            // 
            // btnStartGame
            // 
            this.btnStartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartGame.Location = new System.Drawing.Point(499, 256);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(159, 41);
            this.btnStartGame.TabIndex = 12;
            this.btnStartGame.Text = "Сделать ход";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(499, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 41);
            this.button1.TabIndex = 14;
            this.button1.Text = "Переместить танки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvGameField);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Танковый бой";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameField)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dgvGameField;
    }
}

