namespace Game.Configs
{
	using Ui;
	using UnityEngine;

	[CreateAssetMenu(fileName = "Prefabs", menuName = "Configs/Core/Prefabs", order = (int)EConfig.Core)]
	public class PrefabsConfig : ScriptableObject
	{
		[Header("Ui")]
		public UiShopBundleView ShopBundle;
	}
}