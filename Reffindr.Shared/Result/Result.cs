using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Shared.Result;
public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }

    protected Result(bool isSuccess, string error)
    {
        if (isSuccess && error != string.Empty)
            throw new ValidationException();
        if (!isSuccess && error == string.Empty)
            throw new ValidationException();

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Failure(string error) => new Result(false, error);
    public static Result Success() => new Result(true, string.Empty);
}

public class Result<T> : Result
{
    public T Value { get; }

    protected Result(bool isSuccess, string error, T value)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static new Result<T> Failure(string error) => new Result<T>(false, error, default!);
    public static Result<T> Success(T value) => new Result<T>(true, string.Empty, value);
}
