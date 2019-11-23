using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danshjo
{
    class danshjo
    {
        //public double RiyaziPoint { get; set; }
        //public double fizekiPoint { get; set; }
        //public double ShimiPoint { get; set; }

        /// <summary>
        /// doroosPoint لیست نمردرس فراخوانی شده
        /// DaneshAmoozName نام دانشجو ها دریافتی
        /// Moadel لیست معدل فراخوانی شده
        /// Moadel_koll معدل کل همه دانشجو ها در یک درس
        /// doroosStruct 
        /// </summary>

        public string DaneshAmoozName { get; set; }
        public List<doroos> _Doroose_danshjo { set; get; }
        public List<doroos> doroosPoint { set; get; }
        public List<doroos> Moadel { get; set; }
        public double Moadel_koll { set; get; }
        public List<doroos> doroosStruct { set; get; }
        public danshjo()
        {
            _Doroose_danshjo = new List<doroos>();
            Moadel = new List<doroos>();
            doroosPoint = new List<doroos>();
            doroosStruct = new List<doroos>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Calculate_Moadel()
        {
            for (int i = 0; i < doroosStruct.Count; i++)
            {
                List<doroos> nomaratetakdars = doroosPoint.FindAll(x => x.darsID == doroosStruct[i].darsID);
                double ResultOfX = 0;
                doroos objMoadel = new doroos();
                for (int j = 0; j < nomaratetakdars.Count; j++)
                {
                    ResultOfX += nomaratetakdars[j].Point;
                    objMoadel.darsID = nomaratetakdars[j].darsID;
                    objMoadel.Name = nomaratetakdars[j].Name;

                }
                ResultOfX = ResultOfX / nomaratetakdars.Count;
                objMoadel.Point = ResultOfX;
                Moadel.Add(objMoadel);
            }
        }

        /// <summary>
        /// calculate_moadele_koll محاسبه معدل کل همه دانشجو ها در یک درس 
        /// Moadel.Count تعداد نمرات معدل
        /// result +=Moadel[i].Point نمرات معدل داخل یک متغییر
        /// Moadel_koll معدل کل همه دانشجو ها در یک درس
        /// </summary>
        public void calculate_moadele_koll()
        {
            double result = 0;
            for (int i = 0; i < Moadel.Count; i++)
            {
                result += Moadel[i].Point;
            }
            Moadel_koll = result / Moadel.Count;

        }
    }
}
