using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groups
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contextBand = new ContextBands())
            {
                #region AddBands&Profile
                //Console.WriteLine("Сколько групп добавить?");
                //int countGroup = int.Parse(Console.ReadLine());
                //for (int i = 0; i < countGroup; i++)
                //{
                //    Console.WriteLine("Введите наименование группы?");
                //    string name = Console.ReadLine();
                //    var band = new MusicianGroup
                //    {
                //        NameOfGroup = name
                //    };
                //    contextBand.Band.Add(band);
                //    contextBand.SaveChanges();
                //}

                //for (int i = 0; i < countGroup; i++)
                //{
                //    Console.WriteLine("Введите описание группы?");
                //    string profile = Console.ReadLine();
                //    Console.WriteLine("Введите текст песни этой группы?");
                //    string text = Console.ReadLine();
                //    Console.WriteLine("Введите рейтинг этой группы?");
                //    int rating = int.Parse(Console.ReadLine());
                //    Console.WriteLine("Введите время звучания песни?");
                //    long timeMusic = long.Parse(Console.ReadLine());
                //    var profileMusic = new ProfileBand
                //    {
                //        ProfileMusicGroups = profile,
                //        TextMusic = text,
                //        TimesSounding = timeMusic,
                //        Rating = rating,
                //        GroupId = contextBand.Band.ToList()[i].Id
                //    };
                //    contextBand.Music.Add(profileMusic);
                //    contextBand.SaveChanges();
                //}
                #endregion

                #region Searching&Sorting
                Console.WriteLine("Введите слово из группы которую хотите найти?");
                string nameSearch = Console.ReadLine();
                
                var groupIdSearch = (from band in contextBand.Band
                                     where band.NameOfGroup.Contains(nameSearch)
                                     select band.Id).FirstOrDefault();
                var musicSearch = from profileMusic
                                  in contextBand.Music
                                  where profileMusic.GroupId == groupIdSearch
                                  select profileMusic;
                foreach (ProfileBand profile in musicSearch)
                {
                    Console.WriteLine($"Band Name: {profile.ProfileMusicGroups}");
                    Console.WriteLine($"Rating: {profile.Rating}");
                    Console.WriteLine($"Text: {profile.TextMusic}");
                    Console.WriteLine($"Time sound: {profile.TimesSounding}");
                }
                Console.ReadLine();

                Console.WriteLine("Сортировка----------------------------------");
                var musicProfileSortDes = from profileMusic
                                       in contextBand.Music
                                       orderby profileMusic.Rating
                                       descending
                                       select profileMusic;
                var musicProfileSortAsc = from profileMusic
                                       in contextBand.Music
                                          orderby profileMusic.Rating
                                          ascending
                                          select profileMusic;
                foreach (ProfileBand profile in musicProfileSortAsc)
                {
                    Console.WriteLine($"Band Name: {profile.ProfileMusicGroups}");
                    Console.WriteLine($"Rating: {profile.Rating}");
                }
                Console.ReadLine();
                #endregion
            }
        }
    }
}
