using System;
using Infrastructure.Windows.MVVM.SubView;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Gameplay.UI.Inventory.Guns
{
    public class GunsInventorySubView : SubView<GunsInventorySubViewData>
    {
        public event Action<GunsType> OnEquip;
        
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private TextMeshProUGUI _fireRateText;
        [SerializeField] private TextMeshProUGUI _equippedStatus;
        [SerializeField] private Image _gunsImage;
        [SerializeField] private Button _equipped;

        private GunsInventorySubViewData _data;
        
        public override void Initialize(GunsInventorySubViewData subViewData)
        {
            _data = subViewData;
            
            _nameText.text = subViewData.Type.ToString();
            _fireRateText.text = subViewData.FireRate;
            _damageText.text = subViewData.Damage;
            _equippedStatus.text = subViewData.IsEquipped ? "Equipped" : "Equip";
            _gunsImage.sprite = subViewData.Sprite;
        }

        private void OnEnable()
        {
            _equipped.onClick.AddListener(Equip);
        }

        private void OnDisable()
        {
            _equipped.onClick.RemoveListener(Equip);
        }

        private void Equip()
        {
            OnEquip?.Invoke(_data.Type);
        }
    }
}