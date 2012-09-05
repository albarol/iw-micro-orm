namespace IwMicroOrm.Core.Query.SelectQuery.Joins
{
    using System;

    public class InvalidJoinException : SystemException
    {
        public InvalidJoinException(string message)
            : base(message)
        {
        }
    }
}
