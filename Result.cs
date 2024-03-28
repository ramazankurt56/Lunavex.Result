using Lunavex.Result;

namespace Lunavex.Result;
public sealed class Result<T>
{
    public T? Data { get; set; }

    public List<string>? ErrorMessages { get; set; }
    public string? ErrorMessages2 { get; set; }

    public bool IsSuccessful { get; set; } = true;


    public int StatusCode { get; set; } = 200;


    public Result(T data)
    {
        Data = data;
    }
    public Result(int statusCode, List<string> errorMessages)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
    }

    public Result(int statusCode, string errorMessage)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = new List<string> { errorMessage };

    }

    public static implicit operator Result<T>(T data)=> new Result<T>(data);
   

    public static implicit operator Result<T>((int statusCode, List<string> errorMessages) parameters)=> new Result<T>(parameters.statusCode, parameters.errorMessages);
 

    public static implicit operator Result<T>((int statusCode, string errorMessage) parameters)=> new Result<T>(parameters.statusCode, parameters.errorMessage);


    public static Result<T> Succeed(T data) => new Result<T>(data);

    public static Result<T> Failure(int statusCode, List<string> errorMessages) => new Result<T>(statusCode, errorMessages);


    public static Result<T> Failure(int statusCode, string errorMessage) => new Result<T>(statusCode, errorMessage);

    public static Result<T> Failure(string errorMessage)=> new Result<T>(500, errorMessage);

    public static Result<T> Failure(List<string> errorMessages)=> new Result<T>(500, errorMessages);

}