using System;

namespace SuccessOrFailureMonadLibrary
{
    public class SuccessOrFailure<TFailure, TSuccess>
    {
        private readonly TFailure failure;
        private readonly TSuccess success;

        private readonly bool isFailureSet;
        private readonly bool isSuccessSet;

        protected SuccessOrFailure() { }

        private SuccessOrFailure(TFailure failure)
        {
            this.failure = failure;
            isFailureSet = true;
            isSuccessSet = false;
        }

        private SuccessOrFailure(TSuccess success)
        {
            this.success = success;
            isSuccessSet = true;
            isFailureSet = false;
        }

        public static SuccessOrFailure<TFailure, TSuccess> CreateFailure(TFailure failure) =>
            new SuccessOrFailure<TFailure, TSuccess>(failure);

        public static SuccessOrFailure<TFailure, TSuccess> CreateSuccess(TSuccess success) =>
            new SuccessOrFailure<TFailure, TSuccess>(success);

        public TResult ClassifyAs<TResult>(Func<TFailure, TResult> classifyFailure, Func<TSuccess, TResult> classifySuccess)
        {
            if (isFailureSet)
            {
                return classifyFailure(failure);
            }

            if (isSuccessSet)
            {
                return classifySuccess(success);
            }

            // TODO: how to get rid of having to throw this exception here
            throw new InvalidOperationException("Neither failure nor success is initialized.");
        }
    }
}
