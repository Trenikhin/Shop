namespace Game.Factories
{ 
	using Configs;
	using Ui;
	using UnityEngine;
	using Zenject;

	public class ShopCardFactory : IFactory<ShopBundleConfig, Transform, IUiShopBundleView>
	{
		[Inject] PrefabsConfig _prefabsConfig;
		[Inject] DiContainer _container;
		
		public IUiShopBundleView Create(ShopBundleConfig param1, Transform param2)
		{
			var template = _prefabsConfig.ShopBundle;
			DiContainer subContainer = _container.CreateSubContainer();
			
			subContainer.BindInstance( param1 );

			IUiShopBundleView view = subContainer.InstantiatePrefabForComponent< IUiShopBundleView >( template, param2 );

			return view;
		}
	}
}