/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

namespace OpenNos.DAL.EF.MySQL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NpcMonster
    {
        #region Instantiation

        public NpcMonster()
        {
            Drop = new HashSet<Drop>();
            MapMonster = new HashSet<MapMonster>();
            MapNpc = new HashSet<MapNpc>();
            NpcMonsterSkill = new HashSet<NpcMonsterSkill>();
        }

        #endregion

        #region Properties

        public byte AttackClass { get; set; }

        public byte AttackUpgrade { get; set; }

        public byte BasicArea { get; set; }

        public short BasicCooldown { get; set; }

        public byte BasicRange { get; set; }

        public short BasicSkill { get; set; }

        public short CloseDefence { get; set; }

        public short Concentrate { get; set; }

        public byte CriticalLuckRate { get; set; }

        public short CriticalRate { get; set; }

        public short DamageMaximum { get; set; }

        public short DamageMinimum { get; set; }

        public sbyte DarkResistance { get; set; }

        public short DefenceDodge { get; set; }

        public byte DefenceUpgrade { get; set; }

        public short DistanceDefence { get; set; }

        public short DistanceDefenceDodge { get; set; }

        public virtual ICollection<Drop> Drop { get; set; }

        public byte Element { get; set; }

        public short ElementRate { get; set; }

        public sbyte FireResistance { get; set; }

        public byte HeroLevel { get; set; }

        public bool IsHostile { get; set; }

        public int JobXP { get; set; }

        public byte Level { get; set; }

        public sbyte LightResistance { get; set; }

        public short MagicDefence { get; set; }

        public virtual ICollection<MapMonster> MapMonster { get; set; }

        public virtual ICollection<MapNpc> MapNpc { get; set; }

        public int MaxHP { get; set; }

        public int MaxMP { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public bool NoAggresiveIcon { get; set; }
        public virtual ICollection<NpcMonsterSkill> NpcMonsterSkill { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short NpcMonsterVNum { get; set; }

        public int RespawnTime { get; set; }
        public byte Speed { get; set; }
        public sbyte WaterResistance { get; set; }
        public int XP { get; set; }
        public bool IsMapObject { get; set; }

        #endregion
    }
}