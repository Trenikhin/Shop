namespace Game.Ui
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Configs;
	using UniRx;
	using UnityEngine;
	using Zenject;

	public class UiShopPresenter: IInitializable, IDisposable
	{
		[Inject] IUiNavigator _uiNavigator;
		[Inject] iUiShopView _view;
		[Inject] ShopConfig _config;
		
		CompositeDisposable _disposables = new CompositeDisposable();
		
		List<IUiShopBundleView> _bundles = new List<IUiShopBundleView>();
		
		public void Initialize()
		{
			// Open / Close screen
			_uiNavigator.Screen
				.Select( s => s == EScreen.Shop )
				.Subscribe(s =>
				{
					if (s)
						DrawBundles();
					
					_view.ShowHide(s);
				})
				.AddTo( _disposables );
			
			_view.OnCloseClicked
				.Subscribe( _ => _uiNavigator.Open( EScreen.HUD ) )
				.AddTo( _disposables );

			_view.SetName( _config.ScreenName );
		}

		void DrawBundles()
		{
			_bundles.ForEach( i => _view.DestroyObj( i as UiShopBundleView ) );
			_bundles = _config.Cards
				.Select(c => _view.Create(c))
				.ToList();
		}

		public void Dispose() => _disposables?.Dispose();
	}
}