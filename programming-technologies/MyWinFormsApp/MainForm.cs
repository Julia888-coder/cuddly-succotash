using System.Collections.ObjectModel;

namespace MyWinFormsApp
{
    public partial class MainForm : Form
    {
        private PersonRepository _personRepository = new();

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateItems()
        {
            var items = _personRepository.GetAll();
            listBoxItems.DataSource = new ObservableCollection<Person>(items);
            listBoxItems.SelectedItem = null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var editForm = new EditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                var newPerson = editForm.GetPerson();
                _personRepository.Add(newPerson);
                UpdateItems();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem is not Person selectedPerson)
                return;

            var editForm = new EditForm(selectedPerson);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                var changedPerson = editForm.GetPerson();
                _personRepository.Edit(changedPerson);
                UpdateItems();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem is not Person selectedPerson)
                return;
            _personRepository.Delete(selectedPerson.Id);

            UpdateItems();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_personRepository == null) return;
            var saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _personRepository.SaveJsonData(saveDialog.FileName);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _personRepository = new PersonRepository(openDialog.FileName);
                UpdateItems();
            }
        }

        // Обработка нажатия на кнопку "Показать" для отображения всех пациентов,
        // которые старше определенного возраста (его вводит пользователь).
        private void buttonAgeComparing_Click(object sender, EventArgs e)
        {
            var ageInput = Convert.ToInt32(numericUpDownAgeComparing.Value);

            var items = _personRepository.GetAgeGreaterOrEqual(ageInput);
            listBoxAgeComparing.DataSource = new ObservableCollection<Person>(items);
            listBoxAgeComparing.SelectedItem = null;
        }

        // Обработка нажатия на кнопку "Узнать" для отображения самого популярного города
        // у клиентов. Группирует пациентов по городам и выводит город, у которого больше всего
        // пациентов.
        private void buttonPopularCity_Click(object sender, EventArgs e)
        {
            var items = _personRepository.GetByCities();
            if (items.Count > 0)
            {
                string keyWithMostElements = items.OrderByDescending(x => x.Value.Count).First().Key;
                textBoxPopularCity.Text = keyWithMostElements;
            }
        }
    }
}
