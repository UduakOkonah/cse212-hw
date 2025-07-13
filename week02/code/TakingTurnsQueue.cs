public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person current = _people.Dequeue();

        // Make a copy to return with original turn count
        var result = new Person(current.Name, current.Turns);

        if (current.Turns <= 0)
        {
            // Infinite turns: re-enqueue without decrement
            _people.Enqueue(current);
        }
        else if (current.Turns > 1)
        {
            // More than 1 turn left: decrement and re-enqueue
            current.Turns -= 1;
            _people.Enqueue(current);
        }
        // If current.Turns == 1: don't re-enqueue (they're done)

        return result;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
