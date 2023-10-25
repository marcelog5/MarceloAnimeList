namespace Commom.DomainLayer.Query
{
    public interface IQueryResult<TResponse>
    {
        public bool Sucess { get; set; }
        public TResponse? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
    }
}
