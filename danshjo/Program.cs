using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace danshjo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            mohasbe dars = new mohasbe();
            int j = 1, num = 1;
            
            int adddars;
            string addname2 = null;
            List<Ostad> Masters;
            List<doroos> Listofdoroos;
             List<doroos>List_doroos = new List<doroos>();
            List<danshjo> L1;
            //    List<doroos> _Doroose_eraeeShode;
            /////////////////////////////////چک کردن پوشه وفایل

           cash save_dars = new cash("Data.List_droos", "The_List_droos");
            string JsonFromCash = save_dars.TextFromFile();

            if (string.IsNullOrEmpty(JsonFromCash))
            {
                Listofdoroos = new List<doroos>();
            }
            else
            {
                Listofdoroos = JsonConvert.DeserializeObject<List<doroos>>(JsonFromCash);
            }

            ////////-------------------------------------------------------------------
            cash save_ostad = new cash("Data.List_ostad", "The_List_ostad");
            string JsonCash_ostad = save_ostad.TextFromFile();

            if (string.IsNullOrEmpty(JsonCash_ostad))
            {
                Masters = new List<Ostad>();
            }
            else
            {
                Masters = JsonConvert.DeserializeObject<List<Ostad>>(JsonCash_ostad);
            }

            ////////-------------------------------------------------------------------
            cash save__danshjo = new cash("Data.List_danshjo", "The_List_danshjo");
            string JsonCash_danshjo = save__danshjo.TextFromFile();

            if (string.IsNullOrEmpty(JsonCash_danshjo))
            {
                L1 = new List<danshjo>();
            }
            else
            {
                L1 = JsonConvert.DeserializeObject<List<danshjo>>(JsonCash_danshjo);
            }

            /////////////////////////////////////////////////////////درس
            Console.Write("----------------------dars--------------------\n");
            Console.Write($"Tedad dars mojood  {Listofdoroos.Count}  Mibashad EzafeKardane dars jadid \"y\"");

            string flag = Console.ReadLine().ToLower();
            if (flag == "y")
            {
                Console.Write("chand ta dars?");
                adddars = Convert.ToInt32(Console.ReadLine());

                while (j <= adddars)
                {
                    doroos cash_dars = new doroos();
                    j++;
                    Console.Write("\nid dars " + "enter:");
                    // addnum1 = Convert.ToInt32(Console.ReadLine());
                    cash_dars.darsID = Convert.ToInt32(Console.ReadLine()); ;

                    Console.Write("name dars " + "enter:");
                    // addname1 = Console.ReadLine();
                    cash_dars.Name = Console.ReadLine(); ;
                    Listofdoroos.Add(cash_dars);
                }
            }

            Console.WriteLine("\ndarsa ====>\n");
            for (int i = 0; i < Listofdoroos.Count; i++)
            {
                Console.WriteLine($" Name : {Listofdoroos[i].Name}-----id : {Listofdoroos[i].darsID}");
                dars.getdoroos(Listofdoroos[i].darsID, Listofdoroos[i].Name);
            }

            int i1 = SaveCash_order(Listofdoroos);
            switch (i1)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }
            Console.ReadLine();


            //////////////////////////////////////////استاد
            Console.Write("----------------------ostad--------------------\n");
            Console.Write($"Tedad ostad mojood  {Masters.Count}  Mibashad EzafeKardane Ostad jadid \"y\"");

            string f1 = Console.ReadLine().ToLower();
            if (f1 == "y")
            {
                Console.Write("\nchand ta ostad?");
                int counts = Convert.ToInt32(Console.ReadLine());

                for (int ii = 0; ii < counts; ii++)
                {
                    Ostad objOstad = new Ostad();
                    Console.Write("\nEnter ostad Name : ");
                    string name_osta = Console.ReadLine();
                    objOstad._NameOfMaster = name_osta;

                    Masters.Add(objOstad);
                }
            }

            Console.WriteLine("\nostad ====> \n");
            for (int i = 0; i < Masters.Count; i++)
            {
                Console.WriteLine($" Name : {Masters[i]._NameOfMaster}-----Token : {Masters[i]._MasterToken}");

            }

            int ii1 = Save_order(Masters);
            switch (ii1)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }
            Console.ReadLine();

            ////////////////////////////////////////////انتخاب درس استاد
            Ostad obj_Ostad = new Ostad();

            Console.WriteLine("-----------------antkham dars ostad--------------------\n");
            Console.Write($"Tedad ostad mojood  {Masters.Count}  Mibashad EzafeKardane dars Ostad jadid \"y\"");

            string f2 = Console.ReadLine().ToLower();
            if (f2 == "y")
            {
                for (int q = 0; q < Masters.Count; q++)
                {
                    Console.WriteLine("\nlotfan az doroos e zir yeki ya chand dars ra be ostad motasel namaeyd !\nNahve ye etesale doroos be soorate  \"IDdars1,IDdars2,IDdars3,...\" Mibashad !\n");
                    Console.WriteLine($"Name e ostad : {Masters[q]._NameOfMaster}");
                    for (int jj = 0; jj < dars.Listofdoroos.Count; jj++)
                    {
                        Console.WriteLine($"{jj + 1}.Name : {dars.Listofdoroos[jj].Name} -- ID : {dars.Listofdoroos[jj].darsID}");
                    }
                    Console.WriteLine("\n=============== Id Doroos Ra Vared Namaeyd ");
                    string Doroos = Console.ReadLine();
                    if (Doroos.Contains(','))
                    {
                        string[] DoroosArry = Doroos.Split(',');
                        for (int k = 0; k < DoroosArry.Length; k++)
                        {
                            doroos objDoroos = new doroos();
                            objDoroos = dars.Listofdoroos.Find(x => x.darsID == Convert.ToInt32(DoroosArry[k]));
                            Masters[q]._Doroose_ostad.Add(objDoroos);

                            //     obj_Ostad.getostad(objDoroos.darsID, objDoroos.Name, Masters[q]._NameOfMaster, num);
                            Console.WriteLine($"Baraye ostad {Masters[q]._NameOfMaster}----Darse {objDoroos.Name} ba ID : {objDoroos.darsID}  Add Shod !\n=========================================");

                        }
                    }
                    else
                    {
                        doroos objDoroos = new doroos();
                        objDoroos = dars.Listofdoroos.Find(x => x.darsID == Convert.ToInt32(Doroos));
                        Masters[q]._Doroose_ostad.Add(objDoroos);

                        //     obj_Ostad.getostad(objDoroos.darsID, objDoroos.Name, Masters[q]._NameOfMaster, num);
                        Console.WriteLine($"Baraye ostad {Masters[q]._NameOfMaster}---- Darse { objDoroos.Name} ba ID : {objDoroos.darsID}  Add Shod !\n=========================================");
                    }
                }
            }

            Console.WriteLine("\nDoroose eraeeShode====>\n ");
            for (int i = 0; i < Masters.Count; i++)
            {
                for (int ia = 0; ia < Masters[i]._Doroose_ostad.Count; ia++)
                {

                    Console.WriteLine($"Name Ostad: {Masters[i]._NameOfMaster} -- Name Dars : {Masters[i]._Doroose_ostad[ia].Name} -- ID : {Masters[i]._Doroose_ostad[ia].darsID}");
                    obj_Ostad.getostad(Masters[i]._Doroose_ostad[ia].darsID, Masters[i]._Doroose_ostad[ia].Name, Masters[i]._NameOfMaster, num);
                    num++;
                }
            }
            Console.ReadLine();

            int ii3 = Save_order(Masters);
            switch (ii3)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }
            Console.ReadLine();

            ////////////////////////////////////////دانشجو
            Console.WriteLine("\n-----------------danshjo--------------------");
            Console.Write($"Tedad danshjo mojood  {L1.Count}  Mibashad EzafeKardane danshjo jadid \"y\"");
            int addnfar;

            string f3 = Console.ReadLine().ToLower();
            if (f3 == "y")
            {

                Console.Write("\nchand ta danshamoz?");
                addnfar = Convert.ToInt32(Console.ReadLine());

                for (int ii = 0; ii < addnfar; ii++)
                {

                    Console.Write("name daneshamooz?");
                    addname2 = Console.ReadLine();

                    danshjo obj_daneshju = new danshjo();
                    obj_daneshju.DaneshAmoozName = addname2;

                    L1.Add(obj_daneshju);

                }
            }

            Console.WriteLine("\ndanshjo ====> \n");
            for (int i = 0; i < L1.Count; i++)
            {
                Console.WriteLine($" Name : {L1[i].DaneshAmoozName}");

            }

            int ii2 = Save_danshjo(L1);
            switch (ii2)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }
            Console.ReadLine();

            //////////////////////////////////////////انتخاب درس واستادی برای دانشجیان
            Console.WriteLine("-----------------antkham dars va ostad bray Danshjo--------------------\n");
            Console.Write($"Tedad danshjo mojood  {L1.Count}  Mibashad EzafeKardane dars danshjo jadid \"y\"");
            string f4 = Console.ReadLine().ToLower();
            if (f4 == "y")
            {
                for (int q = 0; q < L1.Count; q++)
                {
                    Console.WriteLine("\nlotfan az doroos va ostad e zir yeki ya chand dars ra be danshjo motasel namaeyd !\nNahve ye etesale doroos be soorate  \"shomar dars1,shomar dars2,shomar dars3,...\" Mibashad !\n");
                    Console.WriteLine($"Name e danshjo : {L1[q].DaneshAmoozName}\n");

                    for (int jj = 0; jj < obj_Ostad._Doroose_eraeeShode.Count; jj++)
                    {
                        Console.WriteLine($"{obj_Ostad._Doroose_eraeeShode[jj].number}.Name Ostad: {obj_Ostad._Doroose_eraeeShode[jj].ostadName} -- Name Dars : {obj_Ostad._Doroose_eraeeShode[jj].Name} -- ID : {obj_Ostad._Doroose_eraeeShode[jj].darsID}");
                    }
                    Console.WriteLine("\n=============== Id Doroos Ra Vared Namaeyd ");

                    string Doroos = Console.ReadLine();
                    if (Doroos.Contains(','))
                    {
                        string[] DoroosArry = Doroos.Split(',');
                        for (int k = 0; k < DoroosArry.Length; k++)
                        {
                            doroos objDoroos = new doroos();
                            objDoroos = obj_Ostad._Doroose_eraeeShode.Find(x => x.number == Convert.ToInt32(DoroosArry[k]));
                            L1[q]._Doroose_danshjo.Add(objDoroos);
                            Console.WriteLine($"Baraye danshjo {L1[q].DaneshAmoozName} ostad {objDoroos.ostadName}  Darse {objDoroos.Name} ba ID : {objDoroos.darsID}  Add Shod !\n=========================================");
                        }
                    }
                    else
                    {
                        doroos objDoroos = new doroos();
                        objDoroos = obj_Ostad._Doroose_eraeeShode.Find(x => x.number == Convert.ToInt32(Doroos));
                        L1[q]._Doroose_danshjo.Add(objDoroos);
                        Console.WriteLine($"Baraye danshjo {L1[q].DaneshAmoozName} ostad {objDoroos.ostadName}  Darse {objDoroos.Name} ba ID : {objDoroos.darsID}  Add Shod !\n=========================================");
                    }
                }
            }

            Console.WriteLine("\nDars danshjo ====> \n");
            for (int i = 0; i < L1.Count; i++)
            {
                for (int ia = 0; ia < L1[i]._Doroose_danshjo.Count; ia++)
                {
                    Console.WriteLine($"Baraye danshjo: {L1[i].DaneshAmoozName} ----- ostad {L1[i]._Doroose_danshjo[ia].ostadName} ----Darse {L1[i]._Doroose_danshjo[ia].Name} -----ba ID : {L1[i]._Doroose_danshjo[ia].darsID}");
                }

            }

            int ii4 = Save_danshjo(L1);
            switch (ii4)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }
            Console.ReadLine();

            /////////////////////////////////////////////امتحان
            Console.WriteLine("\n-----------------amthanat--------------------");
            Console.Write($"Tedad danshjo mojood  {L1.Count}  Mibashad EzafeKardane amthanat danshjo jadid \"y\"");
            string f5 = Console.ReadLine().ToLower();
            if (f5 == "y")
            {
                Console.Write("\nhar dars chan amthan?");
                int chandamthan = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < L1.Count; i++)
                {
                    for (int k = 0; k < dars.Listofdoroos.Count; k++)
                    {
                        for (int jj = 0; jj < chandamthan; jj++)
                        {
                            doroos objd = new doroos();

                            objd.darsID = dars.Listofdoroos[k].darsID;
                            objd.Name = dars.Listofdoroos[k].Name;
                            Console.Write("\nnomre dars " + dars.Listofdoroos[k].Name + " " + L1[i].DaneshAmoozName + " : ");
                            objd.Point = Convert.ToDouble(Console.ReadLine());
                            List_doroos.Add(objd);
                            L1[i].doroosPoint.Add(objd);  
                        }
                    }
                   
                    dars.getDaneshamoozLessons(List_doroos, L1[i].DaneshAmoozName);
                }

                Console.WriteLine("\n");
                Console.WriteLine(dars.GetListResult(L1.Count));
                Console.WriteLine(dars.bm());

                for (int h=0; h < dars.L1.Count ; h++)
                {
                    L1[h].Moadel_koll=dars.L1[h].Moadel_koll;
                }

            }
            Console.WriteLine("\nDars danshjo ====> \n");
            for (int i = 0; i < L1.Count; i++)
            {
                Console.WriteLine($"\nname daneshAmooz: { L1[i].DaneshAmoozName} \n Moadel_koll: {L1[i].Moadel_koll} ");

                for (int ia = 0; ia < L1[i].doroosPoint.Count; ia++)
                {
                    Console.WriteLine($"Darse {L1[i].doroosPoint[ia].Name} -----doroos Point  : {L1[i].doroosPoint[ia].Point}");
                }
                for (int ia = 0; ia < L1[i].Moadel.Count; ia++)
                {
                    Console.WriteLine($"Darse {L1[i].Moadel[ia].Name} -----doroos Point  : {L1[i].Moadel[ia].Point}");
                }

            }

            int ii5 = Save_danshjo(L1);
            switch (ii5)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }
            Console.ReadLine();
        }

        ///////////////////////////////////////////////////نوشتن فایل 
        public static int SaveCash_order(List<doroos> CASH)
        {
            string Jsondars = JsonConvert.SerializeObject(CASH);
            cash savedars = new cash("Data.List_droos", "The_List_droos");
            int res = 0;
            try
            {

                res = savedars.Write_ToFile(Jsondars, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }
        public static int Save_order(List<Ostad> TOCASH)
        {
            string Jsonostad = JsonConvert.SerializeObject(TOCASH);
            cash save_ostad = new cash("Data.List_ostad", "The_List_ostad");


            int res = 0;
            try
            {
                res = save_ostad.Write_ToFile(Jsonostad, true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }
        public static int Save_danshjo(List<danshjo> TOCASH)
        {
            string Jsondanshjo = JsonConvert.SerializeObject(TOCASH);
            cash save_danshjo = new cash("Data.List_danshjo", "The_List_danshjo");


            int res = 0;
            try
            {
                res = save_danshjo.Write_ToFile(Jsondanshjo, true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }
    }
}
