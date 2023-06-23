using System;
class SVU_HomeWork 
{
    public void get_values(string[] arrQuestions,string[] arrType,string[] arrAnswers,string[] arrCorrectAnswers)
    {
        string n ="";
        while (n.ToLower() != "exit")
        {
            int Count=0;
            Console.WriteLine("To the number of wrong answers, type 1");
            Console.WriteLine("To the number of right answers, type 2");
            Console.WriteLine("To view all the questions with correct and answered responses, type 3");
            n = Console.ReadLine();
            if (n == "1")
            {
                for(int  i = 0; i < arrType.Length;i++)
                {
                    if (arrType[i] == "Worng")
                        Count+=1;
                }
                Console.WriteLine(Count);
            }
            else if (n == "2")
            {
                for(int  i = 0; i < arrType.Length ;i++)
                {
                    if (arrType[i] == "Correct")
                        Count+=1;
                }
                Console.WriteLine(Count);
            }
            else if (n == "3")
            {
                Console.WriteLine("question\tType\tUser Answer\tCorrect Answer\n==========================================");
                for(int i = 0; i <arrQuestions.Length ;i++)
                {
                    Console.Write(arrQuestions[i]+"\t");
                    if (arrType[i] == "1")
                        Console.Write("Correct\t");
                    else
                        Console.Write("wrong\t");
                    Console.Write(arrAnswers[i]+"\t"+arrCorrectAnswers[i]+"\n");
                }
                
            }
        } 
    }
    
  static void Main() 
  {
    string input,specialChars;
    string myRandomString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"+"abcdefghijklmnopqrstuvwxyz"+"0123456789"+"!@#$%^&*-_.";
    Console.WriteLine("Enter number of question");
    int numberOfQuestions = Int32.Parse(Console.ReadLine());
    while (numberOfQuestions <= 0)
    {
        Console.WriteLine("Enter a valid number");
        numberOfQuestions = Int32.Parse(Console.ReadLine());
    }
    while(true)
    {
        Console.WriteLine("Please enter your name (first name and lastname) and you svu id number with a space between each part (Accpeted Chars: A-Z a-z 0-9).\nThe entered text should contain at least 2 of Accepted chars.");
        input= Console.ReadLine();
        specialChars ="";
        int acceptableNumbers = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'A' && input[i] <= 'Z') || (input[i] >= 'a' && input[i] <= 'z') || (input[i] >= '0' && input[i] <= '9'))
                {
                    acceptableNumbers += 1;
                    specialChars +=input[i];
                }
            }
            if (acceptableNumbers > 1 )
                    break;
    }
    Console.WriteLine("Your full and id are : "+ input);
    Console.WriteLine("Distinct Chars are : "+ specialChars);
    Console.WriteLine("====================================");
    string[] arrQuestions= new string[numberOfQuestions];
    string[] arrType= new string[numberOfQuestions];
    string[] arrAnswers= new string[numberOfQuestions];
    string[] arrCorrectAnswers= new string[numberOfQuestions];
    for (int innerQuestion = 1;innerQuestion<=numberOfQuestions;innerQuestion++)
    {
        Console.WriteLine("Question : "+ innerQuestion);
        Console.WriteLine("Please enter an integer value between 3 and 100 (the number of characters from which to enmerate the most or least repeated characters == Degree of difficlty)");
        int value = Int32.Parse(Console.ReadLine());
        if(!(value >= 3 && value <= 100)){
            innerQuestion -=1;
            continue;
        }
        Random random = new Random();
		char[] question = new char[value];
		for (int singleChar = 0; singleChar < value; ++singleChar)
		{
			int index = random.Next(myRandomString.Length);
			question[singleChar] = myRandomString[index];
		}
		string strQuestion = new string(question);
		arrQuestions.SetValue(strQuestion, innerQuestion-1);
    	Console.WriteLine("What are the distinct existed in the following text:");
		Console.WriteLine(question);
		string correctAnswer = "";
		for (int z = 0; z < question.Length; z++)
            {
                if ((question[z] >= 'A' && question[z] <= 'Z') || (question[z] >= 'a' && question[z] <= 'z'))
                    correctAnswer += question[z];
            }
        arrCorrectAnswers.SetValue(correctAnswer, innerQuestion-1);
		string answer = Console.ReadLine();
		arrAnswers.SetValue(answer, innerQuestion-1);
		if(answer.ToLower() == "ignore"){
		    arrType.SetValue("0", innerQuestion-1);
		    continue;
		}
		if (answer == correctAnswer)
		    arrType.SetValue("1", innerQuestion-1);
		else
		    arrType.SetValue("0", innerQuestion-1);
    }
    SVU_HomeWork myOtherObject = new SVU_HomeWork();
    myOtherObject.get_values(arrQuestions,arrType,arrAnswers,arrCorrectAnswers);
  }
}