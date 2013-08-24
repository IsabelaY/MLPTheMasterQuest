using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLPTheMasterQuest.Entities.Items
{
    public enum ItemType { Consumable, Armor, Accessory, Weapon, Key }

    public abstract class BaseItem
    {
        #region Field Region

        string name;
        ItemType type;
        int price;

        #endregion

        #region Property Region

        public ItemType Type
        {
            get { return type; }
            protected set { type = value; }
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        public int Price
        {
            get { return price; }
            protected set { price = value; }
        }

        #endregion

        #region Constructor Region

        public BaseItem(string name, ItemType type, int price)
        {
            Type = type;
            Name = name;
            Price = price;
        }

        #endregion

        #region Abstract Methods Region

        public abstract object Clone();

        public override string ToString()
        {
            string itemString = "";

            itemString += Name + ", ";
            itemString += Type + ", ";
            itemString += Price.ToString();

            return itemString;
        }

        #endregion


    }
}