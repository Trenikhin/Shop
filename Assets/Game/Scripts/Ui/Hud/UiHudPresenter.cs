namespace Game.Ui
{
	using System;
	using UniRx;
	using Zenject;

	public class UiHudPresenter : IInitializable, IDisposable
	{
		[Inject] IUiNavigator _uiNavigator;
		[Inject] IUiHudView _view;
		
		CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			// Open / Close screen
			_uiNavigator.Screen
				.Select( s => s == EScreen.HUD )
				.Subscribe(s => _view.ShowHide( s ) )
				.AddTo( _disposables );
			
			_view.OnShopClicked
				.Subscribe( _ => _uiNavigator.Open( EScreen.Shop ) )
				.AddTo( _disposables );
		}

		public void Dispose() => _disposables?.Dispose();
	}
}