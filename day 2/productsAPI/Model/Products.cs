namespace productsAPI.Model
{
    public class Product
    {
        #region Properties
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }
        public bool pIsInstock { get; set; }
        #endregion

        #region Get Methods
        static List<Product> pList = new List<Product>()
        {
            new Product(){ pId=101, pName="Pepsi", pCategory="Cold-Drink", pIsInstock=true, pPrice=50},
            new Product(){ pId=102, pName="Iphone", pCategory="Electronics", pIsInstock=false, pPrice=150000},
            new Product(){ pId=103, pName="Air-Pods", pCategory="Electronics", pIsInstock=true, pPrice=27000},
            new Product(){ pId=104, pName="IWatch", pCategory="Electronics", pIsInstock=true, pPrice=49000},
            new Product(){ pId=105, pName="Fanta", pCategory="Cold-Drink", pIsInstock=false, pPrice=75}
        };


        public List<Product> GetALlProducts()
        {
            return pList;
        }

        public List<Product> GetProductByCategory(string category)
        {
            var p = pList.FindAll(pr => pr.pCategory == category);
            return p;
        }

        public Product GetProductById(int id)
        {
            var p = pList.Find(pr => pr.pId == id);
            if (p != null)
            {
                return p;
            }
            throw new Exception("Product Not Found");
        }

        public List<Product> GetProductByAvability(bool para)
        {
            var p = pList.FindAll(pr => pr.pIsInstock == para);
            return p;
        }
        #endregion

        #region Add, Delete and Update
        public string AddNewProduct(Product newProduct)
        {//do data validation
            pList.Add(newProduct);
            return "Product Added Successfully";
        }

        public string DeleteProduct(int pid)
        {
            var p = pList.Find(pr => pr.pId == pid);
            if (p!=null)
            {
                pList.Remove(p);
                return "Product Removed Successfully";
            }
            throw new Exception("Product Not Found");
        }

        public string EditProduct(Product changes)
        {
            var p = pList.Find(pr => pr.pId == changes.pId);
            if (p != null)
            {
                p.pName = changes.pName;
                p.pCategory = changes.pCategory;
                p.pPrice = changes.pPrice;
                p.pIsInstock = changes.pIsInstock;
                return "Product Updated";
            }
            throw new Exception("Product Not Found");
        }
        #endregion
    }
}
















