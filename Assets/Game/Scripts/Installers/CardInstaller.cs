namespace Game.Ui
{
	using Configs;
	using Zenject;

	public class CardInstaller : MonoInstaller
	{
		[Inject] ShopBundleConfig _config;
		
		public override void InstallBindings()
		{
			Container
				.BindInterfacesTo<UiShopBundlePresenter>()
				.AsSingle();
			
			Container
				.BindInterfacesTo<UiShopBundleView>()
				.FromComponentInHierarchy()
				.AsSingle();
			
			// Config
			Container.BindInstance( _config );
		}
	}
}