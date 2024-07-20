namespace APICEP.Integracao.Response
{
    public class ViaCepResponse
    {
        public string Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public string? ibge { get; set;}
        public string? gid { get; set;}
        public string? siafi { get; set;}


    }
}
