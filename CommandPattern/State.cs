using CommandPattern.Interfaces;

namespace CommandPattern
{
    public class State : IState
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public State(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}