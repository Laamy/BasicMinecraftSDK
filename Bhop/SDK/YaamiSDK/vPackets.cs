using Bhop.gameHooks;

namespace Bhop.SDK.YaamiSDK
{
    public class vPackets // Fake packets
    {
        public bool copyBlock() => gh_Mouse.sendAction(gh_Mouse.MouseEF.CopyBlock);
        public bool place() => gh_Mouse.sendAction(gh_Mouse.MouseEF.Place);
        public bool hit() => gh_Mouse.sendAction(gh_Mouse.MouseEF.Hit);
    }
}
