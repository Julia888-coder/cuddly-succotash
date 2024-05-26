using System.Text.Json;

namespace MyWinFormsApp
{
    public class PersonRepository
    {
        private readonly List<Person> _persons;
        
        private int _maxId;

        public PersonRepository()
        {
            _maxId = 0;
            _persons = new List<Person>();
        }

        public PersonRepository(string path)
        {
            _persons = LoadJsonData(path);
            _maxId = _persons.Max(p => p.Id);
        }

        // Подгрузка данных из JSON-файла
        private List<Person> LoadJsonData(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Person>>(json);
        }
        
        public void Add(Person person)
        {
            person.Id = ++_maxId;
            _persons.Add(person);
        }
        
        public IEnumerable<Person> GetAll() => _persons;
        
        // LINQ-запрос на методах с применением группировки данных и выборки из нее.
        // Группирует элементы по городам, и возвращает словарь "Город: Список пациентов".
        public Dictionary<string, List<Person>> GetByCities()
        {
            return _persons.GroupBy(p => p.Address.City).ToDictionary(p => p.Key, p => p.ToList());
        }

        // Классический LINQ-запрос с выборкой из списка объектов.
        // Выбирает элементы, у которых значение поля Age больше заданного.
        public IEnumerable<Person> GetAgeGreaterOrEqual(int age) {
            return from p in _persons
                   where p.Age >= age
                   select p;
        }

        public void Delete(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
                _persons.Remove(person);
        }
        
        public void Edit(Person person)
        {
            var index = _persons.FindIndex(p => p.Id == person.Id);
            if (index >= 0)
                _persons[index] = person;
        }
        
        // Сохранение данных в JSON-файл
        public void SaveJsonData(string path)
        {
            var json = JsonSerializer.Serialize(_persons);
            File.WriteAllText(path, json);
        }
    }
}
