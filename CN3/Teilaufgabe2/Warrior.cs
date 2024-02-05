using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Teilaufgabe2
{
    public class Warrior
    {
        [XmlAttribute("Name", DataType = "string")]
        [JsonInclude]
        public string Name;

        [XmlArray("Weapons")]
        [XmlArrayItem("Weapon")]
        [JsonInclude]
        public Weapon[] Weapons;

        public Warrior() { }
    }
}
