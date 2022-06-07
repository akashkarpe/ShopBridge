using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductMaster
    {
        ProductDBAccess productDBAccess;
        public ProductMaster()
        {
            productDBAccess = new ProductDBAccess();
        }
        public List<Product> GetProductList()
        {
            List<Product> lstProducts = new List<Product>();
            try
            {
                DataTable dtProduct = productDBAccess.GetAllProducts();
                lstProducts = (from DataRow dr in dtProduct.Rows
                          select new Product()
                          {
                              Id = Convert.ToInt32(dr["Id"]),
                              Name = Convert.ToString(dr["Name"]),
                              Description = Convert.ToString(dr["Description"]),
                              Price = Convert.ToDecimal(dr["Price"]),
                              IsActive = Convert.ToBoolean(dr["IsActive"]),
                              CreatedBy = Convert.ToString(dr["CreatedBy"]),
                              CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                              UpdatedBy = Convert.ToString(dr["UpdatedBy"]),
                              UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]),
                          }).ToList();
            }
            catch
            {
                throw;
            }
            return lstProducts;
        }

        public int InsertProduct(Product product)
        {
            int result = 0;
            try
            {
                result = productDBAccess.InsertProduct(product);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public int UpdateProduct(Product product)
        {
            int result = 0;
            try
            {
                result = productDBAccess.updateProduct(product);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public int DeleteProduct(int productId)
        {
            int result = 0;
            try
            {
                result = productDBAccess.DeleteProduct(productId);
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
