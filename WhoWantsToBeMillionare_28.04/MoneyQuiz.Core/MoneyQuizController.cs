using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data.Data;
using MoneyQuiz.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Core
{
    public class MoneyQuizController
    {
        MoneyQuizDbContext context;
        public MoneyQuizController(MoneyQuizDbContext context)
        {
            this.context = context;
        }
        public async Task AddQuestion(int amount, string text)
        {
            await context.Questions.AddAsync(new Question { Amount = amount, QuestionText = text });
            await context.SaveChangesAsync();
        }
        public async Task AddAnswersToQuestion(int questionId, List<(string text, bool isCorrect)> answers)
        {

            var question = await context.Questions.FindAsync(questionId);
            if (question == null) throw new ArgumentNullException("Not valid question.");

            foreach (var (text, isCorrect) in answers)
            {
                await context.Answers.AddAsync(new Answer { Answer_Text = text, IsCorrect = isCorrect, Question_Id = questionId });
            }

            await context.SaveChangesAsync();
        }
        public async Task EditQuestion(int questionId, string newText, int newAmount)
        {
            var question = await context.Questions.FindAsync(questionId) ?? throw new ArgumentNullException("Invalid question.");
            question.QuestionText = newText;
            question.Amount = newAmount;
            await context.SaveChangesAsync();
        }
        public async Task EditAnswer(int answerId, params object[] answerEdits)
        {
            var answer = await context.Answers.FindAsync(answerId);
            if (answer == null) throw new InvalidOperationException("Answer not found.");

            answer.Answer_Text = answerEdits[0].ToString();
            answer.IsCorrect = bool.Parse(answerEdits[1].ToString());
            if (answerEdits[2] is not null)
            {
                answer.Question_Id = int.Parse(answerEdits[2].ToString());
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteLifeline(int lifelineId)
        {
            var lifeline = await context.LifeLines.FindAsync(lifelineId) ?? throw new ArgumentNullException("Lifeline not found.");
            context.LifeLines.Remove(lifeline);
            await context.SaveChangesAsync();
        }
        public async Task AddPlayer(string name, string email)
        {
            var player = new Player { Name = name, Email = email };
            await context.Players.AddAsync(player);
            await context.SaveChangesAsync();
        }
        public async Task<List<string>> GetOver3000QuestionsText()
        {
            return await context.Questions
                .Where(q => q.Amount > 3000)
                .Select(q => q.QuestionText)
                .ToListAsync();
        }
        public async Task<List<(string QuestionText, List<string> Answers)>> GetQuestionsWithAnswers()
        {
            var result = await context.Questions.Include(x => x.Answers)
                .Select(q => new
                {
                    q.QuestionText,
                    Answers = q.Answers.Select(a => a.Answer_Text).ToList()
                })
                .ToListAsync();

            return result.Select(q => (q.QuestionText, q.Answers)).ToList();
        }
        public async Task<List<(string QuestionText, string CorrectAnswer)>> GetCorrectAnswersByAmount(int amount)
        {
            var result = await context.Questions
                .Include(x => x.Answers)
                .Where(q => q.Amount == amount)
                .Select(q => new
                {
                    q.QuestionText,
                    CorrectAnswer = q.Answers.FirstOrDefault(a => a.IsCorrect).Answer_Text
                })
                .ToListAsync();

            return result.Select(q => (q.QuestionText, q.CorrectAnswer)).ToList();
        }
    }
}
