using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danshjo
{
    class Ostad
    {
        //================================================= Properties
        public string _NameOfMaster { get; set; }
        public string _MasterToken { get; set; }
        public int number { set; get; }
        public List<doroos> _Doroose_eraeeShode { set; get; }
        public List<doroos> _Doroose_ostad { set; get; }

        //================================================= Constructors

        public void getostad(int id, string Name, string Nameostad, int number)
        {
            doroos obj_doroos = new doroos();
            obj_doroos.darsID = id;
            obj_doroos.Name = Name;
            obj_doroos.ostadName = Nameostad;
            obj_doroos.number = number;
            _Doroose_eraeeShode.Add(obj_doroos);
        }

        public Ostad()
        {
             _Doroose_eraeeShode = new List<doroos>();

            _Doroose_ostad = new List<doroos>();

            _MasterToken = Guid.NewGuid().ToString();
        }

        //================================================= Methods


    }
}
