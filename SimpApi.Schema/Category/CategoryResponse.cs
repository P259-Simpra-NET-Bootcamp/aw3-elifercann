using SimpApi.Entities.BaseEntity;

namespace SimpApi.Schema;

public class CategoryResponse : BaseResponse
{
    public string Name { get; set; }
    public int Order { get; set; }

    public List<ProductResponse> Products { get; set; }=new List<ProductResponse>();
}

