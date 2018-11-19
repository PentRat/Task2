using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.TextModel.CompositeConstructions;
using Task2.TextModel.SimpleConstructions;

namespace Task2.Analyser
{
    public class Analyzer
    {
        private const string CursedLetters = "BCDFGHJKLMNPQRSTVWXZbcdfghjklmnpqrstvwxzБВГДЖЗЙКЛМНПРСТФХЦЧШЩбвгджзйклмнпрстфхцчшщ";
        public List<Sentence> SortByWordsCount(Text text)
        {
            var orderedSentences = text.TextComponents
                .Select(x => x as Sentence)
                .Where(x => x != null)
                .OrderBy(x => x.WordsCount)
                .ToList();
            return orderedSentences;
        }

        public List<Word> WordsInQuestionsWithSettedLenghtFinder(Text text, int wordLenght)
        {
            List<Word> WordsInQuestionsWithSettedLenght = new List<Word>();
            List<Sentence> allSentences = SortByWordsCount(text);
            List<Sentence> questions = QuestionFinder(allSentences);
            foreach (Sentence question in questions)
            {
                WordsInQuestionsWithSettedLenght.AddRange(FindWordsWithSettedLenght(question, wordLenght));
            }
            return WordsInQuestionsWithSettedLenght;
        }

        private List<Sentence> QuestionFinder(List<Sentence> allSentences)
        {
            var questions = allSentences
                .Select(x => x as Sentence)
                .Where(x => x != null && IsItQuestion(x) == true)
                .ToList();
            return questions;
        }


        private bool IsItQuestion(Sentence sentence)
        {
            var mark = sentence.SentenceComponents
                .Select(x => x as PunctuationMark)
                .Any(x => x.SymbolCombination.Contains('?'));
            return mark;
        }

        private List<Word> FindWordsWithSettedLenght(Sentence question, int wordLenght)
        {
            var searchedWords = question.SentenceComponents
               .Select(x => x as Word)
               .Where(x => x != null && x.Letters.Count == wordLenght)
               .ToList();
            return searchedWords;
        }
        private List<BaseSentenceComponent> FindWordsToPurge(Sentence sentence, int wordLenght)
        {
            List<Word> FoundedWords = FindWordsWithSettedLenght(sentence, wordLenght);
            var searchedWords = FoundedWords
               .Select(x => x as Word)
               .Where(x => x != null && CursedLetters.Contains(x.Letters[0]))
               .ToList();
            List<BaseSentenceComponent> baseSentenceComponents = new List<BaseSentenceComponent>();
            foreach (Word word in FoundedWords)
            {
                baseSentenceComponents.Add(word);
            }
            return baseSentenceComponents;
        }

        private Sentence Rebuild(Sentence inputSentence, List<BaseSentenceComponent> filter)
        {
            var result = inputSentence.SentenceComponents.Except(filter).ToList();
            Sentence sentence = new Sentence(result);
            return (sentence);

        }
        public Text TextRebuild(Text oldText, int wordLenght)
        {
            Text NewText = new Text();
            foreach (Sentence sentence in oldText.TextComponents)
            {
                List<BaseSentenceComponent> Filter = FindWordsToPurge(sentence, wordLenght);
                Sentence Rebuilded = Rebuild(sentence, Filter);
                NewText.Add(Rebuilded);
            }
            return NewText;
        }
    }
}
