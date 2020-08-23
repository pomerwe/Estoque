using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CategoryAdapter : BaseAdapter
{
    public GameObject categoryContent;
    public GameObject categoryPrefab;


    public void Awake()
    {
        SetAdapter(categoryContent, categoryPrefab);
    }

    public void AddCategoriesToContent(List<Category> categories)
    {
        categories.ForEach(c =>
        {
            AddToContent(c);
        });
    }

    public override void RemoveFromContent(IModelBase model)
    {
        var categoryView = contentPrefabObjectList
                        .Where(c => (c as CategoryComponent).category.CategoryId ==(model as Category).CategoryId)
                        .FirstOrDefault() as CategoryComponent;

        var index = contentPrefabObjectList.IndexOf(categoryView);
        
        Destroy(categoryView.gameObject);
        contentPrefabObjectList.RemoveAt(index);
    }
}
