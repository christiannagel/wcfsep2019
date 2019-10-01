using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AmbientTransactionsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            AmbientTx1();
           
        }

        private static void AmbientTx1()
        {
            {
                using var scope = new TransactionScope(TransactionScopeOption.Required);

                Transaction.Current.TransactionCompleted += (sender, e) =>
               {
                   ShowTxInfo(e.Transaction.TransactionInformation, "completed");
               };

                ShowTxInfo(Transaction.Current.TransactionInformation, "just created");

                AmbientTx2();

                scope.Complete(); // happy bit
            }  // scope.Dispose() - if root tx, commit or abort


            // ShowTxInfo(Transaction.Current.TransactionInformation, "after dispose");
        }

        private static void AmbientTx2()
        {
            using var scope = new TransactionScope(TransactionScopeOption.RequiresNew);
            ShowTxInfo(Transaction.Current.TransactionInformation, "tx in inner scope");
            scope.Complete();

        }

        private static void ShowTxInfo(TransactionInformation txi, string status)
        {
            Console.WriteLine(status);
            Console.WriteLine($"{txi.Status} {txi.CreationTime}");
            Console.WriteLine($"{txi.LocalIdentifier}");
            Console.WriteLine($"{txi.DistributedIdentifier}");
            Console.WriteLine();
        }
    }
}
