using System;

public class CircularBuffer<T>
{
    //////////////////////////////////////////////////////
    // You can add your own methods but .:[DO NOT]:.
    // change the signature of the provided methods
    //////////////////////////////////////////////////////
    ///

    private readonly T[] _buffer;
    private int _head;
    private int _tail;
    private bool _isFull;

    public CircularBuffer(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.", nameof(capacity));

        _buffer = new T[capacity];
        _head = 0;
        _tail = 0;
        _isFull = false;
    }

    public T Read()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Buffer is empty.");

        var value = _buffer[_tail];
        _tail = (_tail + 1) % _buffer.Length;
        _isFull = false;

        return value;
    }

    public void Write(T value)
    {
        if (_isFull)
            throw new InvalidOperationException("Buffer is full.");

        _buffer[_head] = value;
        _head = (_head + 1) % _buffer.Length;
        _isFull = _head == _tail;
    }

    public void Overwrite(T value)
    {
        if (_isFull)
        {
            _buffer[_head] = value;
            _head = (_head + 1) % _buffer.Length;
            _tail = (_tail + 1) % _buffer.Length;
        }
        else
        {
            Write(value);
        }
    }

    public void Clear()
    {
        _head = 0;
        _tail = 0;
        _isFull = false;
    }

    public bool IsEmpty()
    {
        return !_isFull && _head == _tail;
    }

    public bool IsFull()
    {
        return _isFull;
    }
}