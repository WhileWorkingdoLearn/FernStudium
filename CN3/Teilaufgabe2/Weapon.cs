using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Teilaufgabe2
{
    public class Weapon
    {
        private string _Type;

        private WeaponRange _Range;

        [XmlElement("Type")]
        public string Type { get => _Type; set => _Type = value; }

        [XmlElement("Range")]
        public WeaponRange Range { get => _Range; set => _Range = value; } 
        
        public Weapon() { }
    }
}
