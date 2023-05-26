using SimpApi.Entities.BaseEntity;

namespace SimpApi.Schema;

public class CategoryRequest : BaseRequest
{
    public string Name { get; set; }
    public int Order { get; set; }
   
    public List<ProductRequest> Products { get; set; }=new List<ProductRequest>();
}

