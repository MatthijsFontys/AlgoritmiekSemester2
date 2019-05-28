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
        private int coolCount;
        private int regularCount;
        private int valuableCount;
        private int layer;
        private int highestZ; 
        private Ship ship;
        public Form1() {
            InitializeComponent();
            layer = 1;
            highestZ = 1;
            coolCount = 0;
            regularCount = 0;
            valuableCount = 0;
            CbContainerType.Items.Add(ContainerType.regular);
            CbContainerType.Items.Add(ContainerType.cooled);
            CbContainerType.Items.Add(ContainerType.valuable);
            CbContainerType.SelectedIndex = 0;
            LblLayerCount.Text = "Layer: " + layer;
            SetControlPositions();
        }

        private void BtnAddContainer_Click(object sender, EventArgs e) {
            double weight = (double)NumContainerWeight.Value;
            int amount = Convert.ToInt32(NumContainerAmount.Value);
            for (int i = 0; i < amount ; i++) {
                if ((ContainerType)CbContainerType.SelectedItem == ContainerType.cooled) {
                    LbStartContainers.Items.Add(new CooledContainer((int)NumShipLength.Value, weight));
                    coolCount ++;
                }
                else if ((ContainerType)CbContainerType.SelectedItem == ContainerType.regular) {
                    LbStartContainers.Items.Add(new RegularContainer(weight));
                    regularCount ++;
                }
                else {
                    LbStartContainers.Items.Add(new ValuableContainer(weight));
                    valuableCount ++;
                }
            }
            SetCountLabels();
        }

        private void BtnDivideContainers_Click(object sender, EventArgs e) {
            Reset();
            SetCounts();
            SetCountLabels();
            ILoadStrategy loader = new LoadStrategy();
            ship = new Ship((int)NumShipWidth.Value, (int)NumShipLength.Value);
            loader.DivideContainers(GetContainersFromListBox(), ship);
            CreateSquares(PnlResult, layer);
            lblWeightDifference.Text = Math.Round(ship.GetWeightDifferenceInPercent(), 2) + " %";
        }

        private List<Logic.IContainer> GetContainersFromListBox() {
            List<Logic.IContainer> toReturn = new List<Logic.IContainer>();
            foreach (var item in LbStartContainers.Items)
                toReturn.Add(item as Logic.IContainer);
            return toReturn;
        }

        private void CreateSquares(Panel panel, int layer = 1) {
            foreach (Side side in ship.Sides) {
                int longestSide = (ship.Width > ship.Length) ? ship.Width : ship.Length;
                int sideLength = 600 / longestSide - 5;
                for (int y = side.Length; y >= 1; y--) {
                    for (int x = side.StartX; x < side.StartX + side.Width; x++) {
                        Stack staple = side.GetStackFromCoordinates(x, y);
                        sideLength = sideLength > 100 ? 100 : sideLength;
                        Button tempBtn = new Button();
                        tempBtn.BackColor = GetBoxColor(staple, layer);
                        tempBtn.Left = x * (sideLength + 6);
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
                }
                int highestZInSide = side.Stacks.Max(s => s.Containers.Count);
                if (highestZInSide > highestZ)
                    highestZ = highestZInSide;
                ToggleButtonsIfNeeded();
            }
        }

        private void SetControlPositions() {
            // Left
            PnlLeft.Left = 0;
            PnlLeft.Width = Convert.ToInt32(this.ClientSize.Width * .4);
            PnlLeft.Height = this.ClientSize.Height;
            PnlLeft.Top = 0;

            // Right
            PnlRight.Left = PnlLeft.Width;
            PnlRight.Width = Convert.ToInt32(this.ClientSize.Width * .6);
            PnlRight.Height = this.ClientSize.Height;
            PnlRight.Top = 0;

            // Right content
            PnlLegend.Left = 0;
            PnlResult.Left = PnlLegend.Width;
            PnlResult.Width = PnlResult.Parent.ClientSize.Width;
            PnlResult.Top = 0;
            PnlResult.Height = Convert.ToInt32(PnlResult.Parent.Height * .9);

            PnlInfo.Left = PnlInfo.Parent.Width / 2 - PnlInfo.Width / 2;
            PnlInfo.Top = PnlResult.ClientSize.Height - 100;
            PnlInfo.Height = Convert.ToInt32(PnlResult.Parent.Height * .1);
        }

        private Color GetBoxColor(Stack staple, int layer = 1) {
            Logic.IContainer container = staple.Containers.FirstOrDefault(c => c.Z == layer);
            if (container is ValuableContainer)
                return Color.LightGoldenrodYellow;
            if (container is CooledContainer)
                return Color.CornflowerBlue;
            if (container is RegularContainer)
                return Color.Silver;
            else
                return Color.SandyBrown;
        }

        private string GetText(Stack staple) {
            if (staple.Containers.FirstOrDefault(c => c.Z == layer) != null)
                return Math.Floor(staple.Containers.FirstOrDefault(c => c.Z == layer).Weight).ToString();
            else
                return "";
        }

        private void Form1_Resize(object sender, EventArgs e) {
            SetControlPositions();
        }

        private void BtnLayerDown_Click(object sender, EventArgs e) {
            if (layer > 1) {
                PnlResult.Controls.Clear();
                layer--;
                ToggleButtonsIfNeeded();
                CreateSquares(PnlResult, layer);
                LblLayerCount.Text = "Layer: " + layer;
            }
        }

        private void BtnLayerUp_Click(object sender, EventArgs e) {
            if (layer < highestZ) {
                PnlResult.Controls.Clear();
                layer++;
                ToggleButtonsIfNeeded();
                CreateSquares(PnlResult, layer);
                LblLayerCount.Text = "Layer: " + layer;
            }
        }

        private void Reset() {
            PnlResult.Controls.Clear();
            layer = 1;
            ResetLabels();
        }

        private void SetCounts() {
            regularCount = 0;
            valuableCount = 0;
            coolCount = 0;
            foreach (var item in LbStartContainers.Items) {
                if (item is RegularContainer)
                    regularCount++;
                if (item is CooledContainer)
                    coolCount++;
                if(item is ValuableContainer)
                    valuableCount++;
            }
            SetCountLabels();
        }

        private void ResetLabels() {
            LblLayerCount.Text = "Layer: " + layer;
            SetCountLabels();
            lblWeightDifference.Text = " 0 %";
        }

        private void BtnClear_Click(object sender, EventArgs e) {
            LbStartContainers.Items.Clear();
            ResetLabels();
            SetCounts();
        }

        private void BtnRemoveContainer_Click(object sender, EventArgs e) {
            var selectedItem = LbStartContainers.SelectedItem;
            if (selectedItem != null)
                LbStartContainers.Items.Remove(selectedItem);
            else
                MessageBox.Show("Select an item before removing");
        }

        private void SetCountLabels() {
            LblCoolCount.Text = coolCount.ToString();
            LblRegularCount.Text = regularCount.ToString();
            LblValuableCount.Text = valuableCount.ToString();
        }

        private void ToggleButtonsIfNeeded() {
            if (layer == 1)
                BtnLayerDown.Enabled = false;
            else
                BtnLayerDown.Enabled = true;
            if (layer == highestZ)
                BtnLayerUp.Enabled = false;
            else
                BtnLayerUp.Enabled = true;

        }
    }
}
