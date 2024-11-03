namespace Game.Installers
{
	using Core;
	using Zenject;

	public class CoreInstaller: MonoInstaller
	{
		public override void InstallBindings()
		{
			Container
				.BindInterfacesAndSelfTo<Money>()
				.AsSingle();
			
			Container
				.BindInterfacesAndSelfTo<Inventory>()
				.AsSingle();
		}
	}
}