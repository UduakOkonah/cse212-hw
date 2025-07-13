using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities.
    // Expected Result: Highest priority item is dequeued first.
    // Defect(s) Found: None.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("low", 1);
        queue.Enqueue("medium", 5);
        queue.Enqueue("high", 10);

        string result = queue.Dequeue();
        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario: Items with the same priority - should follow FIFO.
    // Expected Result: First enqueued item of same priority is removed first.
    // Defect(s) Found: None.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("first", 5);
        queue.Enqueue("second", 5);
        queue.Enqueue("third", 5);

        string result1 = queue.Dequeue();
        string result2 = queue.Dequeue();
        Assert.AreEqual("first", result1);
        Assert.AreEqual("second", result2);
    }

    [TestMethod]
    // Scenario: Dequeue on empty queue.
    // Expected Result: Exception is thrown.
    // Defect(s) Found: None.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var queue = new PriorityQueue();
        queue.Dequeue(); // Should throw
    }
}
