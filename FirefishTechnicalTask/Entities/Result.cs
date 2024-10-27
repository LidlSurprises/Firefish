using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Routing.Template;

namespace FirefishTechnicalTaskAPI.Entities
{
    public enum ResultState
    {
        Faulted,
        Success
    }
    public readonly struct Result<TValue>
    {
        internal readonly TValue? value;
        internal readonly ResultState State;
        internal readonly Exception? error;

        public readonly bool IsFaulted => State == ResultState.Faulted;
        public readonly TValue? Value => value;
        public readonly Exception? Error => error;

        public Result(TValue value)
        {
            this.value = value;
            error = null;
            State = ResultState.Success;
        }

        public Result(Exception error)
        {
            value = default;
            this.error = error;
            State = ResultState.Faulted;
        }

        public TResult Match<TResult>(Func<TValue?, TResult> Success, Func<Exception?, TResult> Fail) =>
            IsFaulted ? Fail(error) : Success(value);

        public static implicit operator TValue(Result<TValue> result) => (TValue)result;
        public static implicit operator Result<TValue>(TValue value) => new(value);

        public static implicit operator Exception?(Result<TValue> result) => result.error;
        public static implicit operator Result<TValue>(Exception error) => new(error);
    }
}
