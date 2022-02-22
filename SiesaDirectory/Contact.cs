
namespace SiesaContact
{

    public class Contact
    {
        public string _name { get; set; }
        public string _landline { get; set; }
        public string _cellphone { get; set; }


        public Contact(string name, string landline, string cellphone)
        {
            _name = name;
            _landline = landline;
            _cellphone = cellphone;
        }

        // public string getNameContact() { return _name; }
        // public string getlandlineContact() { return _landline; }
        // public string getCellphoneContact() { return _cellphone; }
        // public void setNameContact(string name) { _name = name; }

    }

}