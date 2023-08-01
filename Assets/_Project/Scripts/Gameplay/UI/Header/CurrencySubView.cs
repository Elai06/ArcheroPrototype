using _Project.Scripts.Gameplay.Models.Resource;
using Infrastructure.Windows.MVVM.SubView;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Gameplay.UI.Header
{
    public class CurrencySubView : SubView<CurrencyData>
    {
        [SerializeField] private TextMeshProUGUI _valueText;
        
        public override void Initialize(CurrencyData data)
        {
            _valueText.text = data.Amount.ToString();
        }
    }
}