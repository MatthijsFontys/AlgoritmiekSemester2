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
        private int layer;
        private Ship ship;
        public Form1() {
            InitializeComponent();
            layer = 1;
            CbContainerType.Items.Add(ContainerType.regular);
            CbContainerType.Items.Add(ContainerType.cooled);
            CbContainerType.Items.Add(ContainerType.valuable);
            CbContainerType.SelectedIndex = 0;
            LblLayerCount.Text = "Layer: " + layer;
            //PnlResult.Size = this.ClientSize;
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
            CreateSquares(PnlResult, layer);
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

        private void CreateSquares(Panel panel, int layer = 1) {
            foreach (Side side in ship.Sides) {
                int longestSide = (ship.Width > ship.Length) ? ship.Width : ship.Length;
                int sideLength = PnlResult.Width / longestSide - 5;
                for (int y = side.Length; y >= 1; y--) {
                    for (int x = side.StartX; x < side.StartX + side.Width; x++) {
                        Staple staple = side.GetStapleFromCoordinates(x, y);
                        sideLength = sideLength > 100 ? 100 : sideLength;
                        Button tempBtn = new Button();
                        tempBtn.BackColor = GetBoxColor(staple, layer);
                        tempBtn.Left = (x /*- side.StartX*/) * (sideLength + 6);
                        tempBtn.Top = (side.Length - y) * (sideLength + 6);
                        tempBtn.Width = sideLength;
                        tempBtn.Height = sideLength;
                        tempBtn.TabStop = false;
                        tempBtn.FlatStyle = FlatStyle.Flat;
                        tempBtn.FlatAppearance.BorderSize = 0;
                        tempBtn.Text = GetText(staple);
                        int fontSize = (Convert.ToInt32(sideLength * 0.3) < 5) ? 5 : Convert.ToInt32(sideLength * 0.3);
                        tempBtn.Font = new Font("Arial", fontSize, FontStyle.Bold);
                        panel.Controls.Add(tempBtn);
                    }

                  /*  if (side.Name == SideName.Left) {
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

                    }*/
                }

            }
        }

        private void SetControlPositions() {
            PnlResult.AutoSize = true;
            //PnlResult.Height = PnlResult.Parent.ClientSize.Height - 100;
            PnlResult.Left = PnlResult.ClientSize.Width / 2 - PnlResult.Width / 2;
            PnlInfo.Top = PnlInfo.Parent.Height - PnlInfo.Height;
            PnlInfo.Left = PnlResult.ClientSize.Width / 2 - PnlInfo.Width / 2;
        }

        /*  private Color GetBoxColor(Staple staple) {
              if (staple.ReservationStates.Contains(ReservationState.Cooled) && staple.ReservationStates.Contains(ReservationState.Valueable))
                  return Color.Orange;
              if (staple.ReservationStates.Contains(ReservationState.Cooled))
                  return Color.CornflowerBlue;
              if (staple.ReservationStates.Contains(ReservationState.Valueable))
                  return Color.LightGoldenrodYellow;
              else
                  return Color.Silver;
          } */

        private Color GetBoxColor(Staple staple, int layer = 1) {
            IShipContainer container = staple.Containers.FirstOrDefault(c => c.Z == layer);
            if (container is ValuableContainer)
                return Color.LightGoldenrodYellow;
            if (container is CooledContainer)
                return Color.CornflowerBlue;
            if (container is RegularContainer)
                return Color.Silver;
            else
                return Color.SandyBrown;
        }

        private string GetText(Staple staple) {
            if (staple.Containers.FirstOrDefault(c => c.Z == layer) != null)
                return Math.Floor(staple.Containers.FirstOrDefault(c => c.Z == layer).Weight).ToString();
            else
                return "";
        }

        private void BtnGoToResult_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 1;
        }

        private void Form1_Resize(object sender, EventArgs e) {
            tabControl1.Width = this.ClientSize.Width;
            SetControlPositions();
        }

        private void PnlResult_Paint(object sender, PaintEventArgs e) {
            //Graphics g = e.Graphics;
            //Pen pen = new Pen(Color.Red, 5);
            //Panel currentSender = sender as Panel;
            //float middle = currentSender.ClientSize.Width / 2;
            //g.DrawLine(pen, middle, 0, middle, currentSender.Height);
        }

        private void BtnLayerDown_Click(object sender, EventArgs e) {
            if (layer > 1) {
                PnlResult.Controls.Clear();
                layer--;
                CreateSquares(PnlResult, layer);
                LblLayerCount.Text = "Layer: " + layer;
            }
        }

        private void BtnLayerUp_Click(object sender, EventArgs e) {
            PnlResult.Controls.Clear();
            layer++;
            CreateSquares(PnlResult, layer);
            LblLayerCount.Text = "Layer: " + layer;
        }
    }
}
