using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ECONOSAVE
{
    class General
    {
        #region Item Chuỗi
        public static String Trim(string s_value)
        {
            return s_value.Trim();
        }
        public static String Left(string s_Value, int s_index)
        {
            return s_Value.Substring(0, s_index);
        }

        public static String Right(string s_Value, int count)
        {
            return s_Value.Substring(s_Value.Length - count + 1);
        }

        public static String LeftByte(string s_Value, int count)
        {
            int i = 0;
            int y = 0;
            string rtn = "";
            foreach (byte c in Encoding.UTF8.GetBytes(s_Value.ToCharArray()))
            {
                if (i < count)
                {
                    rtn += s_Value[y];
                    if (c > 255)
                    {
                        i = i + 2;
                    }
                    else
                    {
                        i = i + 1;
                    }
                    y += 1;
                }
                else
                {
                    break;
                }
            }
            return rtn;
        }

        public static String RightByte(string s_Value, int count)
        {
            int i = 0;
            int y = 0;
            int len = s_Value.Length;
            string rtn = "";
            foreach (byte c in Encoding.UTF8.GetBytes(s_Value.ToCharArray()))
            {
                if (i < count)
                {
                    rtn += s_Value[len - y];
                    if (c > 255)
                    {
                        i = i + 2;
                    }
                    else
                    {
                        i = i + 1;
                    }
                    y += 1;
                }
                else
                {
                    break;
                }
            }
            return rtn;
        }
        #endregion
    }
}
