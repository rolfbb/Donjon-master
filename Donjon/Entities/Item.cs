using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon.Entities
{
    class Item : IDrawable
    {
        public string Name { get; }
        public string Symbol { get; }
        public virtual ConsoleColor Color { get; }

        public Item(string name, string symbol, ConsoleColor color)
        {
            Name = name;
            Symbol = symbol;
            Color = color;
        }

        // Factory-method (metod istf property för att tydliggöra att man får ett nytt conin vid varje anrop
        public static Item Coin() => new Item("Coin", "c", ConsoleColor.Yellow);

    }
}
