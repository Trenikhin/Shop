namespace Game.Ui
{
	using UniRx;
	using Zenject;

	public interface IUiNavigator
	{
		IReadOnlyReactiveProperty<EScreen> Screen { get; }
		
		void Open(EScreen name);
	}
	
	public class UiNavigator : IUiNavigator, IInitializable
	{
		[Inject] readonly UiModel _uiModel;
		
		public IReadOnlyReactiveProperty<EScreen> Screen => _uiModel.Screen;
		
		public void Initialize()
		{
			// Set the default screen
			_uiModel.SetScreen(EScreen.HUD);
		}
		
		public void Open(EScreen name)
		{
			_uiModel.SetScreen(name);
		}
	}
}