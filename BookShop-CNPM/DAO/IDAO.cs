﻿using System.Data;

namespace BookShop_CNPM.DAO
{
    public interface IDAO<T>
    {
        DataTable getAll();
        T getById(string id);
        bool insert(T data);
        bool update(T data);
        bool delete(string id);
    }
}
