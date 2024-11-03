namespace Game.Configs
{
	using Core;
	using UnityEngine;
	
	[CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/Core/Item", order = (int)EConfig.Core)]
	public class ItemConfig: ScriptableObject
	{
		public string Name;
		public Sprite Icon;

		public Item Get() => new Item(Name);
	}
}