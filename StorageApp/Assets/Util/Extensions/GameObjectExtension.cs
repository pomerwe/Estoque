using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class GameObjectExtensions
{
    //<summary>
    //Return the first component that implements IModelComponentBase in provided GameObject
    //</summary>
    public static IModelComponentBase GetModelComponentBase(this GameObject gameObject)
    {
        Component[] components = gameObject.GetComponents<Component>();
        IModelComponentBase componentBase = null; 
        
        for(int i = 0; i < components.Length; i++)
        {
            var c = components[i];
            if (c is IModelComponentBase)
            {
                componentBase = c as IModelComponentBase;
                break;
            }
        }

        if(componentBase == null)
        {
            throw new Exception("Não há um IModelComponentBase nesse gameObject!");
        }
        else
        {
            return componentBase;
        }
    }
}
