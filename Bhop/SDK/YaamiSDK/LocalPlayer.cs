using System;
using System.Collections.Generic;

namespace Bhop.SDK.YaamiSDK
{
    public class LocalPlayer
    {
        public ulong addr;
        public LocalPlayer(ulong addr) => this.addr = addr;

        #region Defined vars
        /// <summary>
        /// Returns the amount of items your players holding
        /// </summary>
        public int heldItemCount
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.heldItemCount_Hex);
            set => MCM.writeInt(addr + SDK_PS_Offsets.heldItemCount_Hex, value);
        }

        /// <summary>
        /// Returns true if you can view creative items else false.
        /// </summary>
        public bool viewCreativeitems
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.viewCreativeItems) != 0;
            set => MCM.writeInt(addr + SDK_PS_Offsets.viewCreativeItems, value ? 1 : 0);
        }

        /// <summary>
        /// Returns true if local player is flying else false;
        /// </summary>
        public bool isFlying
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.isFlying_Hex) != 0;
            set => MCM.writeInt(addr + SDK_PS_Offsets.isFlying_Hex, value ? 1 : 0);
        }

        /// <summary>
        /// Returns true if user is inside inventory.
        /// </summary>
        public bool inInventory
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.inInventory) != 1;
            set => MCM.writeInt(addr + SDK_PS_Offsets.inInventory, value ? 1 : 5);
        }

        /// <summary>
        /// Set your gamemode via an enum
        /// </summary>
        public Gamemode gamemode
        {
            get
            {
                ulong gm = MCM.readInt64(addr + SDK_PS_Offsets.Gamemode_Hex);
                if (gm == 0)
                    return Gamemode.Survival;
                if (gm == 1 * 4294967296)
                    return Gamemode.Creative;
                if (gm == 2 * 4294967296)
                    return Gamemode.Adventure;
                return Gamemode.Emtpy;
            }
            set => MCM.writeInt64(addr + SDK_PS_Offsets.Gamemode_Hex, (ulong)value * 4294967296);
        }

        /// <summary>
        /// Exact blocks traveled (Float)
        /// </summary>
        public float blocksTraveled_Ex
        {
            get => MCM.readFloat(addr + SDK_PS_Offsets.BlocksTraveled_Ex_Hex);
            set => MCM.writeFloat(addr + SDK_PS_Offsets.BlocksTraveled_Ex_Hex, value);
        }

        /// <summary>
        /// Blocks Traveled
        /// </summary>
        public int blocksTraveled
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.BlocksTraveled_Hex);
            set => MCM.writeInt(addr + SDK_PS_Offsets.BlocksTraveled_Hex, value);
        }

        /// <summary>
        /// Returns how many ticks sinse you joined the world
        /// </summary>
        public int worldAge
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.WorldAge_Hex);
            set => MCM.writeInt(addr + SDK_PS_Offsets.WorldAge_Hex, value);
        }

        /// <summary>
        /// Returns the name of the current dimension
        /// </summary>
        public string dimension
        { get => MCM.readString(MCM.baseEvaluatePointer(SDK_PS_Offsets.localPlayer, MCM.ceByte2uLong(SDK_PS_Offsets.localPlayer_offsets + SDK_PS_Offsets.gameDim_offsets)), 16); }

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
        public void setPos(Vec3 vec)
        {
            playerAABB.AA.x = vec.x;
            playerAABB.BB.x = vec.x + 0.6f;
            playerAABB.AA.y = vec.y;
            playerAABB.BB.y = vec.y + 1.8f;
            playerAABB.AA.z = vec.z;
            playerAABB.BB.z = vec.z + 0.6f;
        }
        /// <summary>
        /// External setPos function
        /// </summary>
        /// <param name="vec">Vector3</param>
        public void setPos(Vec3i vec)
        {
            playerAABB.AA.x = vec.x;
            playerAABB.BB.x = vec.x + 0.6f;
            playerAABB.AA.y = vec.y;
            playerAABB.BB.y = vec.y + 1.8f;
            playerAABB.AA.z = vec.z;
            playerAABB.BB.z = vec.z + 0.6f;
        }

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

        #region Custom voids
        /// <summary>
        /// Returns a list of every entity in render distance
        /// </summary>
        /// <returns></returns>
        public List<LocalPlayer> getRawEntities()
        {
            List<LocalPlayer> entityList = new List<LocalPlayer>();
            for (int i = 0; i < 0xFF; i++)
            {
                LocalPlayer entity = new LocalPlayer(MCM.baseEvaluatePointer(SDK_PS_Offsets.localPlayer, MCM.ceByte2uLong(SDK_PS_Offsets.localPlayer_EntityList_offsets + $"{(i * 8).ToString("X")} 0")));
                entityList.Add(entity);
            }
            return entityList;
        }

        /// <summary>
        /// Returns a list of every entity in render distance filtered out from empty entities
        /// </summary>
        /// <returns></returns>
        public List<LocalPlayer> getEntities()
        {
            List<LocalPlayer> entityList = new List<LocalPlayer>();
            for (int i = 0; i < 0xFF; i++)
            {
                LocalPlayer entity = new LocalPlayer(MCM.baseEvaluatePointer(SDK_PS_Offsets.localPlayer, MCM.ceByte2uLong(SDK_PS_Offsets.localPlayer_EntityList_offsets + $"{(i * 8).ToString("X")} 0")));
                if (entity.type.Length >= 3 && entity.username.Length >= 3 && !entity.isNull)
                    entityList.Add(entity);
            }
            return entityList;
        }

        /// <summary>
        /// Returns a list of minecraft entities of the class "Player"
        /// </summary>
        /// <returns></returns>
        public List<LocalPlayer> getPlayers() => getTypeEntities("player");

        /// <summary>
        /// Returns a list of minecraft entities of your customized class
        /// </summary>
        public List<LocalPlayer> getTypeEntities(string type)
        {
            List<LocalPlayer> entityList = new List<LocalPlayer>();
            for (int i = 0; i < 0xFF; i++)
            {
                LocalPlayer entity = new LocalPlayer(MCM.baseEvaluatePointer(SDK_PS_Offsets.localPlayer, MCM.ceByte2uLong(SDK_PS_Offsets.localPlayer_EntityList_offsets + $"{(i * 8).ToString("X")} 0")));
                if (entity.type == type && entity.username.Length >= 3 && entity.username != username && entity.playerAABB.AA.x != playerAABB.AA.x
                    && entity.playerAABB.AA.y != playerAABB.AA.y && entity.playerAABB.AA.z != playerAABB.AA.z && !entity.isNull)
                    entityList.Add(entity);
            }
            return entityList;
        }

        /// <summary>
        /// Returns the closest player
        /// </summary>
        public LocalPlayer getClosestPlayer() => getClosestEntity("player");

        /// <summary>
        /// Returns the closest custom entity
        /// </summary>
        public LocalPlayer getClosestEntity(string type)
        {
            var entList = getTypeEntities(type);

            List<double> distances = new List<double>();

            foreach (LocalPlayer currEnt in entList)
                distances.Add(currEnt.distanceTo(Minecraft.lp));

            if (distances.Count > 0)
            {
                distances.Sort();
                foreach (LocalPlayer ent in entList)
                    if (ent.distanceTo(Minecraft.lp) == distances[0]) return ent;
            }

            return (LocalPlayer)null;
        }

        /// <summary>
        /// Flares distanceTo function ported into YaamiSDK
        /// </summary>
        public double distanceTo(LocalPlayer e)
        {
            float dX = playerAABB.AA.x - e.playerAABB.AA.x;
            float dY = playerAABB.AA.y - e.playerAABB.AA.y;
            float dZ = playerAABB.AA.z - e.playerAABB.AA.z;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }

        /// <summary>
        /// worldToScreen externally
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Vec2 WorldToScreen(LocalPlayer entity, uint fov)
        {
            Vec3 delta = new Vec3(
                playerAABB.AA.x - entity.playerAABB.AA.x,
                playerAABB.AA.y - entity.playerAABB.AA.y,
                playerAABB.AA.z - entity.playerAABB.AA.z);

            float deltaX = delta.x;
            float deltaY = delta.y;
            float deltaZ = delta.z;

            deltaX = deltaX * (float)Math.Sin(bodyRots.y);
            deltaY = deltaY * (float)Math.Sin(bodyRots.x);
            deltaZ = deltaZ * (float)Math.Cos(bodyRots.y) * (float)Math.Cos(bodyRots.x);

            deltaX = (deltaX / deltaZ * fov) + 960;
            deltaY = (deltaY / deltaZ * fov) + 540;

            return new Vec2(deltaX, deltaY);
        }
        #endregion

        #region Defined Enums
        /// <summary>
        /// Gamemode enums for the local player
        /// </summary>
        public enum Gamemode
        {
            Survival = 0x0,
            Creative = 0x1,
            Adventure = 0x2,
            Emtpy = 0x07,
        }
        #endregion
    }
}
