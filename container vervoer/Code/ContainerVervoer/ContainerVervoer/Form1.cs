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
        public Form1() {
            InitializeComponent();
            
        }

        private void BtnStart_Click(object sender, EventArgs e) {
            LbResult.Items.Clear();
            int target = Convert.ToInt32(TbTarget.Text);
            LblTarget.Text = target.ToString();
            Application.DoEvents();
            List<string> numbersInString = TbNumbers.Text.Split(';').ToList();
            List<int> numbers = new List<int>();
            foreach (string number in numbersInString)
                numbers.Add(Convert.ToInt32(number));
           IBruteForce bruteForce = new BruteForceGenerations();
           List<int> result = bruteForce.GetNumbersThatGiveSum(numbers, target);
            foreach (int number in result) {
                LbResult.Items.Add(numbers[number]);
            }
            LblResultSum.Text = Generation.CalculateSumBySequence(result, numbers).ToString();
        }
    }
}
