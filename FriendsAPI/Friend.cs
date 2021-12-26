using System;

namespace FriendsAPI
{
     public class Friend
        {
            public string id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string location { get; set; }
            public string homeland { get; set; }
            public string dateOfBirth { get; set; }

            public Friend()
            {
            }

            ~Friend()
            {
            }

            public Friend(string id, string firstname, string lastname, string homeland, string location, string dateOfBirth)
            {
                this.id = id;
                this.firstname = firstname;
                this.lastname = lastname;
                this.homeland = homeland;
                this.location = location;
                this.dateOfBirth = dateOfBirth;
            }
        }
}
