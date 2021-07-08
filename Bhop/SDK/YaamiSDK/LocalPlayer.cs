using System;
using System.Collections.Generic;

namespace Bhop.SDK.YaamiSDK
{
    public class LocalPlayer
    {
        public ulong addr;
        public LocalPlayer(ulong addr) => this.addr = addr;

        #region outside localplayer
        /// <summary>
        /// Player entity reach (LocalPlayer Only!)
        /// </summary>
        public float reach
        {
            get => MCM.readFloat(SDK_PS_Offsets.reach_Hex);
            set => MCM.writeFloat(SDK_PS_Offsets.reach_Hex, value);
        }
        #endregion

        #region Defined vars
        /// <summary>
        /// Player Pitch & Yaw (PnY)
        /// Body rotations
        /// Orientation
        /// Direction
        /// </summary>
        public Vec2 bodyRots
        { get => new Vec2(addr + SDK_PS_Offsets.bodyRots_Hex); }

        /// <summary>
        /// Player hitbox width/height
        /// </summary>
        public Vec2 hitbox
        { get => new Vec2(addr + SDK_PS_Offsets.Hitbox_Hex); }

        /// <summary>
        /// Player block step height
        /// </summary>
        public float stepHeight
        {
            get => MCM.readFloat(addr + SDK_PS_Offsets.Step_Hex);
            set => MCM.writeFloat(addr + SDK_PS_Offsets.Step_Hex, value);
        }

        /// <summary>
        /// Player entity type
        /// </summary>
        public string type
        {
            get => MCM.readString(addr + SDK_PS_Offsets.Type_Hex, 24);
            set => MCM.writeString(addr + SDK_PS_Offsets.Type_Hex, value);
        }

        /// <summary>
        /// Axis Aligned Bounding Boxes AKA
        /// Player position (XYZ_1, XYZ_2)
        /// Contains two Vectors
        /// 
        /// new Vec3(?,?,?) // XYZ 1
        /// new Vec3(?,?,?) // XYZ 2
        /// </summary>
        public AABB playerAABB
        { get => new AABB(addr + SDK_PS_Offsets.PositionX_Hex); }

        /// <summary>
        /// Player velocity
        /// </summary>
        public Vec3 velocity
        { get => new Vec3(addr + SDK_PS_Offsets.VelocityX_Hex); }

        /// <summary>
        /// Entity swinging animation point (1-4, I THINK!)
        /// </summary>
        public int swingAnimation
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.SwingAn_Hex);
            set => MCM.writeInt(addr + SDK_PS_Offsets.SwingAn_Hex, value);
        }

        /// <summary>
        /// Entity username/nametag
        /// </summary>
        public string username
        {
            get => MCM.readString(addr + SDK_PS_Offsets.Username_Hex, 24);
            set => MCM.writeString(addr + SDK_PS_Offsets.Username_Hex, value);
        }

        /// <summary>
        /// The ID of the entity your looking at
        /// </summary>
        public int lookingEntityID
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.LookingEntityID_Hex);
            set => MCM.writeInt(addr + SDK_PS_Offsets.LookingEntityID_Hex, value);
        }

        /// <summary>
        /// Returns true if entity is inside water.
        /// </summary>
        public bool inWater
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.inWater_Hex) != 0;
            set => MCM.writeInt(addr + SDK_PS_Offsets.inWater_Hex, value ? 1 : 0);
        }

        /// <summary>
        /// Returns true if the entity is on the ground.
        /// </summary>
        public bool onGround
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.onGround_Hex) != 0;
            set => MCM.writeInt(addr + SDK_PS_Offsets.onGround_Hex, value ? 1 : 0);
        }
        #endregion

        #region Custom vars
        /// <summary>
        /// Returns true if the players dead else false.
        /// </summary>
        public bool isDead
        {
            get
            {
                if (hitbox.x <= 0.25 && hitbox.y <= 0.25)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Returns true if the players in elytra flight else false.
        /// </summary>
        public bool inElytraFlight
        {
            get
            {
                if (hitbox.x >= 0.5 && hitbox.y >= 0.5 && hitbox.x <= 0.65 && hitbox.y <= 0.65 && onGround == false)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Return true if WASD Or SpaceBar is held else false.
        /// </summary>
        public bool isMoving
        {
            get
            {
                if (keyHooks.keyBoolean('W') || keyHooks.keyBoolean('A') || keyHooks.keyBoolean('S') || keyHooks.keyBoolean('D') || keyHooks.keyBoolean((char)0x20))
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Returns true if the local player is == null.
        /// </summary>
        public bool isNull
        {
            get
            {
                if (playerAABB.AA.x == 0 && playerAABB.BB.x == 0 && playerAABB.AA.y == 0 && playerAABB.BB.y == 0 && playerAABB.AA.z == 0 && playerAABB.BB.z == 0
                    && hitbox.x == 0f && hitbox.y == 0f && bodyRots.x == 0f && bodyRots.y == 0f)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Returns true if the players looking entity id is == -1.
        /// </summary>
        public bool isLookingAtEntity
        {
            get
            {
                if (lookingEntityID != -1)
                    return true;
                return false;
            }
        }
        #endregion

        #region Defined voids
        /// <summary>
        /// External setPos function
        /// </summary>
        /// <param name="vec">Vector3</param>
        public void setPos(Vec3 vec) => playerAABB.moveTo(vec);

        /// <summary>
        /// External refreshAABB function
        /// </summary>
        public void refreshAABB() => playerAABB.moveTo(playerAABB.AA);

        /// <summary>
        /// Looking Vectors
        /// </summary>
        public Vec3 lookingVec
        { get => MathUtils.directionalVector((bodyRots.x + 89.9f) * (float)Math.PI / 178F, bodyRots.y * (float)Math.PI / 178F); }
        #endregion
    }
}
