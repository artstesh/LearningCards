using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCards
    {    
    class WordCard
        {
        public string word { get; }
        public string description { get; }

        public WordCard(string word, string description)
            {
            this.word = word;
            this.description = description;
            }

        
        }
    }
