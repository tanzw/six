using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Well.Data
{
    public class ServiceNum
    {
        public static Dictionary<int, string> GetZodiacArray()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "鼠");
            dic.Add(2, "牛");
            dic.Add(3, "虎");
            dic.Add(4, "兔");
            dic.Add(5, "龙");
            dic.Add(6, "蛇");
            dic.Add(7, "马");
            dic.Add(8, "羊");
            dic.Add(9, "猴");
            dic.Add(10, "鸡");
            dic.Add(11, "狗");
            dic.Add(12, "猪");
            return dic;
        }

        public static string GetNumZodiac(int num)
        {
            return GetZodiacArray()[num];
        }



        public static Dictionary<int, string> GetNumArray()
        {
            Dictionary<int, string> dic = GetZodiacArray();

            Dictionary<int, string> result = new Dictionary<int, string>();

            int currentYear = DateTime.Now.Year;
            int tmp = currentYear - 2008;
            int key = 0;
            if (currentYear < 2008)
            {
                key = tmp % 12 + 12 + 1;


            }
            else
            {
                key = tmp % 12 + 1;
            }

            List<string> orderBy = new List<string>();
            for (int i = key; i > 0; i--)
            {
                orderBy.Add(dic[i]);
            }
            for (int i = 12; i > key; i--)
            {
                orderBy.Add(dic[i]);
            }
            for (int i = 1; i < 50; i++)
            {
                var k = 0;
                if (i % 12 > 0)
                {
                    k = i % 12 - 1;
                }
                else
                {
                    k = 11;
                }
                result.Add(i, orderBy[k]);
            }

            return result;
        }

        public static Dictionary<int, Color> GetColorArray()
        {
            Dictionary<int, Color> dic = new Dictionary<int, Color>();
            var green = Color.LimeGreen;
            var red = Color.Red;
            var blue = Color.Blue;

            dic.Add(1, red);
            dic.Add(2, red);
            dic.Add(3, blue);
            dic.Add(4, blue);
            dic.Add(5, green);
            dic.Add(6, green);
            dic.Add(7, red);
            dic.Add(8, red);
            dic.Add(9, blue);
            dic.Add(10, blue);
            dic.Add(11, green);
            dic.Add(12, red);
            dic.Add(13, red);
            dic.Add(14, blue);
            dic.Add(15, blue);
            dic.Add(16, green);
            dic.Add(17, green);
            dic.Add(18, red);
            dic.Add(19, red);
            dic.Add(20, blue);
            dic.Add(21, green);
            dic.Add(22, green);
            dic.Add(23, red);
            dic.Add(24, red);
            dic.Add(25, blue);
            dic.Add(26, blue);
            dic.Add(27, green);
            dic.Add(28, green);
            dic.Add(29, red);
            dic.Add(30, red);
            dic.Add(31, blue);
            dic.Add(32, green);
            dic.Add(33, green);
            dic.Add(34, red);
            dic.Add(35, red);
            dic.Add(36, blue);
            dic.Add(37, blue);
            dic.Add(38, green);
            dic.Add(39, green);
            dic.Add(40, red);
            dic.Add(41, blue);
            dic.Add(42, blue);
            dic.Add(43, green);
            dic.Add(44, green);
            dic.Add(45, red);
            dic.Add(46, red);
            dic.Add(47, blue);
            dic.Add(48, blue);
            dic.Add(49, green);
            return dic;
        }

        public static Color GetNumColor(int num)
        {
            var dic = GetColorArray();
            if (dic.ContainsKey(num))
            {
                return dic[num];
            }
            else
            {
                return Color.Black;
            }
        }
        public static string GetIssue()
        {
            int Index = 0;
            for (DateTime dt = new DateTime(DateTime.Now.Year, 1, 1); dt <= DateTime.Now.Date; dt = dt.AddDays(1))
            {
                switch (dt.DayOfWeek)
                {
                    //星期四
                    case DayOfWeek.Thursday:
                        Index = Index + 1;
                        break;
                    case DayOfWeek.Saturday:
                        Index = Index + 1;
                        break;
                    case DayOfWeek.Tuesday:
                        Index = Index + 1;
                        break;
                }
            }
            return DateTime.Now.Year + Index.ToString().PadLeft(3, '0');
        }

        /// <summary>
        /// 获取订单号20位
        /// </summary>
        /// <returns></returns>
        public static string GetOrderNo(bool is20 = false)
        {
            Random random = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            var orderId = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next().ToString();
            return is20 ? orderId.Substring(0, 20) : orderId;
        }

        public static List<CodeNum> GetNumsArray()
        {
            Dictionary<int, string> dic = GetZodiacArray();


            List<CodeNum> result = new List<CodeNum>();

            int currentYear = DateTime.Now.Year;
            int tmp = currentYear - 2008;
            int key = 0;
            if (currentYear < 2008)
            {
                key = tmp % 12 + 12 + 1;


            }
            else
            {
                key = tmp % 12 + 1;
            }

            List<string> orderBy = new List<string>();
            for (int i = key; i > 0; i--)
            {
                orderBy.Add(dic[i]);
            }
            for (int i = 12; i > key; i--)
            {
                orderBy.Add(dic[i]);
            }
            for (int i = 1; i < 50; i++)
            {
                var k = 0;
                if (i % 12 > 0)
                {
                    k = i % 12 - 1;
                }
                else
                {
                    k = 11;
                }
                result.Add(new CodeNum() { Key = i, Value = i.ToString().PadLeft(2, '0'), Zodiac = orderBy[k], CodeColor = GetNumColor(i) });
            }

            return result;
        }
    }


    public class Zodiac
    {
        public int Key { get; set; }

        public string Value { get; set; }

        public List<CodeNum> Nums { get; set; }
    }


    public class CodeNum
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public Color CodeColor { get; set; }

        public string Zodiac { get; set; }
    }


    public enum OrderType
    {
        特码 = 1,
        连肖 = 2,
        连码 = 3,
        平特 = 4,
        尾数 = 5,
        波色 = 6,
        大小单双 = 7,
        合肖 = 8,
        全不中 = 9,
        单平 = 10,

    }

    public enum ChildType
    {
        特码 = 11,

        二连肖 = 22,
        三连肖 = 23,
        四连肖 = 24,
        五连肖 = 25,

        二全中 = 32,
        三全中 = 33,
        四全中 = 34,
        三中三 = 35,
        特碰 = 36,
        三中二 = 37,

        平特 = 41,
        尾数 = 51,
        红波 = 601,
        绿波 = 701,
        蓝波 = 801,

        红大 = 611,
        红小 = 612,
        红单 = 613,
        红双 = 614,
        红大单 = 621,
        红小单 = 622,
        红大双 = 623,
        红小双 = 624,

        绿大 = 711,
        绿小 = 712,
        绿单 = 713,
        绿双 = 714,
        绿大单 = 721,
        绿小单 = 722,
        绿大双 = 723,
        绿小双 = 724,

        蓝大 = 811,
        蓝小 = 812,
        蓝单 = 813,
        蓝双 = 814,
        蓝大单 = 821,
        蓝小单 = 822,
        蓝大双 = 823,
        蓝小双 = 824,

        特大 = 911,
        特小 = 912,
        特单 = 913,
        特双 = 914,
        特大单 = 921,
        特小单 = 922,
        特大双 = 923,
        特小双 = 924,

        合大 = 1011,
        合小 = 1012,
        合单 = 1013,
        合双 = 1014,
        合大单 = 1021,
        合小单 = 1022,
        合大双 = 1023,
        合小双 = 1024,

        六肖 = 81,
        五肖 = 82,
        四肖 = 83,
        三肖 = 84,
        二肖 = 85,

        五不中 = 91,
        六不中 = 92,
        七不中 = 93,
        八不中 = 94,
        九不中 = 95,
        十不中 = 96,

        单平 = 101



    }

    public enum ResultStatus
    {
        /// <summary>
        /// 未开奖
        /// </summary>
        Wait = 0,
        /// <summary>
        /// 已中奖
        /// </summary>
        Win = 1,
        /// <summary>
        /// 未中奖
        /// </summary>
        Lose = 2,
    }

    public class PermutationAndCombination<T>
    {
        /// <summary>
        /// 交换两个变量
        /// </summary>
        /// <param name="a">变量1</param>
        /// <param name="b">变量2</param>
        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        /// <summary>
        /// 递归算法求数组的组合(私有成员)
        /// </summary>
        /// <param name="list">返回的范型</param>
        /// <param name="t">所求数组</param>
        /// <param name="n">辅助变量</param>
        /// <param name="m">辅助变量</param>
        /// <param name="b">辅助数组</param>
        /// <param name="M">辅助变量M</param>
        private static void GetCombination(ref List<T[]> list, T[] t, int n, int m, int[] b, int M)
        {
            for (int i = n; i >= m; i--)
            {
                b[m - 1] = i - 1;
                if (m > 1)
                {
                    GetCombination(ref list, t, i - 1, m - 1, b, M);
                }
                else
                {
                    if (list == null)
                    {
                        list = new List<T[]>();
                    }
                    T[] temp = new T[M];
                    for (int j = 0; j < b.Length; j++)
                    {
                        temp[j] = t[b[j]];
                    }
                    list.Add(temp);
                }
            }
        }
        /// <summary>
        /// 递归算法求排列(私有成员)
        /// </summary>
        /// <param name="list">返回的列表</param>
        /// <param name="t">所求数组</param>
        /// <param name="startIndex">起始标号</param>
        /// <param name="endIndex">结束标号</param>
        private static void GetPermutation(ref List<T[]> list, T[] t, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                if (list == null)
                {
                    list = new List<T[]>();
                }
                T[] temp = new T[t.Length];
                t.CopyTo(temp, 0);
                list.Add(temp);
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    Swap(ref t[startIndex], ref t[i]);
                    GetPermutation(ref list, t, startIndex + 1, endIndex);
                    Swap(ref t[startIndex], ref t[i]);
                }
            }
        }
        /// <summary>
        /// 求从起始标号到结束标号的排列，其余元素不变
        /// </summary>
        /// <param name="t">所求数组</param>
        /// <param name="startIndex">起始标号</param>
        /// <param name="endIndex">结束标号</param>
        /// <returns>从起始标号到结束标号排列的范型</returns>
        public static List<T[]> GetPermutation(T[] t, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex > t.Length - 1)
            {
                return null;
            }
            List<T[]> list = new List<T[]>();
            GetPermutation(ref list, t, startIndex, endIndex);
            return list;
        }
        /// <summary>
        /// 返回数组所有元素的全排列
        /// </summary>
        /// <param name="t">所求数组</param>
        /// <returns>全排列的范型</returns>
        public static List<T[]> GetPermutation(T[] t)
        {
            return GetPermutation(t, 0, t.Length - 1);
        }
        /// <summary>
        /// 求数组中n个元素的排列
        /// </summary>
        /// <param name="t">所求数组</param>
        /// <param name="n">元素个数</param>
        /// <returns>数组中n个元素的排列</returns>
        public static List<T[]> GetPermutation(T[] t, int n)
        {
            if (n > t.Length)
            {
                return null;
            }
            List<T[]> list = new List<T[]>();
            List<T[]> c = GetCombination(t, n);
            for (int i = 0; i < c.Count; i++)
            {
                List<T[]> l = new List<T[]>();
                GetPermutation(ref l, c[i], 0, n - 1);
                list.AddRange(l);
            }
            return list;
        }
        /// <summary>
        /// 求数组中n个元素的组合
        /// </summary>
        /// <param name="t">所求数组</param>
        /// <param name="n">元素个数</param>
        /// <returns>数组中n个元素的组合的范型</returns>
        public static List<T[]> GetCombination(T[] t, int n)
        {
            if (t.Length < n)
            {
                return null;
            }
            int[] temp = new int[n];
            List<T[]> list = new List<T[]>();
            GetCombination(ref list, t, t.Length, n, temp, n);
            return list;
        }
    }
}
