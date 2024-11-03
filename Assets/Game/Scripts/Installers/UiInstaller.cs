namespace Game.Installers
{
	using Configs;
	using Factories;
	using Ui;
	using UnityEngine;
	using Zenject;

	public class UiInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindCore();
			
			BindHud();
			BindShop();
		}

		void BindCore()
		{
			Container
				.Bind<UiModel>()
				.AsSingle();
			
			Container
				.BindInterfacesTo<UiNavigator>()
				.AsSingle();
		}
		
		void BindHud()
		{
			BindInterfaces<UiHudPresenter>();
			BindFromHierarchy<UiHudView>();
		}
		
		void BindShop()
		{
			BindInterfaces<UiShopPresenter>();
			BindFromHierarchy<UiShopView>();
			BindInterfaces<ShopPurchaser>();
			
			Container
				.BindFactory< ShopBundleConfig, Transform, IUiShopBundleView, UiShopBundleView.Factory >()
				.FromFactory< ShopCardFactory >();
		}

		void BindInterfaces<T>()
		{
			Container
				.BindInterfacesTo<T>()
				.AsSingle();
		}
		
		void BindFromHierarchy<T>()
		{
			Container
				.BindInterfacesTo<T>()
				.FromComponentInHierarchy()
				.AsSingle();
		}
	}
}