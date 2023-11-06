namespace CSharpTest
{
    public class GenericStudy
    {
        public string ShowFullName<T>(string firstName,string surName) where T:new ()
        {
            T person = new T();

            return person.ToString();
        }
    }

    public struct Person
    {
        public string FirstName { get; set; }
        public string SurName { get;  set; }

        public Person(string firstName,string surName)
        {
            this.FirstName = firstName;
            this.SurName = surName;
        }

        public override string ToString()
        {
            return $"{FirstName??"d-first"} {SurName??"d-sur"}";
        }
    }
}