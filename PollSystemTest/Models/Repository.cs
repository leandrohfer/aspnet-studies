namespace PollSystemTest.Models
{
    public static class Repository
    {
        private static List<Answer> _answers = new List<Answer>();
        public static IEnumerable<Answer> Answers { get { return _answers; } }
        private static List<User> _listUsers { get; set; } = new List<User>();
        public static IQueryable<User> ListUsers { get { return _listUsers.AsQueryable(); } }


        static Repository()
        {
            Repository._listUsers.Add(new User() { Id = 1, Name = "Leandro Henrique", Email = "leandro@gmail.com" });
            Repository._listUsers.Add(new User() { Id = 2, Name = "Bet ShakeU", Email = "betshake@gmail.com" });
            Repository._listUsers.Add(new User() { Id = 3, Name = "Richard Morales", Email = "richard@gmail.com" });
            Repository._listUsers.Add(new User() { Id = 4, Name = "Emanoel Cristhiano", Email = "emanoel@gmail.com" });
            Repository._listUsers.Add(new User() { Id = 5, Name = "Leonardo Augusto", Email = "leon@gmail.com" });

            Repository.AddAnswer(new Answer()
            {
                Name = "Leandro Henrique",
                Email = "leandro.henrique@gmail.com",
                Yes = true
            });
            Repository.AddAnswer(new Answer()
            {
                Name = "Eluan Geovanni",
                Email = "eluan.geovanni@gmail.com",
                Yes = true
            });
            Repository.AddAnswer(new Answer()
            {
                Name = "Augusto Coelho",
                Email = "augusto.coelho@gmail.com",
                Yes = false
            });
            Repository.AddAnswer(new Answer()
            {
                Name = "Jorge Bestfall",
                Email = "jorge.bestfall@gmail.com",
                Yes = false
            });
            Repository.AddAnswer(new Answer()
            {
                Name = "Roselda Vergolino",
                Email = "vergolino@gmail.com",
                Yes = true
            });
            Repository.AddAnswer(new Answer()
            {
                Name = "Yan Yuri",
                Email = "yan.yuri@gmail.com",
                Yes = false
            });
        }

        public static void Save(User user)
        {
            var userexist = Repository._listUsers.Find(u => u.Id == user.Id);
            if (userexist != null)
            {
                userexist.Name = user.Name;
                userexist.Email = user.Email;
            }
            else
            {
                int maiorId = Repository.ListUsers.Max(u => u.Id);
                user.Id = maiorId + 1;
                Repository._listUsers.Add(user);
            }
        }
        public static void Delete(int id)
        {
            var userexist = Repository._listUsers.Find(u => u.Id == id);
            if (userexist != null)
            {
                Repository._listUsers.Remove(userexist);
            }
        }

        public static void AddAnswer(Answer answer)
        {
            _answers.Add(answer);
        }

        
    }
}
