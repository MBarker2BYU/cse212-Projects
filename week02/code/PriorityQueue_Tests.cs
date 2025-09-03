using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a single item
    // Expected Result: The queue should contain the enqueued item
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueSingleItem()
    {
        //Create the priority queue
        var priorityQueue = new PriorityQueue();

        //Enqueue a single item
        priorityQueue.Enqueue("Message1", 1);

        var priorityQueueString = priorityQueue.ToString();

        //Assert that the queue contains the enqueued item
        Assert.AreEqual("[Message1 (Pri:1)]", priorityQueueString);
    }

    [TestMethod]
    // Scenario: Dequeue a single item from the queue
    // Expected Result: The dequeued item should be the same as the enqueued item
    // Defect(s) Found: Item not removed from queue after dequeue
    public void TestPriorityQueue_DequeueSingleItem()
    {
        //Create the priority queue
        var priorityQueue = new PriorityQueue();

        //Enqueue a single item
        priorityQueue.Enqueue("Message1", 1);

        //Dequeue the item
        var dequeuedItem = priorityQueue.Dequeue();
        //Assert that the dequeued item is the same as the enqueued item
        Assert.AreEqual("Message1", dequeuedItem);
        //Verify the queue is empty
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority
    // Defect(s) Found: Last item not considered (loop boundary); item not removed from queue
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Message1", 1);
        priorityQueue.Enqueue("Message2", 2);
        priorityQueue.Enqueue("Message3", 3);

        // Dequeue the items and assert their order
        var dequeuedItem1 = priorityQueue.Dequeue();
        Assert.AreEqual("Message3", dequeuedItem1);

        var dequeuedItem2 = priorityQueue.Dequeue();
        Assert.AreEqual("Message2", dequeuedItem2);

        var dequeuedItem3 = priorityQueue.Dequeue();
        Assert.AreEqual("Message1", dequeuedItem3);

        //Verify the queue is empty
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and dequeue them
    // Expected Result: Items with the same priority should be dequeued in FIFO order
    // Defect(s) Found: FIFO order violated (last item selected); item not removed from queue
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Message1", 2);
        priorityQueue.Enqueue("Message2", 2);
        priorityQueue.Enqueue("Message3", 2);

        // Dequeue the items and assert their order
        var dequeuedItem1 = priorityQueue.Dequeue();
        Assert.AreEqual("Message1", dequeuedItem1);

        var dequeuedItem2 = priorityQueue.Dequeue();
        Assert.AreEqual("Message2", dequeuedItem2);

        var dequeuedItem3 = priorityQueue.Dequeue();
        Assert.AreEqual("Message3", dequeuedItem3);

        //Verify the queue is empty
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException for empty queue.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message, "Exception message should be 'The queue is empty.'");
        }

    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities and verify FIFO for same priorities
    // Expected Result: Highest priority items dequeued first, same priority items in FIFO order
    // Defect(s) Found: FIFO order violated; item not removed from queue
    public void TestPriorityQueue_MixedPrioritiesAndFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Message1", 1);
        priorityQueue.Enqueue("Message2", 3);
        priorityQueue.Enqueue("Message3", 2);
        priorityQueue.Enqueue("Message4", 3);
        priorityQueue.Enqueue("Message5", 1);

        // Dequeue the items and assert their order
        var dequeuedItem1 = priorityQueue.Dequeue();
        Assert.AreEqual("Message2", dequeuedItem1);

        var dequeuedItem2 = priorityQueue.Dequeue();
        Assert.AreEqual("Message4", dequeuedItem2);

        var dequeuedItem3 = priorityQueue.Dequeue();
        Assert.AreEqual("Message3", dequeuedItem3);

        var dequeuedItem4 = priorityQueue.Dequeue();
        Assert.AreEqual("Message1", dequeuedItem4);

        var dequeuedItem5 = priorityQueue.Dequeue();
        Assert.AreEqual("Message5", dequeuedItem5);

        //Verify the queue is empty
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]

    // Scenario: Enqueue items with highest priority at end, verify dequeue
    // Expected Result: Highest priority item dequeued
    // Defect(s) Found: Last item not considered (loop boundary); item not removed from queue
    public void TestPriorityQueue_HighestPriorityAtEnd()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Message1", 1);
        priorityQueue.Enqueue("Message2", 2);
        priorityQueue.Enqueue("Message3", 5); // Highest priority at the end

        // Dequeue the highest priority item
        var dequeuedItem = priorityQueue.Dequeue();
        Assert.AreEqual("Message3", dequeuedItem);

        //Verify the queue is not empty
        Assert.AreEqual("[Message1 (Pri:1), Message2 (Pri:2)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Verify the queue is empty after all dequeues
    // Expected Result: Queue should be empty
    // Defect(s) Found: Item not removed from queue after dequeue
    public void TestPriorityQueue_EmptyValidation()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Message1", 1);
        priorityQueue.Enqueue("Message2", 2);
        priorityQueue.Enqueue("Message3", 3);

        // Dequeue all items
        priorityQueue.Dequeue();
        priorityQueue.Dequeue();
        priorityQueue.Dequeue();

        // Verify the queue is empty
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

}