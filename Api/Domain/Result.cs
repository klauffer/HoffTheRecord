namespace Domain
{
    /// <summary>
    /// object representing a scenario when the return type can be one of two options
    /// </summary>
    /// <typeparam name="TSuccess">the type for the left option</typeparam>
    /// <typeparam name="TFailure">the type for the right option</typeparam>
    public abstract class Result<TSuccess, TFailure>
    {
        /// <summary>
        /// match on any case of <see cref="Result{L,R}"/>
        /// </summary>
        /// <typeparam name="T">return type of each case of the match</typeparam>
        /// <param name="onLeft">the method to be ran if we are on the left path</param>
        /// <param name="onRight">the method to be ran if we are on the left path</param>
        /// <returns>returns an instance of <typeparamref name="T"/> </returns>
        public abstract T Match<T>(Func<TSuccess, T> onLeft, Func<TFailure, T> onRight);

        /// <summary>
        /// Implicit converters to allow for a return value of type <typeparamref name="TSuccess"/> to be instantiated into type <see cref="Result{L,R}"/>
        /// </summary>
        /// <param name="value">value of type <typeparamref name="TSuccess"/></param>
        public static implicit operator Result<TSuccess, TFailure>(TSuccess value) => new Result<TSuccess, TFailure>.Success(value);

        /// <summary>
        /// Implicit converters to allow for a return value of type <typeparamref name="TFailure"/> to be instantiated into type <see cref="Result{L,R}"/>
        /// </summary>
        /// <param name="value">value of type <typeparamref name="TFailure"/></param>
        public static implicit operator Result<TSuccess, TFailure>(TFailure value) => new Result<TSuccess, TFailure>.Failure(value);

        /// <summary>
        /// the left side of the <see cref="Result{L,R}"/>
        /// </summary>
        public sealed class Success : Result<TSuccess, TFailure>
        {
            private readonly TSuccess _left;

            /// <summary>
            /// constructor accepting required return value
            /// </summary>
            /// <param name="left">the value held by the Left answer</param>
            public Success(TSuccess left)
            {
                _left = left;
            }

            /// <inheritdoc/>
            public override T Match<T>(Func<TSuccess, T> onLeft, Func<TFailure, T> onRight) =>
                onLeft(_left);
        }

        /// <summary>
        /// the right side of the <see cref="Result{L,R}"/>
        /// </summary>
        public sealed class Failure : Result<TSuccess, TFailure>
        {
            private readonly TFailure _right;

            /// <summary>
            /// constructor accepting required return value
            /// </summary>
            /// <param name="right">the value held by the right answer</param>
            public Failure(TFailure right)
            {
                _right = right;
            }

            /// <inheritdoc/>
            public override T Match<T>(Func<TSuccess, T> onLeft, Func<TFailure, T> onRight) =>
                onRight(_right);
        }
    }
}