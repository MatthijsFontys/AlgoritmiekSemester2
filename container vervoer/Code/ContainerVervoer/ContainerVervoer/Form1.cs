﻿using System;
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
        private int highestZ;
        private Ship ship;
        public Form1() {
            InitializeComponent();
            layer = 1;
            highestZ = 1;
            CbContainerType.Items.Add(ContainerType.regular);
            CbContainerType.Items.Add(ContainerType.cooled);
            CbContainerType.Items.Add(ContainerType.valuable);
            CbContainerType.SelectedIndex = 0;
            LblLayerCount.Text = "Layer: " + layer;
            SetControlPositions();
        }

        private void BtnAddContainer_Click(object sender, EventArgs e) {
            double weight = (double)NumContainerWeight.Value;
            for (int i = 0; i < NumContainerAmount.Value; i++) {
                if ((ContainerType)CbContainerType.SelectedItem == ContainerType.cooled)
                    LbStartContainers.Items.Add(new CooledContainer((int)NumShipLength.Value, weight));
                else if ((ContainerType)CbContainerType.SelectedItem == ContainerType.regular)
                    LbStartContainers.Items.Add(new RegularContainer(weight));
                else
                    LbStartContainers.Items.Add(new ValuableContainer(weight));
            }

        }

        private void BtnDivideContainers_Click(object sender, EventArgs e) {
            Reset();
            ILoadStrategy loader = new LoadStrategy();
            ship = new Ship((int)NumShipWidth.Value, (int)NumShipLength.Value);
            loader.DivideContainers(GetContainersFromLb(), ship);
            CreateSquares(PnlResult, layer);
        }

        private List<IShipContainer> GetContainersFromLb() {
            List<IShipContainer> toReturn = new List<IShipContainer>();
            foreach (var item in LbStartContainers.Items)
                toReturn.Add(item as IShipContainer);
            return toReturn;
        }

        private void CreateSquares(Panel panel, int layer = 1) {
            foreach (Side side in ship.Sides) {
                int longestSide = (ship.Width > ship.Length) ? ship.Width : ship.Length;
                int sideLength = 600 / longestSide - 5;
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
                }
                int highestZInSide = side.Staples.Max(s => s.Containers.Count);
                if (highestZInSide > highestZ)
                    highestZ = highestZInSide;
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
            PnlResult.Left = 0;
            PnlResult.Width = PnlResult.Parent.ClientSize.Width;
            PnlResult.Top = 0;
            PnlResult.Height = Convert.ToInt32(PnlResult.Parent.Height * .9);

            PnlInfo.Left = PnlInfo.Parent.Width / 2 - PnlInfo.Width / 2;
            PnlInfo.Top = PnlResult.ClientSize.Height - 100;
            PnlInfo.Height = Convert.ToInt32(PnlResult.Parent.Height * .1);


        }

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

        private void Form1_Resize(object sender, EventArgs e) {
            SetControlPositions();
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
            if (layer < highestZ) {
                PnlResult.Controls.Clear();
                layer++;
                CreateSquares(PnlResult, layer);
                LblLayerCount.Text = "Layer: " + layer;
            }
        }

        private void Reset() {
            PnlResult.Controls.Clear();
            layer = 1;
            LblLayerCount.Text = "Layer: " + layer;
        }

        private void BtnClear_Click(object sender, EventArgs e) {
            LbStartContainers.Items.Clear();
        }

        private void BtnRemoveContainer_Click(object sender, EventArgs e) {
            try {
                int selectedIndex = LbStartContainers.SelectedIndex;
                LbStartContainers.Items.RemoveAt(selectedIndex);
            }
            catch (Exception) {
                MessageBox.Show("Select an item before removing");
            }
        }
    }
}
