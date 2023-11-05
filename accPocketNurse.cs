using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using pocketNurse;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework.Input;
using System;

namespace pocketNurse
{
	public class accPocketNurse : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pocket Nurse");
			Tooltip.SetDefault("Will heal you for money \n Press 'H' key");

		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 46;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.GreaterHealingPotion, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{

			int healingCost = 2 * (int)(player.statLifeMax - player.statLife);
			if (Main.myPlayer == player.whoAmI && HotkeyPressed() && enoughSilverCoins(player, healingCost) && healingCost > 0)

			{
				for (int i = healingCost; i > 0; i--)
				{

					player.ConsumeItem(ItemID.SilverCoin, false);
				}

				player.statLife = player.statLifeMax;
				player.ClearBuff(BuffID.Bleeding);
				player.ClearBuff(BuffID.Poisoned);
				player.ClearBuff(BuffID.PotionSickness);

				player.AddBuff(BuffID.Ironskin, 600);
				player.AddBuff(BuffID.Regeneration, 600);
				player.AddBuff(BuffID.Endurance, 600);

			}

		}
		private bool HotkeyPressed()
		{
			pocketNurseConfig config = ModContent.GetInstance<pocketNurseConfig>();
			Keys activationKey = config.AccessoryActivationKey;
			KeyboardState keyboardState = Keyboard.GetState();

			bool isHotKeyPressed = keyboardState.IsKeyDown(config.AccessoryActivationKey);

			return isHotKeyPressed;
		}
		private bool enoughSilverCoins(Player player, int itemAmount)
		{
			int itemCount = 0;
			if (player.HasItem(ItemID.SilverCoin))
			{
				for (int i = 0; i < player.inventory.Length; i++)
				{
					if (player.inventory[i].type == ItemID.SilverCoin)
					{
						itemCount += player.inventory[i].stack;
					}



				}
			}
			if (itemCount >= itemAmount)
				return true;
			else return false;


		}
	}
}