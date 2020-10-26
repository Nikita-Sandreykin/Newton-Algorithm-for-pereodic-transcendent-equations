using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace NewtonAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double lx = 2, h = 1; int count;
        Function func;
        NewtonAlg alg;
        private void Button2_Click(object sender, EventArgs e)
        {
            bool check1 = double.TryParse(textBox1.Text, out lx);
            bool check2 = double.TryParse(textBox2.Text, out h);
            bool check3 = int.TryParse(textBox3.Text, out count);
            if (check1 && check2 && check3)
            {
                func = new Function(h, lx);
                alg = new NewtonAlg(func.f, func.df, 0.00000001, count);
                alg.setStep(func.step());
                alg.calculateAll();
                String temp = "";
                for (int i = 0; i < alg.ans.Count(); i++)
                {
                    temp += alg.ans[i].ToString() + "   " + i.ToString() + "\n";
                }
                richTextBox1.Text = temp;
                button1.Visible = true;
            }
            else
            {
                MessageBox.Show("Неверные значения параметров", "Ошибка", MessageBoxButtons.OK);
            }
        }
        private double L(double x)
        {
            return Math.Cos(x * lx) / Math.Sin(x * lx);
        }
        private double R(double x)
        {
            return (x / h - h / x) / 2;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            GraphPane pane = graph.zedGraphControl1.GraphPane;
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList list = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (double x = 0; x <= alg.ans[alg.ans.Count-1]; x += 0.0001)
            {
                // добавим в список точку
                list.Add(x, L(x));
                list2.Add(x, R(x));
            }
            LineItem myCurve = pane.AddCurve("Left part", list, Color.Blue, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("Right part", list2, Color.Red, SymbolType.None);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;
            //graph.zedGraphControl1.AxisChange();
            graph.zedGraphControl1.Invalidate();
            graph.Show();
        }
    }
}
