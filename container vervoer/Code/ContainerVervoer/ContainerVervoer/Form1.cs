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
    }
}
