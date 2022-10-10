namespace TestServer
{
    public static class Constants
    {
        public const string DEFAULT_ADDR = "http://localhost:8989/";

        public const int ERR_CODE = -1;     //will be returned instead of a valid record id, if the record isn't found or an error occured

        public const int STATUS_ACCEPTED = 1;
        public const int STATUS_CANCELLED = 2;
    }
}
