/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Add one customer and serve them
        // Expected Result: Display the customer's info
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer();
        service.ServeCustomer();
        // Defect Found: Needed to print the customer before removing them
        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve both in order
        // Expected Result: Customers served in FIFO order
        Console.WriteLine("Test 2");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving: {service}");
        Console.WriteLine("=================");

        // Test 3
        // Scenario: Try serving when queue is empty
        // Expected Result: Error message
        Console.WriteLine("Test 3");
        service = new CustomerService(4);
        service.ServeCustomer();
        // Defect Found: Needed to handle empty queue before serving
        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add more customers than the max size
        // Expected Result: Error on 5th customer
        Console.WriteLine("Test 4");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer(); // This should trigger the error
        Console.WriteLine($"Queue after adds: {service}");
        // Defect Found: Needed to use >= not >
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Provide invalid size to constructor
        // Expected Result: Should default to size 10
        Console.WriteLine("Test 5");
        service = new CustomerService(0);
        Console.WriteLine($"Expected max size 10: {service}");
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    /// <summary>
    /// Inner class representing a customer record.
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId}): {Problem}";
        }
    }

    /// <summary>
    /// Adds a new customer to the queue after prompting for their details.
    /// </summary>
    private void AddNewCustomer() {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Removes and displays the next customer in the queue.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in the queue.");
        } else {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Displays the current state of the queue.
    /// </summary>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
