using System;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;
using System.Threading;

namespace bug.src
{
    
    public class BugEntity : BlockEntity
    {
        private int val = 0;
    
    public BugEntity(){
        Console.WriteLine("Constructor");
    }

    // This value is set AFTER it has been added to the world and before TryPlaceBlock returns.
    public void setVal(int v)
    {
        val = v;
        MarkDirty(true);
    }

    public override void Initialize(ICoreAPI api)
    {
        base.Initialize(api);
        // un comment this line to see that block exchange on a tick callback doesn't cause the issue.
        //RegisterGameTickListener(ForceExchange, 2000);
    }

    public override void OnExchanged(Block block)
    {
        base.OnExchanged(block);
        // This value should never print 0. But it does after snow updates.
        Console.WriteLine("Entity value: " + val);
    }


    public void ForceExchange(float dt)
    {
        Block block = Block as BugBlock;
        if (block != null)
        {
            int id = block.Id == block.snowCovered1.Id ?  block.notSnowCovered.Id: block.snowCovered1.Id;
            Console.WriteLine("Exchanging id: " + id);
            (Block as BugBlock)?.ForceExchangeBlock(id, Pos);
        }
    }

    }

}