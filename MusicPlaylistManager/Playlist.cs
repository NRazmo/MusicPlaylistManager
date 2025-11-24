using System;

public class Playlist
{
    private Node head;
    private Node tail;
    private Node current;
    private int count;

    public Playlist()
    {
        head = tail = current = null;
        count = 0;
    }

    public void AddSong(Song s)
    {
        Node node = new Node(s);
        if (head == null) head = tail = node;
        else
        {
            tail.Next = node;
            node.Prev = tail;
            tail = node;
        }
        count++;
    }

    public void PrintAll()
    {
        Node temp = head;
        int i = 0;
        while (temp != null)
        {
            Console.WriteLine($"{i}: {temp.Data}");
            temp = temp.Next;
            i++;
        }
    }
}

