namespace PrimeiraApi.Modals
{
    public class ServerResponse<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;

    }
}
