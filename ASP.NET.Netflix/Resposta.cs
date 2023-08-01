namespace ASP.NET.Netflix
{
    public class Resposta
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }

        public Resposta(int statusCode, string mensagem)
        {
            this.StatusCode = statusCode;
            this.Mensagem = mensagem;
        }
    }
}