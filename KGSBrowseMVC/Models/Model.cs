namespace KGSBrowseMVC.Models
{
    public class Model
    {
        private string _returnedValue;

        private string ReturnedValue
        {
            set { _returnedValue = value; }
            get { return _returnedValue; }
        }

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