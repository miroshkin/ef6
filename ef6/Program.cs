using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ef6.Models;

namespace ef6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Words.Add(new Word()
                {
                    Transcription = "asdf",
                });
                context.SaveChanges();

                var words = context.Words.ToList();
                foreach (var word in words)
                {
                    Console.WriteLine(word.Transcription);
                }
                Console.ReadLine();
            }
        }
    }
}
