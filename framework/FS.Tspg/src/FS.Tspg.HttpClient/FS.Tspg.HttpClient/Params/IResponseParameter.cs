namespace FS.Tspg.HttpClient.Params
{
    public interface IResponseParameter
    {
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }

        public void Validate();
    }
}
