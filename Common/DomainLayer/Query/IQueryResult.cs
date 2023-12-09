namespace Common.DomainLayer.Query
{
    public interface IQueryResult<TResponse>
    {
        public bool Success { get; set; }
        public TResponse? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
    }
}
