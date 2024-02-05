using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilaufgabe3
{
    public class Fussballverein : IComparable<Fussballverein>
    {
        private string _Name;

        private int  _Punkte, _Tordifferenz;

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public int Punkte { 
            set { _Punkte = value; }
            get { return _Punkte; } 
        }

        public int Tordifferenz { 
            set { _Tordifferenz = value; }
            get { return _Tordifferenz;}
        }

        public int CompareTo(Fussballverein? andereVerein)
        {
            if (andereVerein == null) return 1;
                 
            if (Equals(andereVerein)) return 0;
            
            if (this.Punkte == andereVerein.Punkte)
            {

                if (this._Tordifferenz == andereVerein.Tordifferenz) return 0;

                if (this._Tordifferenz < andereVerein.Tordifferenz) return -1;

                if (this._Tordifferenz > andereVerein.Tordifferenz) return 1;
                   
            }

            if (this.Punkte < andereVerein.Punkte) return 1;

            if (this.Punkte > andereVerein.Punkte) return -1;

            
            return 0;
        }


        public bool Equals(Fussballverein andereVerein)
        {
            return (this._Name == andereVerein._Name);
        }
        
        public override string ToString()
        {
            return _Name;
        }
    }
}
