using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private Dictionary<string, ICollection<TUser>> _dictionary;

        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            _dictionary = new Dictionary<string, ICollection<TUser>>();
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (_dictionary.ContainsKey(group)) {
                if (_dictionary.GetValueOrDefault(group).Contains(user)) {
                    return false;
                }
            } else {
                _dictionary.Add(group, new List<TUser>());
            }
            _dictionary.GetValueOrDefault(group).Add(user);
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                IList<TUser> list = new List<TUser>();
                foreach(TUser user in _dictionary.Values) {
                    list.Add(user);
                }
                return list;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            ICollection<TUser> list = new List<TUser>();
            if (group != null && _dictionary.ContainsKey(group)) {
                foreach(TUser user in _dictionary.GetValueOrDefault(group)) {
                    list.Add(user);
                }
            }
            return list;
        }
    }
}
