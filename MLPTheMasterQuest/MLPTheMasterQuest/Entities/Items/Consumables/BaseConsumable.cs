using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MLPTheMasterQuest.Entities.Items;

namespace MLPTheMasterQuest.Entities.Items.Consumables
{
    public abstract class BaseConsumable : BaseItem
    {
        public BaseConsumable(string name, int price)
            : base(name, ItemType.Consumable, price)
        {
        }
    }
}
