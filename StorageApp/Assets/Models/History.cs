using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class History : IModelBase
{
    [PrimaryKey, AutoIncrement]
    public int HistoryId { get; set; }
    public DateTime When { get; set; }
    public ActionType ActionType { get; set; }
    public int Quantity { get; set; }
    public int ItemId { get; set; }

    [IgnoreAttribute]
    public Item Item { get; set; }
}

