// 3110. Score of a String
using System.Text.Unicode;
using System.Threading.Tasks;

public class Program
{
	public class TaskToGo
	{
		public char Task { get; set; }
		public int NextAvailableTime { get; set; }
		public int RemainingCount { get; set; }
	}
	public static void Main()
	{
		Console.WriteLine("3110. Score of a String");
		{
			string s = "hello";
			int result = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (i + 1 < s.Length)
				{
					result += Math.Abs(((byte)s[i]) - ((byte)s[i + 1]));
				}
			}
			Console.WriteLine(result);
		}
		// 2894. Divisible and Non-divisible Sums Difference
		Console.WriteLine("2894. Divisible and Non-divisible Sums Difference");
		{
			int n = 10;
			int m = 3;
			int result = 0;
			for (int i = 1; i <= n; i++)
			{
				if (i % m != 0)
					result += i;
				else
					result -= i;
			}
			Console.WriteLine(result);
		}
		// 2942. Find Words Containing Character
		Console.WriteLine("2942. Find Words Containing Character");
		{
			var words = new string[] { "hello", "word", "leetcode" };
			var x = 'l';
			List<int> result = new List<int>();
			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].Contains(x))
					result.Add(i);
			}
			foreach (var item in result)
			{
				Console.Write($"{item} - ");
			}
			Console.WriteLine();
		}
		// 535. Encode and Decode TinyURL
		Console.WriteLine("535. Encode and Decode TinyURL");
		{
			const string baseUrl = "http://tinyurl.com/";
			string longUrl = "https://arkadii.com/blahblahblah";

			var bytes = System.Text.Encoding.UTF8.GetBytes(longUrl);
			string shortUrl = $"{baseUrl}{Convert.ToBase64String(bytes)}";
			Console.WriteLine($"Short URL: {shortUrl}");

			var base64 = shortUrl.Replace(baseUrl, string.Empty);
			var decodedBytes = Convert.FromBase64String(base64);
			string decodedUrl = System.Text.Encoding.UTF8.GetString(decodedBytes);
			Console.WriteLine($"Decoded URL: {decodedUrl}");
		}
		// 621. Task Scheduler
		Console.WriteLine("621. Task Scheduler");
		{
			char[] tasks = ['A', 'A', 'A', 'B', 'B', 'B'];
			int n = 2;
			int steps = 0; 
			Dictionary<char, int> taskCounts = new Dictionary<char, int>();
			foreach (var task in tasks)
			{
				if (taskCounts.ContainsKey(task))
					taskCounts[task]++;
				else
					taskCounts[task] = 1;
			}
			List<TaskToGo> taskList = new List<TaskToGo>();
			foreach (var task in taskCounts)
			{
				taskList.Add(new TaskToGo { Task = task.Key, RemainingCount = task.Value, NextAvailableTime = 0 });
			}

			while (taskList.Count > 0)
			{
				var currentTask = taskList
					.Where(t => t.NextAvailableTime <= steps)
					.MaxBy(t => t.RemainingCount);

				if (currentTask != null)
				{
					currentTask.RemainingCount--;
					currentTask.NextAvailableTime = steps + n + 1;
					if (currentTask.RemainingCount == 0)
					{
						taskList.Remove(currentTask);
					}
				}
				steps++;
			}

			Console.WriteLine(steps);
		}
		// 621. Task Scheduler ALT
		Console.WriteLine("621. Task Scheduler ALT");
		{
			char[] tasks = ['A', 'A', 'A', 'B', 'B', 'B'];
			int n = 2;

			// Count frequencies
			Dictionary<char, int> taskCounts = new();
			foreach (var task in tasks)
				taskCounts[task] = taskCounts.GetValueOrDefault(task) + 1;

			int maxFreq = taskCounts.Values.Max();
			int maxFreqCount = taskCounts.Values.Count(v => v == maxFreq); // K

			int result = Math.Max(tasks.Count() ,( (maxFreq * (n + 1)) - ((n + 1) - maxFreqCount)));

			Console.WriteLine(result);
		}
	}
}

