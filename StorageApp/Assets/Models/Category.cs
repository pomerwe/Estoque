using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Category : IModelBase
{
    [PrimaryKey, AutoIncrement]
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageBase64 { get; set; }
}
