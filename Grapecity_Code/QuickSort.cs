using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapecity_Code
{
    class QuickSort : ISort
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
        public QuickSort(List<int> array)
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
        /// 快排非递归算法
        /// </summary>
        /// <param name="array"></param>
        static void Sort(int[] array, int low, int high)
        {
            Stack<int> stk = new Stack<int>();
            if (low < high)
            {
                stk.Push(high);
                stk.Push(low);
                while (stk.Count != 0)
                {
                    int l = stk.Pop();
                    int r = stk.Pop();
                    int index = Partition(array, l, r);
                    if (l < index - 1)
                    {
                        stk.Push(index - 1);
                        stk.Push(l);
                    }
                    if (r > index + 1)
                    {
                        stk.Push(r);
                        stk.Push(index + 1);
                    }
                }
            }
        }
        /// <summary>
        /// 快排一次分割算法  
        /// </summary>
        /// <param name="A"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        static int Partition(int[] A, int low, int high)
        {
            int pivot = A[low];
            while (low < high)
            {
                while (low < high && A[high] >= pivot)
                    high--;
                A[low] = A[high];
                while (low < high && A[low] <= pivot)
                    low++;
                A[high] = A[low];
            }
            A[low] = pivot;   //high==low
            return low;
        }
        public void Sort()
        {
            throw new NotImplementedException();
        }
    }
}
