namespace MyWinFormsApp
{
    public class Person
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string SecondName { get; set; }
        
        public int Age { get; set; }
        
        public Address Address { get; set; }

        public List<Car> Cars { get; set; }

        public override string ToString()
        {
            return $"Person ( Id = {Id}, Name = {Name}, SecondName = {SecondName}, Age = {Age}, City = {Address.City}, Flat = {Address.Flat})";
        }
    }
}
