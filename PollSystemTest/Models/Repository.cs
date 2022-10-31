namespace PollSystemTest.Models
{
    public static class Repository
    {
        private static List<Answer> _answers = new List<Answer>();
        public static IEnumerable<Answer> Answers { get { return _answers; } }

        public static void AddAnswer(Answer answer)
        {
            _answers.Add(answer);
        }
    }
}
