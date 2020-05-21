using WebApp.Common.Enums;

namespace WebApp.Common
{
    public abstract class BaseSingle  
    {
        public CatalogType CatalogId { get; set; }
    }

    public class CatalogRequest 
    {
        public dynamic Catalog { get; set; }
        public int CatalogId { get; set; }

    }


}
