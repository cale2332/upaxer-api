using System.Collections.Generic;

namespace WebApp.Services.DataTransferObjects.Responses
{

    public class ResultCatalogResponse<T>
	{
		public List<T> Catalog { get; set; }
		public int Total { get; set; }
	}

    public class ResultEnumResponse
    {
        public List<EnumResponse> Catalog { get; set; }
    }

    public class EnumResponse
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }

}
