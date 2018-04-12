using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapecity_Code
{
    class DirectInsert : ISort
    {
        List<int> initArray=new List<int>();
        Queue<int []> arrayState=new Queue<int []>();

        public Queue<int []> arrayNow
        {
            get
            {
                return arrayState;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="array"></param>
        public DirectInsert(List<int> array)
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
        /// 插入排序算法
        /// </summary>
        /// <param name="array"></param>
        public void Sort()
        {
            for (int i = 1; i < initArray.Count(); i++)
            {

                //拓展时外层每一趟排序完可以把当前数组元素进栈;
                int iValue = initArray[i];//暂存i的值;
                for (int j = i - 1; j >= 0; j--)
                {
                    bool needRep = false;
                    if (initArray[j] > iValue)
                    {
                        initArray[j + 1] = initArray[j];
                        needRep = true;
                    }
                    if (needRep == true)
                    {
                        initArray[j] = iValue;
                    }
                }
                arrayState.Enqueue(initArray.ToArray());
            }
        }
    }
}
