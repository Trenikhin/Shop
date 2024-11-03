namespace Game.Ui
{
	using System;
	using UniRx;
	using UnityEngine;
	using UnityEngine.UI;

	public interface IUiHudView
	{
		IObservable<Unit> OnShopClicked { get; }

		void ShowHide(bool showHide);
	}
	
	public class UiHudView : MonoBehaviour, IUiHudView
	{
		[SerializeField] Button _shopButton;

		public IObservable<Unit> OnShopClicked => _shopButton.OnClickAsObservable();
		
		public void ShowHide(bool showHide) => gameObject.SetActive(showHide);
	}
}