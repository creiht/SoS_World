using System;
using Server;

namespace Server.Items
{
	public class ArmsOfNobility : RingmailArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061092; } } // Arms of Nobility

		public override int BasePhysicalResistance{ get{ return 20; } }
		public override int BasePoisonResistance{ get{ return 22; } }

		[Constructable]
		public ArmsOfNobility()
		{
			Name = "Arms of Nobility";
			Hue = 0x4FE;
			Attributes.BonusStr = 8;
			Attributes.Luck = 100;
			Attributes.WeaponDamage = 20;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public ArmsOfNobility( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_ArmsOfNobility(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( Hue == 0x562 )
					Hue = 0x4FE;

				PhysicalBonus = 0;
				PoisonBonus = 0;
			}
		}
	}
}