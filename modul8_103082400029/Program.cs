using System;
using modul8_103082400029;

class Program
{
    static void Main()
    {
        var config = BankTransferConfig.LoadConfig();

        if (config.lang == "en")
            Console.Write("Please insert the amount of money to transfer : ");
        else
            Console.Write("Masukkan jumlah uang yang akan di-transfer : ");

        int amount = int.Parse(Console.ReadLine());

        int fee = (amount <= config.transfer.threshold)
            ? config.transfer.low_fee
            : config.transfer.high_fee;

        int total = amount + fee;

        if (config.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {fee}");
            Console.WriteLine($"Total amount = {total}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {fee}");
            Console.WriteLine($"Total biaya = {total}");
        }

        if (config.lang == "en")
            Console.WriteLine("Select transfer method :");
        else
            Console.WriteLine("Pilih metode transfer :");

        for (int i = 0; i < config.methods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {config.methods[i]}");
        }

        Console.ReadLine();

        if (config.lang == "en")
            Console.Write($"Please type \"{config.confirmation.en}\" to confirm the transaction : ");
        else
            Console.Write($"Ketik \"{config.confirmation.id}\" untuk mengkonfirmasi transaksi : ");

        string confirm = Console.ReadLine();

        if ((config.lang == "en" && confirm == config.confirmation.en) ||
            (config.lang == "id" && confirm == config.confirmation.id))
        {
            if (config.lang == "en")
                Console.WriteLine("The transfer is completed");
            else
                Console.WriteLine("Proses transfer berhasil");
        }
        else
        {
            if (config.lang == "en")
                Console.WriteLine("Transfer is cancelled");
            else
                Console.WriteLine("Transfer dibatalkan");
        }
    }
}