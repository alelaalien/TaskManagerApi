﻿namespace TaskManager.Domain.Exceptions
{
    public class ServerException : Exception
    {
        public ServerException()   { }
        public ServerException(string message) : base(message) { }

    }
}
