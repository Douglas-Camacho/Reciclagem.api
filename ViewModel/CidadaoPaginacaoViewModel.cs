using Reciclagem.api.Models;
using Reciclagem.api.ViewModel;

namespace Reciclagem.api.ViewModel
{
    public class CidadaoPaginacaoViewModel
    {
        public IEnumerable<CidadaoViewModel> Cidadaos { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public string PreviousPageUrl => HasPreviousPage ? $"/Cidadao?pagina={CurrentPage - 1}&amp;tamanho={PageSize}" : "";
        public string NextPageUrl => HasPreviousPage ? $"/Cidadao?pagina={CurrentPage - 1}&amp;tamanho={PageSize}" : "";
    }

    public class ClientePaginacaoReferenciaViewModel
    { 
        public IEnumerable<CidadaoViewModel> Cidadaos { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Cidadao?referencia={Ref}&amp;tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Cidadao?referencia={NextRef}&amp;tamanho={PageSize}" : "";
    }
}
