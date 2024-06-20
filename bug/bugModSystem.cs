using Vintagestory.API.Common;


using bug.src;

namespace  Bug
{
    

public class bugModSystem : ModSystem
{
    public override void Start(ICoreAPI api)
    {
        api.Logger.Notification("Registering bug components.");
        api.RegisterBlockClass("bug", typeof(BugBlock));
        api.RegisterBlockEntityClass("bug", typeof(BugEntity));
    }
}
}