using System;
using System.Collections.Generic;
using System.Text;

namespace Well.Model
{
    public class WinNumber
    {
        public WinNumber()
        {

        }
        public int Id { get; set; }

        public string Issue { get; set; }

        public string Num1_Code { get; set; }

        public string Num1_Zodiac { get; set; }

        public string Num2_Code { get; set; }

        public string Num2_Zodiac { get; set; }

        public string Num3_Code { get; set; }

        public string Num3_Zodiac { get; set; }

        public string Num4_Code { get; set; }

        public string Num4_Zodiac { get; set; }

        public string Num5_Code { get; set; }

        public string Num5_Zodiac { get; set; }

        public string Num6_Code { get; set; }

        public string Num6_Zodiac { get; set; }

        public string Num7_Code { get; set; }

        public string Num7_Zodiac { get; set; }

        public string Create_Time { get; set; }

        public string Create_User_Id { get; set; }


        public string Update_Time { get; set; }

        public string Update_User_Id { get; set; }

        public string Display1 { get; set; }

        public string Display2 { get; set; }

        public string Display3 { get; set; }

        public string Display4 { get; set; }

        public string Display5 { get; set; }

        public string Display6 { get; set; }

        public string Display7 { get; set; }


        private List<string> _CodeList = new List<string>();
        public List<string> CodeList
        {
            get
            {
                _CodeList.Clear();
                _CodeList.Add(Num1_Code);
                _CodeList.Add(Num2_Code);
                _CodeList.Add(Num3_Code);
                _CodeList.Add(Num4_Code);
                _CodeList.Add(Num5_Code);
                _CodeList.Add(Num6_Code);
                _CodeList.Add(Num7_Code);

                return _CodeList;
            }
        }

        private List<string> _ZodiacList = new List<string>();
        public List<string> ZodiacList
        {
            get
            {
                _ZodiacList.Clear();
                _ZodiacList.Add(Num1_Zodiac);
                _ZodiacList.Add(Num2_Zodiac);
                _ZodiacList.Add(Num3_Zodiac);
                _ZodiacList.Add(Num4_Zodiac);
                _ZodiacList.Add(Num5_Zodiac);
                _ZodiacList.Add(Num6_Zodiac);
                _ZodiacList.Add(Num7_Zodiac);

                return _ZodiacList;
            }
        }
    }
}
