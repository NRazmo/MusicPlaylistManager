
public class Node
{
    public Song Data { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(Song song)
    {
        Data = song;
        Next = null;
        Prev = null;
    }
}

