
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace BiblioVR.Core
//{
//    /// <summary>
//    /// Provides methods for managing Databases
//    /// </summary>
//    public class DatabaseManager
//    {
//        private MangaDB mangaDB;

//        public DatabaseManager()
//        {
//            this.mangaDB = new MangaDB();
//        }

//        /// <summary>
//        /// Populate the databases
//        /// </summary>
//        private void Populate()
//        {
//            foreach (DirectoryInfo dir in FileHelper.GetDirs(FileHelper.APP_ROOT))
//            {
//                switch (Title.GetType(dir))
//                {
//                    case TitleType.MANGA:
//                        switch (Manga.GetSource(dir))
//                        {
//                            case MangaType.MANGADEX:
//                                mangaDB.Add(new MangaDex(dir));
//                                break;
//                            case MangaType.KISSMANGA:
//                                mangaDB.Add(new KissManga(dir));
//                                break;
//                            case MangaType.NULL:
//                            default:
//                                break;
//                        }
//                        break;



//                    case TitleType.NULL:
//                    default:
//                        break;

//                }
//            }
//        }

//        /// <summary>
//        /// Refresh the databases
//        /// </summary>
//        public void Refresh()
//        {
//            mangaDB.Clear();

//            Populate();
//        }

//        /// <summary>
//        /// Gets all Manga from the Manga database
//        /// </summary>
//        /// <returns></returns>
//        public List<Title> GetMangaPopulation()
//        {
//            return mangaDB.Get();
//        }


//        /// <summary>
//        /// Get the current Manga Database
//        /// </summary>
//        /// <returns>The current Manga Database</returns>
//        public MangaDB GetMangaDB()
//        {
//            return this.mangaDB;
//        }


//    }
//}
