﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sds.Inn.UpdatableItems
{
    public interface IItemTypeDictionary
    {
        IDictionary<string, Type> ItemTypes { get; set; }
    }
}
