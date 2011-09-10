using System;
using System.Collections;

namespace DoFactory.GangOfFour.Command.NETOptimized
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Create user and let her compute
			User user = new User();

			user.Compute('+', 100);
			user.Compute('-', 50);
			user.Compute('*', 10);
			user.Compute('/', 2);

			// Undo 4 commands
			user.Undo(4);

			// Redo 3 commands
			user.Redo(3);

			// Wait for user
			Console.Read();
		}
	}

	// "Command"

	interface ICommand
	{
		void Execute();
		void UnExecute();
	}

	// "ConcreteCommand"

	class CalculatorCommand : ICommand
	{
		char @operator;
		int  operand;
		Calculator calculator;

		// Constructor
		public CalculatorCommand(Calculator calculator, 
			char @operator, int operand)
		{
			this.calculator = calculator;
			this.@operator  = @operator;
			this.operand    = operand;
		}

		public char Operator
		{
			set{ @operator = value; }
		}

		public int Operand
		{
			set{ operand = value; }
		}

		public void Execute()
		{
			calculator.Operation(@operator, operand);
		}
  
		public void UnExecute()
		{
			calculator.Operation(Undo(@operator), operand);
		}

		// Private helper function
		private char Undo(char @operator)
		{
			char undo;
			switch(@operator)
			{
				case '+': undo = '-'; break;
				case '-': undo = '+'; break;
				case '*': undo = '/'; break;
				case '/': undo = '*'; break;
				default : undo = ' '; break;
			}
			return undo;
		}
	}

	// "Receiver"

	class Calculator
	{
		private int curr = 0;

		public void Operation(char @operator, int operand)
		{
			switch(@operator)
			{
				case '+': curr += operand; break;
				case '-': curr -= operand; break;
				case '*': curr *= operand; break;
				case '/': curr /= operand; break;
			}
			Console.WriteLine(
				"Current value = {0,3} (following {1} {2})", 
				curr, @operator, operand);
		}
	}

	// "Invoker"

	class User
	{
		// Initializers
		private Calculator calculator = new Calculator();
		private ArrayList commands = new ArrayList();

		private int current = 0;

		public void Redo(int levels)
		{
			Console.WriteLine("\n---- Redo {0} levels ", levels);
			// Perform redo operations
			for (int i = 0; i < levels; i++)
			{
				if (current < commands.Count - 1)
				{
					ICommand command = commands[current++] as ICommand;
					command.Execute();
				}
			}
		}

		public void Undo(int levels)
		{
			Console.WriteLine("\n---- Undo {0} levels ", levels);
			// Perform undo operations
			for (int i = 0; i < levels; i++)
			{
				if (current > 0)
				{
					ICommand command = commands[--current] as ICommand;
					command.UnExecute();
				}
			}
		}

		public void Compute(char @operator, int operand)
		{
			// Create command operation and execute it
			ICommand command = new CalculatorCommand(
				calculator, @operator, operand);
			command.Execute();

			// Add command to undo list
			commands.Add(command);
			current++;
		}
	}
}
