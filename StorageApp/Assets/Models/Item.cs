using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Item
{
    [PrimaryKey, AutoIncrement]
    public int ItemId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Description { get; set; }
    public string ImageBase64 { get; set; }
    public float Value { get; set; }
    public DateTime Validity { get; set; }
    public int CategoryId { get; set; }
    public DateTime Deleted { get; set; }
}

