namespace KGSBrowseMVC.Models
{
    public class Model
    {
        private string ReturnedValue { set; get; }

        public Model()
        {
            ReturnedValue = "Empty Model";
        }
        public Model(string message)
        {
            ReturnedValue = message;
        }
    }
}