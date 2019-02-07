using System;
using System.Collections;
using System.Threading;
//using System.Windows.Forms;


using Microsoft.PointOfService;

namespace EclipsePos.Apps.Util
{
	/// <summary>
	/// Summary description for PrintJobQueue.
	/// </summary>
	public class PrintJobQueue : IDisposable		
	{
		
		#region Variable

		private static PrintJobQueue printJobQueue;
		private static Queue queue;
		private static Thread t1=null;
		private static object lockObject = new object();
		private static AutoResetEvent wh = new AutoResetEvent(true);
        private object[] queueBakup; // = new Object[200];



		#endregion


		static PrintJobQueue() 
		{
			printJobQueue = new PrintJobQueue();
			queue = new Queue();
			
			
		}

		private PrintJobQueue()
		{
            
		}


		private static void PintReceiptImmediate()
		{

			while (true)
			{
				PrintWorker print = null;

				lock (lockObject)
				{

					if (queue.Count > 0 )
					{
						try 
						{ 
							print = (PrintWorker) queue.Dequeue();
						}
						catch (Exception e)
						{
							Logger.Error("PrintJobQueue.cs", e.ToString() );
						}
					}
				}

				if ( print != null)
				{
					print.Worker();
				}
				else
				{
                        wh.WaitOne(); // No more print jobs - wait for the signel
                }
			
			}
		}


		
		public void PintReceipt()
		{
			
			lock (lockObject)
			{
				while (queue.Count > 0 )
				{
					try 
					{
						PrintWorker print = (PrintWorker) queue.Dequeue(); 
						print.Worker();
					}
					catch (Exception e)
					{
						Logger.Error("PrintJobQueue.cs", e.ToString() );
					}
				}
			}
		}

		 
		public void AddJob(PrintWorker worker)
		{
			
			lock (lockObject)
			{
				queue.Enqueue(worker);
			}

			if( PosSettings.Default.PrintReceiptImmediate)
			{
				if (t1 == null)
				{
					t1 = new Thread(new ThreadStart(PintReceiptImmediate));
					t1.Start();
					
				}
				else
				{
					wh.Set();
				}
			}
		}

		public void PrintReceiptStart()
		{
			if (t1==null )
			{
				t1 = new Thread(new ThreadStart(PintReceiptImmediate));
				t1.Start();
			}
			wh.Set();
			
			
		}


        public void  Backup()
        {
            this.queueBakup = new object[queue.Count];
            queue.CopyTo(queueBakup, 0);
        }

        public void Restore()
        {
            this.Clear();

            foreach (object obj in queueBakup)
            {
                if (obj == null) break;
                queue.Enqueue(obj);
            }
            this.queueBakup = null;



        }


        public void Clear()
        {
            lock (lockObject)
            {
                queue.Clear();
            }
        }

        public void PintCopy()
        {

            this.Backup();
            this.PintReceipt();
            this.Restore();


        }


		#region IDisposable Members

		public void Dispose()
		{
			wh.Close();
			queue = null;
			try
			{
				t1.Abort();
			}
			catch
			{}
		
		}

		#endregion
		
		#region Properties
		
		public static PrintJobQueue Instance
		{
			get
			{
				return printJobQueue;
			}
		}


		public Thread PrintThread
		{
			get 
			{
				return t1;
			}
		}


		#endregion
	}
}
