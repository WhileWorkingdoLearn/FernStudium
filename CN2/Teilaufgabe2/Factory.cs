using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilaufgabe2
{
    internal class Factory<TItemType, TParameterType> where TItemType : IInitializing<TParameterType>, new()
    {
        private TParameterType _value;
        public Factory(TParameterType value) {
           _value = value;
        }

        public TItemType MakeItem() {TItemType item = new TItemType();
            item.Initialize(_value); return item;
                }

        public TItemType[] MakeItems(int count) {
            TItemType[] items = new TItemType[count]; 
            for (int i = 0; i < count; i++)
            {
                items[i] = MakeItem();
            }   
            return items;
        }
    }
}
