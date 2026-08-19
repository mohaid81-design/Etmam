using System;

namespace Data
{
    /// <summary>
    /// Thrown by SqlDataHelper{T}.EditAsync when the row's RowVersion no longer matches the value
    /// the caller expected (see the "RowVersion" property convention there) — i.e. another user/session
    /// saved changes to this same record after it was loaded here.
    /// </summary>
    public class ConcurrencyConflictException : Exception
    {
        public ConcurrencyConflictException(string message) : base(message) { }
    }
}
