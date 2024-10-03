using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace bug.src
{

    public class BugBlock : Block
    {


        public override bool TryPlaceBlock(IWorldAccessor world, IPlayer byPlayer, ItemStack itemstack, BlockSelection blockSel, ref string failureCode)
        {
            Block block = world.BlockAccessor.GetBlock(Code);

            // Check if we can actually place this block here
            if (block.CanPlaceBlock(world, byPlayer, blockSel, ref failureCode))
            {
                Console.WriteLine("Can Place block!");
                // This actually 'adds the block'. Set the block to this position as we know it is allowed. This instantiates an entity object for us.
                world.BlockAccessor.SetBlock(block.BlockId, blockSel.Position);

                BugEntity be = GetBlockEntity<BugEntity>(blockSel.Position);
                be?.setVal(1);
                
                return true;
            }
            return false;
        }

     public override void PerformSnowLevelUpdate(IBulkBlockAccessor blockAccessor, BlockPos pos, Block newBlock, float snowLevel)
        {
            base.PerformSnowLevelUpdate(blockAccessor, pos, newBlock, snowLevel);
        }
    

        public void ForceExchangeBlock(int id, BlockPos pos)
        {
            api.World.BlockAccessor.ExchangeBlock(id, pos);
        }

    }
}
