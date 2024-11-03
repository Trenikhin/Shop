namespace Game.Configs
{
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using UnityEngine;

	[CreateAssetMenu(fileName = "CardConfig", menuName = "Configs/Ui/ShopCard", order = (int)EConfig.Ui)]
	public class ShopBundleConfig : ScriptableObject
	{
		public string Title;
		public string Description;
		public Sprite Icon;
		
		public List<StackConfig> Items;
		
		public int Price;
		
		[Range(0, 100)]
		public int Discount;
		
		public float DiscountPercent => Discount / 100f;

		void OnValidate()
		{
			while (Items.Count < 3)
				Items.Add(null);
			
			if (Items.Count > 6)
				Items.RemoveRange(6, Items.Count - 6);
		}
	}

	[System.Serializable]
	public class StackConfig
	{
		public ItemConfig Item;
		public int Amount;
	}
}