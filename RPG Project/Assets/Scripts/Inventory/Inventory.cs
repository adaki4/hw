using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region  Singleton
    public static Inventory instance;

    void Awake() {
        if (instance  != null ) {
            Debug.LogWarning("More inventories instances found");
        }
        else {
            instance = this;
        }
    }
    #endregion
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public List<Item> items = new List<Item>();
    public int maxItemCount;
    public bool Add(Item item) {
        if (!item.isDefaultItem) {
            if (items.Count >= maxItemCount) {
                Debug.Log("Max inventory space reached");
                return false;
            }
            
            items.Add(item);
            if (onItemChangedCallBack != null) {
                onItemChangedCallBack.Invoke();
            }
        }
        return true;
    }
    public void Remove(Item item) {
        items.Remove(item);
        if (onItemChangedCallBack != null) {
            onItemChangedCallBack.Invoke();
        }
    }
}
