using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SQLIteService : MonoBehaviour
{
    private static SQLIteService sqliteService;
    public static SQLIteService Instance
    {
        get
        {
            if (sqliteService == null)
            {
                sqliteService = FindObjectOfType<SQLIteService>();
            }
            return sqliteService;
        }
    }


    public void Start()
    {
        var ds = DataService.GetDataServiceInstance();
        ds.CreateDB();
    }

    #region Item
    public Item GetItem(int itemId)
    {
        var ds = DataService.GetDataServiceInstance();
        return ds.con.Table<Item>().Where(i => i.ItemId == itemId).SingleOrDefault();
    }

    public List<Item> GetItens()
    {
        var ds = DataService.GetDataServiceInstance();
        return ds.con.Table<Item>().ToList();
    }

    public Item SaveItem(Item item)
    {
        var ds = DataService.GetDataServiceInstance();
        return ds.Insert(item);
    }

    public void UpdateItem(Item item)
    {
        var ds = DataService.GetDataServiceInstance();
        ds.Update(item);
    }

    public void DeleteItem(Item item)
    {
        var ds = DataService.GetDataServiceInstance();
        ds.Delete(item);
    }
    #endregion


    #region Category
    public Category GetCategory(int categoryId)
    {
        var ds = DataService.GetDataServiceInstance();
        return ds.con.Table<Category>().Where(c => c.CategoryId == categoryId).SingleOrDefault();
    }

    public List<Category> GetCategories()
    {
        var ds = DataService.GetDataServiceInstance();
        return ds.con.Table<Category>().ToList();
    }

    public Category SaveCategory(Category category)
    {
        var ds = DataService.GetDataServiceInstance();
        return ds.Insert(category);
    }

    public void UpdateItem(Category category)
    {
        var ds = DataService.GetDataServiceInstance();
        ds.Update(category);
    }

    public void DeleteItem(Category category)
    {
        var ds = DataService.GetDataServiceInstance();
        ds.Delete(category);
    }
    #endregion

    #region History
    public History GetHistory(int historyId)
    {
        var ds = DataService.GetDataServiceInstance();

        History history = ds.con.Table<History>().Where(h => h.HistoryId == historyId).SingleOrDefault();
        history.Item = ds.con.Table<Item>().SingleOrDefault(i => i.ItemId == history.ItemId);

        return history;
    }

    public List<History> GetAllHistory()
    {
        var ds = DataService.GetDataServiceInstance();
        return ds.con.Table<History>().ToList();
    }

    public History SaveItem(History history)
    {
        var ds = DataService.GetDataServiceInstance();
        return ds.Insert(history);
    }

    public void UpdateItem(History history)
    {
        var ds = DataService.GetDataServiceInstance();
        ds.Update(history);
    }

    public void DeleteItem(History history)
    {
        var ds = DataService.GetDataServiceInstance();
        ds.Delete(history);
    }
    #endregion
}
