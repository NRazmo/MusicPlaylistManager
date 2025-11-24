
public class Node
{
    public Song Data;
    public Node Next;
    public Node Prev;

    public Node(Song song)
    {
        Data = song;
        Next = null;
        Prev = null;
    }
}

