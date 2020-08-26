using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e) {
            lblShow.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e) {
            lblShow.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e) {
            lblShow.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e) {
            lblShow.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e) {
            lblShow.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e) {
            lblShow.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e) {
            lblShow.Text += "6";
        }

        private void bnt7_Click(object sender, EventArgs e) {
            lblShow.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e) {
            lblShow.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e) {
            lblShow.Text += "9";
        }

        private void btnDot_Click(object sender, EventArgs e) {
            lblShow.Text += ".";
        }

        private void btnPlus_Click(object sender, EventArgs e) {
            lblShow.Text += "+";
        }

        private void btnMinus_Click(object sender, EventArgs e) {
            lblShow.Text += "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e) {
            lblShow.Text += "*";
        }

        private void btnDivide_Click(object sender, EventArgs e) {
            lblShow.Text += "/";
        }

        private void btnEqual_Click(object sender, EventArgs e) {
            Calculate calculate = new Calculate();
            lblShow.Text = calculate.GetResult(lblShow.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            lblShow.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e) {
            int length = lblShow.Text.Length;
            if (length == 0) return;
            lblShow.Text = lblShow.Text.Substring(0,length-1);
        }

        private void btnLbracket_Click(object sender, EventArgs e) {
            lblShow.Text += "(";
        }

        private void btnRbracket_Click(object sender, EventArgs e) {
            lblShow.Text += ")";
        }
    }
}
