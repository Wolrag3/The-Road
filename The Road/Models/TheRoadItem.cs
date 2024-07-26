
/* Unmerged change from project 'The Road (net8.0-maccatalyst)'
Before:
using System;
After:
using SQLite;
using System;
*/

/* Unmerged change from project 'The Road (net8.0-ios)'
Before:
using System;
After:
using SQLite;
using System;
*/

/* Unmerged change from project 'The Road (net8.0-android)'
Before:
using System;
After:
using SQLite;
using System;
*/
using
/* Unmerged change from project 'The Road (net8.0-maccatalyst)'
Before:
using System.Threading.Tasks;
using SQLite;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'The Road (net8.0-ios)'
Before:
using System.Threading.Tasks;
using SQLite;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'The Road (net8.0-android)'
Before:
using System.Threading.Tasks;
using SQLite;
After:
using System.Threading.Tasks;
*/
SQLite;

namespace The_Road.Models
{
    public class TheRoadItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Completed { get; set; }
        public DateTime Due { get; set; }
    }
}
