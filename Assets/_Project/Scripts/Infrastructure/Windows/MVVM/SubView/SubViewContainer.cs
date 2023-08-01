using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Windows.MVVM.SubView
{
    public class SubViewContainer<TSubView, TData> : MonoBehaviour where TSubView : SubView<TData>
    {
        public RectTransform Content;
        public TSubView SubViewPrefab;
        public Dictionary<string, TSubView> SubViews = new Dictionary<string, TSubView>();

        public void Add(string id, TData data)
        {
            TSubView subView;
            if (SubViews.TryGetValue(id, out TSubView view))
            {
                subView = view;
            }
            else
            {
                subView = Instantiate(SubViewPrefab, Content);
                SubViews.Add(id, subView);
            }

            
            subView.Initialize(data);
        }

        public void CleanUp()
        {
            if (SubViews.Count > 0)
                foreach (var subView in SubViews.Values)
                    Destroy(subView.gameObject);

            SubViews.Clear();
        }

        public void Remove(string id)
        {
            if (SubViews.ContainsKey(id))
            {
                Destroy(SubViews[id].gameObject);
                SubViews.Remove(id);
            }
        }

        public void UpdateView(TData data, string id)
        {
            if (SubViews.ContainsKey(id))
            {
                SubViews[id].Initialize(data);
            }
            else
            {
                Add(id, data);
            }
        }
    }
}