using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DBHelper;
using System.Data;

namespace DataAccessLayer
{
    public class ProductDBAccess
    {
        private DataAccessLayer.DBHelper.DBHelper dbHelper;
        public ProductDBAccess()
        {
            dbHelper = new SQLHelper();
        }
        public int InsertProduct(Product product)
        {
            int result = 0;
            string query = string.Empty;
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"INSERT INTO Products(Name,Description,Price,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn)
                                values(@Name,@Description,@Price,@IsActive,@CreatedBy,@CreatedOn,@UpdatedBy,@UpdatedOn)";
                keyValuePairs.Add("@Name", product.Name);
                keyValuePairs.Add("@Description", product.Description);
                keyValuePairs.Add("@Price", product.Price);
                keyValuePairs.Add("@IsActive", product.IsActive);
                keyValuePairs.Add("@CreatedBy", product.CreatedBy);
                keyValuePairs.Add("@CreatedOn", DateTime.Now);
                keyValuePairs.Add("@UpdatedBy", product.CreatedBy);
                keyValuePairs.Add("@UpdatedOn", DateTime.Now);
                result = dbHelper.ExecuteNonQuery(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public int updateProduct(Product product)
        {
            int result = 0;
            string query = string.Empty;
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"UPDATE Products set Name=@Name,Description=@Description,Price=@Price,IsActive=@IsActive,UpdatedBy=@UpdatedBy,UpdatedOn=@UpdatedOn 
                                    where Id=@Id";
                keyValuePairs.Add("@Id", product.Id);
                keyValuePairs.Add("@Name", product.Name);
                keyValuePairs.Add("@Description", product.Description);
                keyValuePairs.Add("@Price", product.Price);
                keyValuePairs.Add("@IsActive", product.IsActive);
                keyValuePairs.Add("@UpdatedBy", product.UpdatedBy);
                keyValuePairs.Add("@UpdatedOn", DateTime.Now);
                result = dbHelper.ExecuteNonQuery(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public DataTable GetAllProducts()
        {
            DataTable symptsList = new DataTable();
            string query = string.Empty;
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"SELECT Id,Name,Description,Price,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn from Products;";
                symptsList = dbHelper.GetDataSet(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return symptsList;
        }

        public int DeleteProduct(int ProductId)
        {
            int result = 0;
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                dbHelper.Query = @"DELETE FROM Products WHERE Id=@Id";
                keyValuePairs.Add("@Id", ProductId);
                result = dbHelper.ExecuteNonQuery(keyValuePairs);
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
