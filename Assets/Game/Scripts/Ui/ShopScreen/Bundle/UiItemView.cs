namespace Game.Ui
{
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class UiItemView : MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI _amount;
		[SerializeField] Image _icon;

		public void Init( Sprite icon, string amount )
		{
			_amount.text = amount;
			_icon.sprite = icon;
		}
	}
}