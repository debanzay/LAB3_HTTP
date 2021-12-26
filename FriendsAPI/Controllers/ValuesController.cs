using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendsAPI;

namespace FriendsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        static List<Friend> friends = new List<Friend>();

        // GET: - вывод полного списка друзей
        [HttpGet]
        public List<Friend> Get()
        {
            /*friends.Add(new Friend("1", "Алексей", "Палкин", "Russia", "Turkey", "01.01.1999"));
            friends.Add(new Friend("2", "Михаил", "Мельников", "Ukrain", "Egypt", "02.02.1999"));
            friends.Add(new Friend("3", "Кирилл", "Оборин", "Kazakhstan", "Hungary", "03.03.1999"));
            friends.Add(new Friend("4", "Саша", "Власов", "Russia", "Italy", "04.04.1999"));
            friends.Add(new Friend("5", "Михаил", "Устюгов", "Russia", "Germany", "05.05.1999"));*/

            return friends;
        }

        // GET:- вывод друга с запрашиваемым id
        [HttpGet("{id}", Name = "Get")]
        public Friend Get(string id)
        {
            Friend _friend = friends.Find(f => f.id == id);
            return _friend;
        }

        // GET: - вывод друзей, родившихся в одной стране
        [HttpGet("{homeland}", Name = "GetHomeland")]
        public List<Friend> GetID(string homeland)
        {
            List<Friend> friendsFound = friends.FindAll(f => f.homeland == homeland);
            return friendsFound;
        }

        // POST: - добавление друга и вывод обновленного списка друзей
        [HttpPost]
        public List<Friend> Post([FromBody] Friend _friend)
        {
            friends.Add(_friend);
            return friends;
        }

        // PUT: api/Friend/5 - редактирование друга с указанным id и обновление списка
        [HttpPut("{id}")]
        public List<Friend> Put(string id, [FromBody] Friend friend)
        {
            Friend friendToUpdate = friends.Find(f => f.id == id);
            int index = friends.IndexOf(friendToUpdate);

            friends[index].firstname = friend.firstname;
            friends[index].lastname = friend.lastname;
            friends[index].homeland = friend.homeland;
            friends[index].location = friend.location;
            friends[index].dateOfBirth = friend.dateOfBirth;

            return friends;
        }

        // DELETE: - удаление друга с указанным id и обновление списка
        [HttpDelete("{id}")]
        public List<Friend> DeleteID(string id)
        {
            Friend friend = friends.Find(f => f.id == id);
            friends.Remove(friend);
            return friends;
        }

        // DELETE: - удаление друга, родившегося в России
        [HttpDelete("{homeland}")]
        public List<Friend> Delete(string homeland = "Russia")
        {
            friends.RemoveAll(f => f.homeland == homeland);
            return friends;
        }

        // DELETE: - удаление всех друзей
        [HttpDelete]
        public List<Friend> Delete()
        {
            friends.Clear();
            return friends;
        }
    }
}

