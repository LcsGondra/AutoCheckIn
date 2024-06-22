namespace AutoCheckIn.Domain.Aggregates
{
    public class Endereco
    {
        public string CEP { get; set; }
        public string Rua { get; set;}
        public int Numero { get; set;}
        public string Complemento { get; set;}
        public string Bairro { get; set;}
        public string Cidade { get; set;}
        public string Estado { get; set;}
    }
}