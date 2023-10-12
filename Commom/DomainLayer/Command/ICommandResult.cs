﻿namespace CarRare.Commom.DomainLayer.Command
{
    public interface ICommandResult<TResponse>
    {
        public bool Sucess { get; set; }
        TResponse? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
    }
}