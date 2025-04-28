
using MoneyQuiz.Core;
using MoneyQuiz.Data.Data;
using System.Linq.Expressions;
MoneyQuizDbContext context = new MoneyQuizDbContext();
MoneyQuizController quizService = new MoneyQuizController(context);

while (true)
{
    Console.WriteLine("1. Add Question");
    Console.WriteLine("2. Add 4 Answers to Question");
    Console.WriteLine("3. Edit Question");
    Console.WriteLine("4. Edit Answer");
    Console.WriteLine("5. Delete Lifeline");
    Console.WriteLine("6. Add Player");
    Console.WriteLine("7. Show Questions Over 3000");
    Console.WriteLine("8. Show Questions with All Answers");
    Console.WriteLine("9. Show Correct Answers for Given Amount");
    Console.WriteLine("0. Exit");
    Console.Write("Choice: ");

    var choice = Console.ReadLine();
    Console.WriteLine();
    switch (choice)
    {
        case "1":
            Console.Write("Enter question text: ");
            var text = Console.ReadLine();

            Console.Write("Enter amount: ");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                await quizService.AddQuestion(amount, text);
                Console.WriteLine("Question successfully added.");
            }
            else
            {
                Console.WriteLine("Invalid type for amount.");
            }
            Console.WriteLine();
            break;
        case "2":
            Console.WriteLine($"Possible options for question id: {string.Join(", ",context.Questions.Select(x => x.Id))}");
            Console.Write("Enter question ID: ");
            try
            {
                if (int.TryParse(Console.ReadLine(), out int questionId))
                {
                    var answers = new List<(string text, bool isCorrect)>();
                    int i = 1;
                    while(answers.Count != 4)
                    {
                        Console.Write($"Answer {i} text: ");
                        var answerText = Console.ReadLine();
                        Console.Write($"Is answer {i} correct? (true/false): ");
                        if (bool.TryParse(Console.ReadLine(), out bool isCorrect))
                        {
                            answers.Add((answerText, isCorrect));
                        }
                        else
                        {
                            Console.WriteLine("Invalid type for correct.");
                            i--;
                        }
                        i++;
                    }

                    await quizService.AddAnswersToQuestion(questionId, answers);
                    Console.WriteLine("Answers added.");
                }
                else
                {
                    Console.WriteLine("Invalid question ID.");
                    break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            break;
        case "3":
            Console.Write("Enter question ID: ");
            try
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Write("Enter new text: ");
                    var newText = Console.ReadLine();
                    Console.Write("Enter new amount: ");
                    if (int.TryParse(Console.ReadLine(), out int newAmount))
                    {
                        await quizService.EditQuestion(id, newText, newAmount);
                        Console.WriteLine("Question updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid type for amount.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid question ID.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine();
            break;
        case "4":
            try
            {
                Console.Write("Enter answer ID: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Write("Enter new answer text: ");
                    var newText = Console.ReadLine();
                    Console.Write("Is the answer correct? (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool isCorrect))
                    {
                        Console.WriteLine("Do you wish to change question Id? (yes/no): ");
                        if(Console.ReadLine().ToLower() == "yes")
                        {
                            Console.WriteLine($"Write new question id, here are the options: {string.Join(", ",context.Questions.Select(x => x.Id))}");
                            Console.Write("New Question Id: ");
                            if(int.TryParse(Console.ReadLine(), out int resultId))
                            {
                                await quizService.EditAnswer(id, newText, isCorrect, resultId);
                                Console.WriteLine("Answer updated including changed question Id.");
                            }
                            else
                            {
                                Console.WriteLine("Wrong");
                            }
                        }
                        else
                        {
                            await quizService.EditAnswer(id, newText, isCorrect);
                            Console.WriteLine("Answer updated without changing the question Id.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid correctness input.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid answer ID.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            break;
        case "5":
            Console.WriteLine($"All lifeline Id's: {string.Join(", ", context.LifeLines.Select(x => x.Id))}");
            Console.Write("Enter lifeline ID to delete: ");
            try
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    await quizService.DeleteLifeline(id);
                    Console.WriteLine("Lifeline deleted.");
                }
                else
                {
                    Console.WriteLine("Invalid ID.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            break;
        case "6":
            Console.Write("Enter player name: ");
            var name = Console.ReadLine();
            Console.Write("Enter player email: ");
            var email = Console.ReadLine();

            await quizService.AddPlayer(name, email);
            Console.WriteLine("Player added.");
            Console.WriteLine();
            break;
        case "7":
            var questions = await quizService.GetOver3000QuestionsText();
            Console.WriteLine("Questions with amount > 3000:");
            if (questions.Count == 0)
            {
                Console.WriteLine("No questions found.");
                Console.WriteLine();
                break;
            }
            foreach (var q in questions)
            {
                Console.WriteLine($"{q}");
            }
            Console.WriteLine();
            break;
        case "8":
            var result = await quizService.GetQuestionsWithAnswers();
            foreach (var (questionText, answers) in result)
            {
                Console.WriteLine($"Q: {questionText}, answers: ");
                foreach (var answer in answers)
                {
                    Console.WriteLine($"{answer}");
                }
            }
            Console.WriteLine();
            break;
        case "9":
            Console.Write("Enter the amount: ");
            if (int.TryParse(Console.ReadLine(), out int amount2))
            {
                var result2 = await quizService.GetCorrectAnswersByAmount(amount2);
                foreach (var (questionText, correctAnswer) in result2)
                {
                    Console.WriteLine($"Q: {questionText} "+ "\n" + $"Correct: {correctAnswer}");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
            Console.WriteLine();
            break;
        case "0":
            Console.WriteLine("Exiting the program...");
            return;
        default:
            Console.WriteLine("Invalid option.");
            Console.WriteLine();
            break;
    }
}
