namespace Game.Ui
{
	using System;
	using System.Linq;
	using Configs;
	using UniRx;
	using UnityEngine;
	using Zenject;

	public class UiShopBundlePresenter : IInitializable, IDisposable
	{
		[Inject] IShopPurchaser _shopPurchaser;
		[Inject] IUiShopBundleView _view;
		[Inject] ShopBundleConfig _cfg;
		
		CompositeDisposable _disposables = new CompositeDisposable();
		
		public void Initialize()
		{
			_view.OnBuyClicked
				.Subscribe( _ => HandlePurchasing() )
				.AddTo(_disposables);

			SetupCardView();
		}

		public void Dispose() => _disposables?.Dispose();

		void SetupCardView()
		{
			var price = _cfg.Price.ToString();
			var oldPrice = (_cfg.Price - (_cfg.Price * _cfg.DiscountPercent)).ToString();
			var discount = _cfg.Discount.ToString();
			
			_view.SetTitle( _cfg.Title );
			_view.SetDescription( _cfg.Description );
			_view.SetIcon(_cfg.Icon);
			
			_view.SetPrice( price );
			_view.SetOldPrice( oldPrice );
			_view.SetDiscountLabel( discount );
			
			_cfg.Items
				.ForEach( i =>
				{
					_view
						.CreateItem()
						.Init(i.Item.Icon, i.Amount.ToString());
				});
		}
		
		void HandlePurchasing()
		{
			var price = _cfg.Price;
			
			var purchasedItems = _cfg.Items
				.Select((item) => (item.Item.Get(), item.Amount))
				.ToList();
			
			_shopPurchaser.TryPurchase( price, purchasedItems );
		}
	}
}