using System;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;

namespace bug.src
{
    
    public class BugEntity : BlockEntity
    {
        private int val = 0;
    
    public BugEntity(){
        // We should not see this in the console after a snow update.. but we do.
        Console.WriteLine("Constructor");
    }

    public void setVal(int v)
    {
        val = v;
        MarkDirty(true);
    }

    public override void Initialize(ICoreAPI api)
    {
        base.Initialize(api);
    }

    public override void OnExchanged(Block block)
    {
        Console.WriteLine("Exchanged");
        base.OnExchanged(block);
    }
    }

}