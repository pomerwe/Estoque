using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseAdapter : MonoBehaviour
{
    private GameObject content;
    private GameObject prefab;
    public List<IModelComponentBase> contentPrefabObjectList;

    public void SetAdapter(GameObject content, GameObject prefab)
    {
        this.content = content;
        this.prefab = prefab;
        contentPrefabObjectList = new List<IModelComponentBase>();
    }

    //<summary>
    //Use the type of Class you need to add in content
    //</summary>
    public void AddRangeToContent(List<IModelBase> itemList)
    {
        itemList.ForEach(i =>
        {
            AddToContent(i);
        });
    }


    public void AddToContent(IModelBase item)
    {
        var prefabObject = Instantiate(prefab, content.transform, false);
        prefabObject.GetModelComponentBase();
        IModelComponentBase componentBase = prefab.GetModelComponentBase();
        componentBase.SetModel(item);
        contentPrefabObjectList.Add(componentBase);
    }
    public void ClearContent()
    {
        DestroyAllContentViews();
        contentPrefabObjectList.Clear();
    }

    private void DestroyAllContentViews()
    {
        foreach (GameObject g in content.transform)
        {
            Destroy(g);
        };
    }

    public abstract void RemoveFromContent(IModelBase model);
}

