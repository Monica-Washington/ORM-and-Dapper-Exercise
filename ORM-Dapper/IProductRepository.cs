namespace ORM_Dapper;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    
}