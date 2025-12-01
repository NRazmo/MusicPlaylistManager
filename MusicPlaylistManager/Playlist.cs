using System;

namespace MusicPlaylistManager
{
    public class Playlist
    {
        private Node head;
        private Node tail;
        private int count;

        public Playlist()
        {
            head = tail = null;
            count = 0;
        }

        public void AddSong(Song s)
        {
            Node node = new Node(s);
            if (head == null)
            {
                head = tail = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            count++;
        }

        public void RemoveSong(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            Node temp = head;
            int i = 0;

            while (i < index)
            {
                temp = temp.Next;
                i++;
            }
            if (temp.Prev != null)
                temp.Prev.Next = temp.Next;
            else
                head = temp.Next;

            if (temp.Next != null)
                temp.Next.Prev = temp.Prev;
            else
                tail = temp.Prev;

            count--;
            Console.WriteLine("Song removed successfully!");
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

        public void Search(string keyword)
        {
            Node temp = head;
            int i = 0;
            bool found = false;

            while (temp != null)
            {
                if (temp.Data.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    temp.Data.Artist.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"{i}: {temp.Data}");
                    found = true;
                }
                temp = temp.Next;
                i++;
            }
            if (!found)
                Console.WriteLine("No matching songs found");

        }
    }
}
