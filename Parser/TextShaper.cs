using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.TextModel.SimpleConstructions;
using Task2.TextModel.CompositeConstructions;

namespace Task2.Parser
{
    public class TextShaper
    {
        public Dictionary<char, Shape> Shapes { get; private set; }

        public IList<char> CharBuffer { get; private set; }

        public IList<BaseSentenceComponent> SentenceBuffer { get; private set; }

        private bool PunctuationInSetnenceSetted = false;
        private bool PunctuationSentenceFinisherSetted = false;
        private bool Separator = false;

        public TextShaper()
        {
            SentenceBuffer = new List<BaseSentenceComponent>();
            CharBuffer = new List<char>();
            Shapes = new Dictionary<char, Shape>();
            Shapes.Add(',', WordFinish);
            Shapes.Add('-', WordFinish);
            Shapes.Add('.', SentenceFinish);
            Shapes.Add('?', SentenceFinish);
            Shapes.Add('!', SentenceFinish);
            Shapes.Add(' ', Separate);
            Shapes.Add(Convert.ToChar("/n") , Separate);
            Shapes.Add(Convert.ToChar("/t"), Separate);
        }

        public delegate void Shape(char currentSymbol);
        
        public void WordFinish(char currentSymbol)
        {
            if (PunctuationInSetnenceSetted == false)
            {
                SetWord();
            }
            CharBuffer.Add(currentSymbol);
            PunctuationInSetnenceSetted = true;
        }

        public void Separate(char currentSymbol)
        {
            
            if (PunctuationInSetnenceSetted == false && PunctuationSentenceFinisherSetted == false)
            {
                SetWord();
                InSentenseSeparator separator = new InSentenseSeparator(currentSymbol);
                SentenceBuffer.Add(separator);
            }

            if (PunctuationInSetnenceSetted == true)
            {
                PunctuationMark punctuationMark = new PunctuationMark(CharBuffer);
                CharBuffer.Clear();
                CharBuffer.Add(currentSymbol);
            }

            if (PunctuationSentenceFinisherSetted == true)
            {
                PunctuationMark punctuationMark = new PunctuationMark(CharBuffer);
                CharBuffer.Clear();
                PunctuationSentenceFinisherSetted = false;
                Sentence sentence = new Sentence(SentenceBuffer);
                Text.TextSentences.Add(sentence);
                SentenceBuffer.Clear();
                CharBuffer.Add(currentSymbol);
            }


        }
        
        public void SentenceFinish(char currentSymbol)
        {
            if (PunctuationSentenceFinisherSetted == false)
            {
                SetWord();
            }
            CharBuffer.Add(currentSymbol);
            PunctuationSentenceFinisherSetted = true;
        }

        public void SetWord()
        {
            Word word = new Word(CharBuffer);
            SentenceBuffer.Add(word);
            CharBuffer.Clear();
        }
    }
}
