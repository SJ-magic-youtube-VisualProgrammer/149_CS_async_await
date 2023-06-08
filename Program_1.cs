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
			
			Task  t = RunAsync();
			Console.WriteLine($"return < RunAsync : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			
			// t.Wait();
			while(!t.IsCompleted){
				t.Wait(200);
				Console.Write(".");
			}
			Console.WriteLine();
			
			
			Console.WriteLine($"finish : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			
		}
		
		static async Task RunAsync(){
			Console.WriteLine($"> RunAsync : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			var watch = Stopwatch.StartNew();
			
			
			await Task.Run( () => Heavy() );
			
			
			watch.Stop();
			
			Console.WriteLine($"< RunAsync : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			// Thread.Sleep(1000);
			
			// return watch.Elapsed;
		}
		
		static void Heavy(){
			Console.WriteLine($"> Heavy : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			Thread.Sleep(5000);
			Console.WriteLine($"< Heavy : thread id = {Thread.CurrentThread.ManagedThreadId}");
			
			
		}
	}
}
