using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace ContainerVervoer {
    public partial class Form1 : Form {
        private Ship ship;
        public Form1() {
            InitializeComponent();
            CbContainerType.Items.Add(ContainerType.regular);
            CbContainerType.Items.Add(ContainerType.cooled);
            CbContainerType.Items.Add(ContainerType.valuable);
            CbContainerType.SelectedIndex = 0;
            SetTabControl();
        }

        private void BtnAddContainer_Click(object sender, EventArgs e) {
            double weight = (double)NumContainerWeight.Value;
            if((ContainerType)CbContainerType.SelectedItem == ContainerType.cooled)
                LbStartContainers.Items.Add(new CooledContainer((int)NumShipLength.Value, weight));
            else if((ContainerType)CbContainerType.SelectedItem == ContainerType.regular)
                LbStartContainers.Items.Add(new RegularContainer(weight));
            else
                LbStartContainers.Items.Add(new ValuableContainer(weight));

        }

        private void BtnDivideContainers_Click(object sender, EventArgs e) {
            ILoadStrategy loader = new LoadStrategy();
            ship = new Ship((int)NumShipWidth.Value, (int)NumShipLength.Value);
            loader.DivideContainers(GetContainersFromLb(), ship);
            CreateSquares(PnlResult);
            //CreateSquares(ship.GetSide(SideName.Right), PnlResultRight);
        }

        private List<IShipContainer> GetContainersFromLb() {
            List<IShipContainer> toReturn = new List<IShipContainer>();
            foreach (var item in LbStartContainers.Items)
                toReturn.Add(item as IShipContainer);
            return toReturn;
        }

        private void SetTabControl() {
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Size = this.ClientSize;
            tabControl1.Location = new Point(0, -1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void CreateSquares(Panel panel, int layer = 0) {
            foreach (Side side in ship.Sides) {
                int sideLength = PnlResult.Width / ship.Width - 5;
                for (int y = side.Length; y >= 1; y--) {
                    for (int x = side.StartX; x < side.Width + side.StartX; x++) {
                        sideLength = sideLength > 100 ? 100 : sideLength;
                        Button tempBtn = new Button();
                        tempBtn.BackColor = GetBoxColor(side.GetStapleWithCoordinates(x, y));
                        tempBtn.Left = (x /*- side.StartX*/) * (sideLength + 6);
                        tempBtn.Top = (side.Length - y) * (sideLength + 6);
                        tempBtn.Width = sideLength;
                        tempBtn.Height = sideLength;
                        tempBtn.TabStop = false;
                        tempBtn.FlatStyle = FlatStyle.Flat;
                        tempBtn.FlatAppearance.BorderSize = 0;
                        panel.Controls.Add(tempBtn);
                    }

                    if (side.Name == SideName.Left) {
                        Button tempBtn = new Button();
                        tempBtn.BackColor = Color.Red;
                        tempBtn.Left = (side.Width + 1) * (sideLength + 6) - 6;
                        tempBtn.Top = -10;
                        tempBtn.Width = 5;
                        tempBtn.Height = panel.ClientSize.Height;
                        tempBtn.TabStop = false;
                        tempBtn.FlatStyle = FlatStyle.Flat;
                        tempBtn.FlatAppearance.BorderSize = 0;
                        tempBtn.BringToFront();
                        panel.Controls.Add(tempBtn);

                    }
                }

            }
        }

        private Color GetBoxColor(Staple staple) {
            if (staple.ReservationStates.Contains(ReservationState.Cooled) && staple.ReservationStates.Contains(ReservationState.Valueable))
                return Color.Orange;
            if (staple.ReservationStates.Contains(ReservationState.Cooled))
                return Color.CornflowerBlue;
            if (staple.ReservationStates.Contains(ReservationState.Valueable))
                return Color.LightGoldenrodYellow;
            else
                return Color.Silver;
        }

        private void BtnGoToResult_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 1;
        }

        private void Form1_Resize(object sender, EventArgs e) {
            PnlResult.Size = this.ClientSize;
        }

        private void PnlResult_Paint(object sender, PaintEventArgs e) {
            //Graphics g = e.Graphics;
            //Pen pen = new Pen(Color.Red, 5);
            //Panel currentSender = sender as Panel;
            //float middle = currentSender.ClientSize.Width / 2;
            //g.DrawLine(pen, middle, 0, middle, currentSender.Height);
        }
    }
}
