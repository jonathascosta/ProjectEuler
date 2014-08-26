using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var album = new Album { Title = "FIFA World Cup 2014" };
            album.Stickers = Enumerable.Range(0, 639)
                                       .Select(x => new Sticker { Album = album, Number = x.ToString() })
                                       .ToList();
            album.Stickers.Add(new Sticker { Album = album, Number = "W1" });
            album.Stickers.Add(new Sticker { Album = album, Number = "J1" });
            album.Stickers.Add(new Sticker { Album = album, Number = "J2" });
            album.Stickers.Add(new Sticker { Album = album, Number = "J3" });
            album.Stickers.Add(new Sticker { Album = album, Number = "J4" });
            album.Stickers.Add(new Sticker { Album = album, Number = "L1" });
            album.Stickers.Add(new Sticker { Album = album, Number = "L2" });
            album.Stickers.Add(new Sticker { Album = album, Number = "L3" });
            album.Stickers.Add(new Sticker { Album = album, Number = "L4" });

        }
    }

    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IList<Sticker> Stickers { get; set; }
    }

    public class Sticker
    {
        public int Id { get; set; }
        public Album Album { get; set; }
        public string Number { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public IList<UserSticker> Stickers { get; set; }
    }

    public class UserSticker
    {
        public int Id { get; set; }
        public Sticker Sticker { get; set; }
        public User User { get; set; }
        public int Quantity { get; set; }
    }
}
