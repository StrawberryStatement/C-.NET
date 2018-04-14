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
        List<int> locArray = new List<int>();        
        Queue<int[]> arrayState = new Queue<int[]>();
        int swapCount = 0;
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
        /// 获取交换次数
        /// </summary>
        public int getSwapCount
        {
            get
            {
                return swapCount;
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
                    initArray.ForEach(data => locArray.Add(data));
                    locArray.Add(i);   //队列中加入需要交换的元素位置；
                    locArray.Add(j);
                    if (initArray[j] < initArray[i])
                    {
                        //交换前的元素进队
                        arrayState.Enqueue(locArray.ToArray());//List 引用不能直传
                        locArray.Clear();
                        //Swap
                        int temp = initArray[i];
                        initArray[i] = initArray[j];
                        initArray[j] = temp;
                        //交换后的元素进队
                        initArray.ForEach(data => locArray.Add(data));
                        locArray.Add(i);   
                        locArray.Add(j);
                        swapCount++;
                        Change = true;
                    }
                    arrayState.Enqueue(locArray.ToArray());//List 引用不能直传
                    locArray.Clear();
                }               
                if (Change == false)
                {
                    break;
                }
            }
        }
    }
}
