using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.RemoteService;

namespace WinFormsClient {
    public partial class GameJournal : Form {
        public GameJournal() {
            InitializeComponent();
        }

        public void Init(FieldTanksClient ftc) {
            dgvGameJournal.DataSource = ftc.SelectTankDetails(false)
                .Select(p => new {
                    p.Player,
                    p.Strategy,
                    p.Color,
                    TankPosition = "x = " + p.X.ToString() + ", y = " + p.Y.ToString(),
                    p.Orient
                })
                .ToList();

            dgvGameJournal.Columns[0].HeaderText = "Имя игрока";
            dgvGameJournal.Columns[1].HeaderText = "Стратегия";
            dgvGameJournal.Columns[2].HeaderText = "Цвет танка";
            dgvGameJournal.Columns[3].HeaderText = "Позиция танка";
            dgvGameJournal.Columns[4].HeaderText = "Ориентация танка";
        }
    }
}
