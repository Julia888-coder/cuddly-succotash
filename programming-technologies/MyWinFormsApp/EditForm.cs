namespace MyWinFormsApp
{
    public partial class EditForm : Form
    {
        public int personId = 0;

        public EditForm(Person? person = null)
        {
            InitializeComponent();
            
            if (person != null)
            {
                personId = person.Id;
                textBoxName.Text = person.Name;
                textBoxSecondName.Text = person.SecondName;
                textBoxCity.Text = person.Address.City;
                numericUpDownAge.Value = person.Age;
                numericUpDownFlat.Value = person.Address.Flat;
            }
        }

        public Person GetPerson()
        {
            var address = new Address
            {
                City = textBoxCity.Text,
                Flat = Convert.ToInt32(numericUpDownFlat.Value)
            };
            return new Person()
            {
                Id = personId,
                Name = textBoxName.Text,
                SecondName = textBoxSecondName.Text,
                Age = Convert.ToInt32(numericUpDownAge.Value),
                Address = address
            };
        }

        private bool validatePerson(Person person)
        {
            return !string.IsNullOrEmpty(person.Name) &&
                !string.IsNullOrEmpty(person.SecondName) &&
                !string.IsNullOrEmpty(person.Address.City) &&
                person.Age > 0 &&
                person.Address.Flat > 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var person = GetPerson();
            if (validatePerson(person))
                DialogResult = DialogResult.OK;
        }
    }
}
