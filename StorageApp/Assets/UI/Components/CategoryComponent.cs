using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryComponent : MonoBehaviour, IModelComponentBase
{
    public Text categoryTitle;
    public Image categoryImage;

    public Category category;
    public void SetModel(IModelBase model)
    {
        if(model is Category)
        {
            category = model as Category;
            categoryTitle.text = category.Name;
            categoryImage.sprite = category.ImageBase64.GetSpriteFromBase64();
        }
        else
        {
            throw new ArgumentException("Não pode adicionar model sem ser Category nesse prefab!");
        }
    }
}
