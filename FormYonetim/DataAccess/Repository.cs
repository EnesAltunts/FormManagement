using Entity;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Repository
    {
        public Forms AddForm(Forms form,string userName)
        {
            using(DataContext dt = new DataContext())
            {
                int userId = dt.Users.FirstOrDefault(x => x.UserName == userName).UserId;

                form.createdBy = userId;

                dt.Forms.Add(form);
                dt.SaveChanges();
            }
            return (form);
        }

        public List<Forms> FormList()
        {
            using (DataContext dt = new DataContext())
            {
                return dt.Forms.ToList();
            }
            
        }

        public Users Control(string username, string password)
        {
            using (DataContext dt = new DataContext())
            {
                var user = dt.Users.FirstOrDefault(x => x.UserName.Equals(username) && x.Password.Equals(password));
                return user;
            }
            
        }
    }
}
