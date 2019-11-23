using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danshjo
{
    class mohasbe
    {
        /// <summary>
        /// 
        /// </summary>

        public List<danshjo> L1 = new List<danshjo>();
        public List<doroos> Listofdoroos = new List<doroos>();

        //public void kjfor(double num1, double num2, double num3, string str)
        //{
        //    danshjo hsab = new danshjo();
        //    hsab.RiyaziPoint=(num1);
        //    hsab.fizekiPoint=(num2);
        //    hsab.ShimiPoint=(num3);
        //    hsab.Calculate_Moadel();
        //    hsab.DaneshAmoozName=(str);
        //    L1.Add(hsab);
        //}


        /// <summary>
        /// 
        /// </summary>
        string ListRes = "";
        public void getdoroos(int id, string Name)
        {
            doroos obj_doroos = new doroos();
            obj_doroos.darsID = id;
            obj_doroos.Name = Name;
            Listofdoroos.Add(obj_doroos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dars"></param>
        /// <param name="daneshamoozname"></param>


        public void getDaneshamoozLessons(List<doroos> dars, string name)
        {
            danshjo obj_daneshju = new danshjo();
            obj_daneshju.DaneshAmoozName = name;
            obj_daneshju.doroosPoint = dars;
            obj_daneshju.doroosStruct = Listofdoroos;
            obj_daneshju.Calculate_Moadel();
            L1.Add(obj_daneshju);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Count"></param>
        /// <returns></returns>
        public string GetListResult(int Count)
        {

            for (int i = 0; i < L1.Count; i++)
            {
                L1[i].calculate_moadele_koll();
                ListRes += L1[i].DaneshAmoozName + ":" + L1[i].Moadel_koll + "\n";
            }
            return ListRes;

        }

        string Res1 = "";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string bm()
        {

            for (int i = 0; i < L1.Count; i++)
            {

                for (int j = 0; j < Listofdoroos.Count; j++)
                {
                    Listofdoroos[j].Point = L1[i].Moadel.Find(x => x.darsID == Listofdoroos[j].darsID).Point + Listofdoroos[j].Point;

                }
            }

            Res1 = "";
            for (int j = 0; j < Listofdoroos.Count; j++)
            {
                Res1 += "Moadel e dars e  " + Listofdoroos[j].Name + " barabar ast ba : " + (Listofdoroos[j].Point / L1.Count) + "\n";
            }
            return Res1;
        }
    }
}
