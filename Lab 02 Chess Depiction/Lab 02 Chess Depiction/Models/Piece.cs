namespace Lab_02_Chess_Depiction.Models
{
    public class Piece
    {
        private string _location;
        public string Location
        {
            get { return _location; }

            set { _location = value; }
        }

        public override string ToString()
        {
            return _location;
        }
    }
}
