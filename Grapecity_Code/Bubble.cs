using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapecity_Code
{
    class Bubble : ISort
    {
        List<int> initArray = new List<int>();
        Queue<int[]> arrayState = new Queue<int[]>();
        int sortedSeries;//交换排序中已确定好位置的元素。
        /// <summary>
        /// 获取当前序列值
        /// </summary>
        public Queue<int[]> arrayNow
        {
            get
            {
                return arrayState;
            }
        }
        /// <summary>
        /// 获取已排序位置
        /// </summary>
        public int getSortedSeries
        {
            get
            {
                return sortedSeries;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="array"></param>
        public Bubble(List<int> array)
        {
            initArray = array;
        }
        /// <summary>
        /// 获取数组长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return initArray.Count();
        }
        /// <summary>
        /// 冒泡排序算法
        /// </summary>
        /// <param name="array"></param>
        public void Sort()
        {
            for (int i = 0; i < initArray.Count(); i++)
            {
                bool Change = false;
                for (int j = i + 1; j < initArray.Count(); j++)
                {
                    if (initArray[j] < initArray[i])
                    {
                        //Swap
                        int temp = initArray[i];
                        initArray[i] = initArray[j];
                        initArray[j] = temp;
                        initArray.Add(i);   //队列中加入需要交换的元素位置；
                        initArray.Add(j);
                        arrayState.Enqueue(initArray.ToArray());//List 引用不能直传
                        Change = true;
                    }
                }               
                if (Change == false)
                {
                    break;
                }
                sortedSeries=i;//一次外层排序确定一个最终位置。
            }
        }
    }
}
