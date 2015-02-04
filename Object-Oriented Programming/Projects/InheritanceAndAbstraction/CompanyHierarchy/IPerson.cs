using System;

public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
    uint Id { get; set; }
    string ToString();
}

