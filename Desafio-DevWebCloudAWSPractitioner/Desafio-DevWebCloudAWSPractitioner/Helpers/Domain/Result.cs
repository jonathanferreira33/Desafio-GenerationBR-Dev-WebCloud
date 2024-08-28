namespace Desafio_DevWebCloudAWSPractitioner.Helpers.Domain
{
    public class Result<T>
    {
        public int statusCode
        {
            get;
            set;
        }

        public string msg
        {
            get;
            set;
        }

        public T data
        {
            get;
            set;
        }


        public Result(T data, string msg, int statusCode)
        {
            this.data = data;
            this.msg = msg;
            this.statusCode = statusCode;
        }

        public Result(T data, int statusCode)
        {
            this.data = data;
            this.statusCode = statusCode;
        }

        public Result(string msg, int statusCode)
        {
            this.msg = msg;
            this.statusCode = statusCode;
        }
    }
}
