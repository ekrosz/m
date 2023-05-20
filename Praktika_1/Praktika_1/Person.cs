namespace Praktika_1
{
    public class Person
    {
        public string Name { get; set; }

        public Role Role { get; set; }

        public int Age { get; set; }
    }

    public enum Role
    {
        Admin,

        Employee,

        Client
    }
}
