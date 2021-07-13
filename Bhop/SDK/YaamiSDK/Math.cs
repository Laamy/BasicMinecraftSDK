using System;

namespace Bhop.SDK.YaamiSDK
{
    public class Vec3
    {
        public Vec3(ulong addr) => this.addr = addr;
        private ulong addr;

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

        /// <summary>
        /// Vector x
        /// </summary>
        public float x
        {
            get => MCM.readFloat(addr);
            set => MCM.writeFloat(addr, value);
        }

        /// <summary>
        /// Vector y
        /// </summary>
        public float y
        {
            get => MCM.readFloat(addr + 4);
            set => MCM.writeFloat(addr + 4, value);
        }

        /// <summary>
        /// Vector z
        /// </summary>
        public float z
        {
            get => MCM.readFloat(addr + 8);
            set => MCM.writeFloat(addr + 8, value);
        }

        /// <summary>
        /// Distance to new vector.
        /// </summary>
        public float Distance(Vec3 _Vec3)
        {
            float diff_x = x - _Vec3.x, diff_y = y - _Vec3.y, diff_z = z - _Vec3.z;
            return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }

        /// <summary>
        /// Distance to new vector.
        /// </summary>
        public float Distance(Vec3i _Vec3)
        {
            float diff_x = x - _Vec3.x, diff_y = y - _Vec3.y, diff_z = z - _Vec3.z;
            return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }

        /// <summary>
        /// Set vector as new vector
        /// </summary>
        /// <param name="vec">new Vec3(?,?,?)</param>
        public void setAs(Vec3 vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }
    }
    public class Vec3i
    {
        public Vec3i(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3i(Vec3 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }

        /// <summary>
        /// Vector x
        /// </summary>
        public float x;

        /// <summary>
        /// Vector y
        /// </summary>
        public float y;

        /// <summary>
        /// Vector z
        /// </summary>
        public float z;

        /// <summary>
        /// Distance to new vector.
        /// </summary>
        public float Distance(Vec3 _Vec3)
        {
            float diff_x = x - _Vec3.x, diff_y = y - _Vec3.y, diff_z = z - _Vec3.z;
            return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }

        /// <summary>
        /// Distance to new vector.
        /// </summary>
        public float Distance(Vec3i _Vec3)
        {
            float diff_x = x - _Vec3.x, diff_y = y - _Vec3.y, diff_z = z - _Vec3.z;
            return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }

        /// <summary>
        /// Set vector as new vector
        /// </summary>
        /// <param name="vec">new Vec3(?,?,?)</param>
        public void setAs(Vec3i vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }

        /// <summary>
        /// Set vector as new vector
        /// </summary>
        /// <param name="vec">new Vec3(?,?,?)</param>
        public void setAs(Vec3 vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }
    }
    public class Vec2
    {
        public Vec2(ulong addr) => this.addr = addr;
        private ulong addr;

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

        /// <summary>
        /// Vector y
        /// </summary>
        public float x
        {
            get => MCM.readFloat(addr);
            set => MCM.writeFloat(addr, value);
        }

        /// <summary>
        /// Vector y
        /// </summary>
        public float y
        {
            get => MCM.readFloat(addr + 4);
            set => MCM.writeFloat(addr + 4, value);
        }

        /// <summary>
        /// Set vector as new vector
        /// </summary>
        /// <param name="vec">new Vec2(?,?)</param>
        public void setAs(Vec2 vec)
        {
            x = vec.x;
            y = vec.y;
        }
    }
    public class Vec2i
    {
        public Vec2i(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2i(Vec2 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
        }

        public Vec2i(Vec2i vec)
        {
            this.x = vec.x;
            this.y = vec.y;
        }

        /// <summary>
        /// Vector y
        /// </summary>
        public float x;

        /// <summary>
        /// Vector y
        /// </summary>
        public float y;

        /// <summary>
        /// Set vector as new vector
        /// </summary>
        /// <param name="vec">new Vec2(?,?)</param>
        public void setAs(Vec2 vec)
        {
            x = vec.x;
            y = vec.y;
        }

        /// <summary>
        /// Set vector as new vector
        /// </summary>
        /// <param name="vec">new Vec2i(?,?)</param>
        public void setAs(Vec2i vec)
        {
            x = vec.x;
            y = vec.y;
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
            AA.x = aabb.AA.x;
            AA.y = aabb.AA.y;
            AA.z = aabb.AA.z;

            BB.x = aabb.BB.x;
            BB.y = aabb.BB.y;
            BB.z = aabb.BB.z;
        }
        
        /// <summary>
        /// Player position (Main)
        /// </summary>
        public Vec3 AA
        { get => new Vec3(addr); }

        /// <summary>
        /// Offset player position (Width, Height, Width)
        /// </summary>
        public Vec3 BB
        { get => new Vec3(addr + 12); }

        /// <summary>
        /// Set AABB as new AABB
        /// </summary>
        /// <param name="vec">new AABB(?,?)</param>
        public void setAs(AABB aabb)
        {
            AA.x = aabb.AA.x;
            AA.y = aabb.AA.y;
            AA.z = aabb.AA.z;

            BB.x = aabb.BB.x;
            BB.y = aabb.BB.y;
            BB.z = aabb.BB.z;
        }

        /// <summary>
        /// Teleportation/setPos
        /// </summary>
        /// <param name="vec">new Vec3(?,?,?)</param>
        public void moveTo(Vec3 vec)
        {
            AA.x = vec.x;
            BB.x = vec.x + 0.6f;

            AA.y = vec.y;
            BB.y = vec.y + 1.8f;

            AA.z = vec.z;
            BB.z = vec.z + 0.6f;
        }

        /// <summary>
        /// Moves the player by modifying the position directly.
        /// </summary>
        /// <param name="by">The amount to move the position by.</param>
        public void Move(Vec3 by) => moveTo(new Vec3(AA.x + by.x, AA.y + by.y, AA.z + by.z));

        /// <summary>
        /// Fancy new shit im learning ?
        /// </summary>
        /// <param name="aabb1"></param>
        /// <param name="aabb2"></param>
        /// <returns></returns>
        public static AABB operator +(AABB aabb1, AABB aabb2)
        {
            return new AABB(new Vec3(aabb1.AA.x + aabb2.AA.x, aabb1.AA.y + aabb2.AA.y, aabb1.AA.z + aabb2.AA.z),
                new Vec3(aabb1.BB.x + aabb2.BB.x, aabb1.BB.y + aabb2.BB.y, aabb1.BB.z + aabb2.BB.z));
        }
    }
    public class MathUtils
    {
        /// <summary>
        /// Direction as vector.
        /// </summary>
        public static Vec3 directionalVector(float yaw, float pitch)
        { return new Vec3((float)Math.Cos(yaw) * (float)Math.Cos(pitch), (float)Math.Sin(pitch), (float)Math.Sin(yaw) * (float)Math.Cos(pitch)); }

        /// <summary>
        /// Direction as vector.
        /// </summary>
        public static Vec3i directionalVector_Vec3i(float yaw, float pitch)
        { return new Vec3i((float)Math.Cos(yaw) * (float)Math.Cos(pitch), (float)Math.Sin(pitch), (float)Math.Sin(yaw) * (float)Math.Cos(pitch)); }
    }
}
