using System;
using System.Diagnostics;

namespace VisuapProgrammer_sj
{
	internal class AsyncTest
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"start : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			Console.WriteLine($"call   > RunAsync : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			Task <TimeSpan> t = RunAsync();
			Console.WriteLine($"return < RunAsync : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			
			// t.Wait();
			while(!t.IsCompleted){
				t.Wait(200);
				Console.Write(".");
			}
			Console.WriteLine();
			
			
			Console.WriteLine($"finish : thread id = {Thread.CurrentThread.ManagedThreadId}");
			Console.WriteLine($"t.Result at main = {t.Result}");
			
		}
		
		static async Task<TimeSpan> RunAsync(){
			Console.WriteLine($"> RunAsync : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			var watch = Stopwatch.StartNew();
			//await Task.Run( () => Heavy(1) );
			Task<int> t = Task.Run( () => Heavy(1) );
			await t;
			Console.WriteLine($"t.Result = {t.Result}");
			
			watch.Stop();
			
			Console.WriteLine($"< RunAsync : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			// Thread.Sleep(1000);
			
			return watch.Elapsed;
		}
		
		static int Heavy(int param){
			Console.WriteLine($"> Heavy : thread id = {Thread.CurrentThread.ManagedThreadId}");
			Console.WriteLine($"param = {param}");
			Thread.Sleep(5000);
			Console.WriteLine($"< Heavy : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			return 99;
		}
	}
}
