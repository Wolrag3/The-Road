
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
using SQLite;
using The_Road.Models;

namespace The_Road.Repositories
{
    public class TheRoadItemRepository : ITheRoadItemRepository
    {
        private SQLiteAsyncConnection connection;
        public event EventHandler<TheRoadItem> OnItemAdded;
        public event EventHandler<TheRoadItem> OnItemUpdated;
        public async Task<List<TheRoadItem>> GetItemsAsync()
        {
            await CreateConnectionAsync();
            return await connection.Table<TheRoadItem>().ToListAsync();
        }
        public async Task AddItemAsync(TheRoadItem item)
        {
            await CreateConnectionAsync();
            await connection.InsertAsync(item);
            OnItemAdded?.Invoke(this, item);
        }
        public async Task UpdateItemAsync(TheRoadItem item)
        {
            await CreateConnectionAsync();
            await connection.UpdateAsync(item);
            OnItemUpdated?.Invoke(this, item);
        }
        public async Task AddOrUpdateAsync(TheRoadItem item)
        {
            if (item.Id == 0)
            {
                await AddItemAsync(item);
            }
            else
            {
                await UpdateItemAsync(item);
            }
        }
        public async Task RemoveAsync(TheRoadItem item)
        {

        }
        private async Task CreateConnectionAsync()
        {
            if (connection != null)
            {
                return;
            }
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "TheRoadItems.db");



            /* Unmerged change from project 'The Road (net8.0-maccatalyst)'
            Before:
                        connection = new SQLiteAsyncConnection(databasePath);


                        await connection.CreateTableAsync<TheRoadItem>();
            After:
                        connection = new SQLiteAsyncConnection(databasePath);


                        await connection.CreateTableAsync<TheRoadItem>();
            */

            /* Unmerged change from project 'The Road (net8.0-ios)'
            Before:
                        connection = new SQLiteAsyncConnection(databasePath);


                        await connection.CreateTableAsync<TheRoadItem>();
            After:
                        connection = new SQLiteAsyncConnection(databasePath);


                        await connection.CreateTableAsync<TheRoadItem>();
            */

            /* Unmerged change from project 'The Road (net8.0-android)'
            Before:
                        connection = new SQLiteAsyncConnection(databasePath);


                        await connection.CreateTableAsync<TheRoadItem>();
            After:
                        connection = new SQLiteAsyncConnection(databasePath);


                        await connection.CreateTableAsync<TheRoadItem>();
            */
            connection = new SQLiteAsyncConnection(databasePath);


            await connection.CreateTableAsync<TheRoadItem>();

            if (await connection.Table<TheRoadItem>().CountAsync() == 0)
            {
                await connection.InsertAsync(new TheRoadItem()
                {
                    Title = "Welcome To The Road",
                    Due = DateTime.Now
                });
            }
        }
    }
}
