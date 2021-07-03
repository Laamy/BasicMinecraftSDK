using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhop.SDK.YaamiSDK
{
    public class Vec3
    {
        public Vec3(ulong addr) => this.addr = addr;
        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vec3(Vec3 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }
        private ulong addr;
        public float x
        {
            get => MCM.readFloat(addr);
            set => MCM.writeFloat(addr, value);
        }
        public float y
        {
            get => MCM.readFloat(addr + 4);
            set => MCM.writeFloat(addr + 4, value);
        }
        public float z
        {
            get => MCM.readFloat(addr + 8);
            set => MCM.writeFloat(addr + 8, value);
        }
        public float Distance(Vec3 _Vec3)
        {
            float diff_x = x - _Vec3.x, diff_y = y - _Vec3.y, diff_z = z - _Vec3.z;
            return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }
    }
    public class Vec2
    {
        public Vec2(ulong addr) => this.addr = addr;
        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vec2(Vec2 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
        }
        private ulong addr;
        public float x
        {
            get => MCM.readFloat(addr);
            set => MCM.writeFloat(addr, value);
        }
        public float y
        {
            get => MCM.readFloat(addr + 4);
            set => MCM.writeFloat(addr + 4, value);
        }
    }
    public class AABB
    {
        public AABB(ulong addr) => this.addr = addr;
        private ulong addr;
        public AABB(Vec3 AA, Vec3 BB)
        {
            this.AA.x = AA.x;
            this.AA.y = AA.y;
            this.AA.z = AA.z;

            this.BB.x = BB.x;
            this.BB.y = BB.y;
            this.BB.z = BB.z;
        }
        public AABB(AABB aabb)
        {
            this.AA.x = aabb.AA.x;
            this.AA.y = aabb.AA.y;
            this.AA.z = aabb.AA.z;

            this.BB.x = aabb.BB.x;
            this.BB.y = aabb.BB.y;
            this.BB.z = aabb.BB.z;
        }
        public Vec3 AA
        { get => new Vec3(addr); }
        public Vec3 BB
        { get => new Vec3(addr + 12); }
    }
    public class MathUtils
    {
        public static Vec3 directionalVector(float yaw, float pitch)
        { return new Vec3((float)Math.Cos(yaw) * (float)Math.Cos(pitch), (float)Math.Sin(pitch), (float)Math.Sin(yaw) * (float)Math.Cos(pitch)); }
    }
}
