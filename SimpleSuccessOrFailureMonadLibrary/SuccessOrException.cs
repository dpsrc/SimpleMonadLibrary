using System;

namespace SuccessOrFailureMonadLibrary
{
    public class SuccessOrException<TSuccess> : SuccessOrFailure<Exception, TSuccess>
    {
        protected SuccessOrException() { }
    }
}
