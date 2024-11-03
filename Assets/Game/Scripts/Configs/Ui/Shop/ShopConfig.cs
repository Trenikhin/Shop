namespace Game.Configs
{
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "ShopConfig", menuName = "Configs/Ui/Shop", order = (int)EConfig.Ui)]
	public class ShopConfig : UiScreenConfig
	{
		public List<ShopBundleConfig> Cards = new List<ShopBundleConfig>();
	}
}