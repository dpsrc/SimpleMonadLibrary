using System;

namespace SuccessOrFailureMonadLibrary
{
    public class SuccessOrFailure<TFailure, TSuccess>
    {
        #region Private fields
        private readonly TFailure failure;
        private readonly TSuccess success;

        private readonly bool isFailureSet;
        private readonly bool isSuccessSet;
        #endregion

        private SuccessOrFailure(TFailure failure)
        {
            this.failure = failure;
            this.isFailureSet = true;
            this.isSuccessSet = false;
        }

        private SuccessOrFailure(TSuccess success)
        {
            this.success = success;
            this.isSuccessSet = true;
            this.isFailureSet = false;
        }

        protected SuccessOrFailure() { }

        public static SuccessOrFailure<TFailure, TSuccess> CreateFailure(TFailure failure) =>
            new SuccessOrFailure<TFailure, TSuccess>(failure);

        public static SuccessOrFailure<TFailure, TSuccess> CreateSuccess(TSuccess success) =>
            new SuccessOrFailure<TFailure, TSuccess>(success);

        public TResult ClassifyAs<TResult>(Func<TFailure, TResult> classifyFailure, Func<TSuccess, TResult> classifySuccess)
        {
            if (this.isFailureSet)
            {
                return classifyFailure(this.failure);
            }

            if (this.isSuccessSet)
            {
                return classifySuccess(this.success);
            }

            // TODO: how to get rid of having to throw this exception here
            throw new InvalidOperationException("Neither failure nor success is initialized.");
        }
    }
}
