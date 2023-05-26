using SimpApi.Entities.BaseEntity;
using SimpApi.Entities.Model;

namespace SimpApi.Schema;

public class ProductResponse : BaseResponse
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Tag { get; set; }

}
