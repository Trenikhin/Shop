namespace Game.Ui
{
	using UniRx;
	
	public class UiModel
	{
		ReactiveProperty<EScreen> _screen = new ReactiveProperty<EScreen>();
		
		public IReadOnlyReactiveProperty<EScreen> Screen => _screen;
		
		public void SetScreen( EScreen screen ) => _screen.Value = screen;
	}
}