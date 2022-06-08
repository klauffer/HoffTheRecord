namespace Domain
{
    /// <summary>
    /// object representing a scenario when the return type can be one of two options
    /// </summary>
    /// <typeparam name="TSuccess">the type for the success option</typeparam>
    public abstract class Result<TSuccess>
    {
        /// <summary>
        /// match on any case of <see cref="Result{L,R}"/>
        /// </summary>
        /// <typeparam name="T">return type of each case of the match</typeparam>
        /// <param name="onSuccess">the method to be ran if we are on the success path</param>
        /// <param name="onFailure">the method to be ran if we are on the Failure path</param>
        /// <returns>returns an instance of <typeparamref name="T"/> </returns>
        public abstract T Match<T>(Func<TSuccess, T> onSuccess, Func<Error, T> onFailure);

        /// <summary>
        /// Implicit converters to allow for a return value of type <typeparamref name="TSuccess"/> to be instantiated into type <see cref="Result{L,R}"/>
        /// </summary>
        /// <param name="value">value of type <typeparamref name="TSuccess"/></param>
        public static implicit operator Result<TSuccess>(TSuccess value) => new Result<TSuccess>.Success(value);

        /// <summary>
        /// Implicit converters to allow for a return value of type <typeparamref name="TFailure"/> to be instantiated into type <see cref="Result{L,R}"/>
        /// </summary>
        /// <param name="value">value of type <typeparamref name="TFailure"/></param>
        public static implicit operator Result<TSuccess>(Error value) => new Result<TSuccess>.Failure(value);

        /// <summary>
        /// the success side of the <see cref="Result{L,R}"/>
        /// </summary>
        public sealed class Success : Result<TSuccess>
        {
            private readonly TSuccess _success;

            /// <summary>
            /// constructor accepting required return value
            /// </summary>
            /// <param name="success">the value held by the Success answer</param>
            public Success(TSuccess success)
            {
                _success = success;
            }

            /// <inheritdoc/>
            public override T Match<T>(Func<TSuccess, T> onSuccess, Func<Error, T> onFailure) =>
                onSuccess(_success);
        }

        /// <summary>
        /// the failure side of the <see cref="Result{L,R}"/>
        /// </summary>
        public sealed class Failure : Result<TSuccess>
        {
            private readonly Error _error;

            /// <summary>
            /// constructor accepting required return value
            /// </summary>
            /// <param name="error">the value held by the failure answer</param>
            public Failure(Error error)
            {
                _error = error;
            }

            /// <inheritdoc/>
            public override T Match<T>(Func<TSuccess, T> onSuccess, Func<Error, T> onFailure) =>
                onFailure(_error);
        }
    }
}