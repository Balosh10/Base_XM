using System;
using System.Collections.Generic;

namespace App_Base_XF.Model
{
  
    public class TopRated
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public bool favorite1 { get; set; }
        public bool favorite2 { get; set; }
        public bool favorite3 { get; set; }
        public bool favorite4 { get; set; }
        public bool favorite5 { get; set; }


    }

    public class MovieTopRated
    {
        public int page { get; set; }
        public List<TopRated> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
