namespace Admin.App.ViewModels
{
    public class ReturnViewModel
    {
        public ReturnViewModel(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
    }
}
