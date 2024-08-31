using System;
using Xunit;

public class CircularBufferTests
{
    /////////////////////////////////////////////////////////
    // You can add more tests to validate your implementation
    /////////////////////////////////////////////////////////

    [Fact]
    public void Reading_empty_buffer_should_fail()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact]
    public void Can_read_an_item_just_written()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Write(1);
        Assert.Equal(1, buffer.Read());
    }

    [Fact]
    public void Writing_to_full_buffer_should_fail()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Write(1);
        Assert.Throws<InvalidOperationException>(() => buffer.Write(2));
    }

    [Fact]
    public void Overwrite_should_replace_oldest_item_when_buffer_is_full()
    {
        var buffer = new CircularBuffer<int>(capacity: 2);
        buffer.Write(1);
        buffer.Write(2);
        buffer.Overwrite(3);

        Assert.Equal(2, buffer.Read()); 
        Assert.Equal(3, buffer.Read()); 
    }

    [Fact]
    public void Can_clear_buffer()
    {
        var buffer = new CircularBuffer<int>(capacity: 2);
        buffer.Write(1);
        buffer.Write(2);
        buffer.Clear();

        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact]
    public void Buffer_should_indicate_when_full()
    {
        var buffer = new CircularBuffer<int>(capacity: 2);
        buffer.Write(1);
        buffer.Write(2);

        Assert.True(buffer.IsFull());
        Assert.False(buffer.IsEmpty());
    }

    [Fact]
    public void Buffer_should_indicate_when_empty()
    {
        var buffer = new CircularBuffer<int>(capacity: 2);

        Assert.True(buffer.IsEmpty());
        Assert.False(buffer.IsFull());
    }

    [Fact]
    public void Can_overwrite_on_full_buffer()
    {
        var buffer = new CircularBuffer<int>(capacity: 2);
        buffer.Write(1);
        buffer.Write(2);
        buffer.Overwrite(3);

        Assert.Equal(2, buffer.Read());
        Assert.Equal(3, buffer.Read());
    }

    [Fact]
    public void Can_fill_and_empty_buffer()
    {
        var buffer = new CircularBuffer<int>(capacity: 3);
        buffer.Write(1);
        buffer.Write(2);
        buffer.Write(3);

        Assert.Equal(1, buffer.Read());
        Assert.Equal(2, buffer.Read());
        Assert.Equal(3, buffer.Read());

        Assert.True(buffer.IsEmpty());
    }
}