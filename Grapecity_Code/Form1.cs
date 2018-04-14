using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;

namespace Grapecity_Code
{
    public partial class GrapeCity : Form
    {  
        List<int> arrayToSort = new List<int>();
        Queue<int[]> sortedQueue = new Queue<int[]>();
        List<int []> sortedArray = new List<int []>();
        Series series = new Series();
        static int globalSortSequence = 0;
        List<int> sortedSeries = new List<int>();
        int swapCount;
        public GrapeCity()
        {
            InitializeComponent();
            Init();
        }
        /// <summary>
        /// 初始化软件配置
        /// </summary>
        private void Init()
        {
            GetArray();
        }
        /// <summary>
        /// 排序
        /// </summary>
        private void Sort()
        {
            Bubble sortInstance = new Bubble(arrayToSort.ToList());
            sortInstance.Sort();
            sortedQueue = sortInstance.arrayNow;
            swapCount = sortInstance.getSwapCount;
            while (sortedQueue.Count > 0)
            {
                sortedArray.Add(sortedQueue.Dequeue());
            }
        }
        /// <summary>
        /// 排序结果重绘，sortSequence是第i次
        /// </summary>
        private void ReDrawing(int sortSequence)
        {
            chart1.Series.Clear();
            series.Dispose();
            series = new Series("排序结果");
            series.ChartType = SeriesChartType.Column;

            for (int i = 0; i < sortedArray[sortSequence].Length-2; i++)//应该是-2
            {
                series.Points.Add(sortedArray[sortSequence][i]);//arraylist需要拆装箱检查

            }
            //sortedArray后两位元素储存当前正在比对的两个数值
            if (sortedArray[sortSequence][sortedArray[sortSequence].Length - 2] != 255 && sortedArray[sortSequence][sortedArray[sortSequence].Length - 1] != 255)
            {
                series.Points[sortedArray[sortSequence][sortedArray[sortSequence].Length - 2]].Color = Color.Red;
                series.Points[sortedArray[sortSequence][sortedArray[sortSequence].Length - 1]].Color = Color.Red;
            }
            chart1.Series.Add(series);
        }
        /// <summary>
        /// 由输入获取排序数列
        /// </summary>
        private void GetArray()
        {
            sortedQueue.Clear();
            arrayToSort.Clear();
            sortedArray.Clear();

            for (int i = 0; i < textBox1.Text.Split(',').Length; i++)
            {
                arrayToSort.Add(Int32.Parse(textBox1.Text.Split(',')[i]));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetArray();
            //sortedArray.Add(arrayToSort.ToArray());
            Sort();
            globalSortSequence = 0;
            ReDrawing(globalSortSequence);  
        }
        /// <summary>
        /// 上一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (globalSortSequence > 1&&globalSortSequence<=sortedArray.Count)
            {
                globalSortSequence--;
                ReDrawing(globalSortSequence);
            }
            else
            {
                ReDrawing(0);
                MessageBox.Show("已还原至初始序列", "提示");
            }
        }
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (globalSortSequence >= 0 && globalSortSequence < sortedArray.Count-1)
            {
                globalSortSequence++;
                ReDrawing(globalSortSequence);
            }
            else
            {
                ReDrawing(sortedArray.Count-1);
                MessageBox.Show("排序已完成", "提示");
            }
        }
    }
}
