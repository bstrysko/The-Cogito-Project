using System;
using System.Collections;
using SpeechLib;

namespace CogitoProject.Communication
{
    /**
     * The Voice class handles all Text to Speech and Speech to Text processing.
     * All underlying processing is done by SAPI.
     * 
     * @author Brent Strysko
     * @date 2/12/10
     */
    public class Voice
    {
        /**
         * Contains all the information needed for Text to Speech processing.
         */
        private SpVoice voice;

        /**
         * The engine to power the Speech to Text features.
         */
        private SpeechLib.SpSharedRecoContext objRecoContext;

        /**
         * The voice profile loaded by SAPI
         */
        private SpeechLib.ISpeechRecoGrammar grammar;

        /**
         * The words that are being matched to the spoken text. 
         */
        private SpeechLib.ISpeechGrammarRule menuRule;

        /**
         * Needed when assigning words to be recognized to menuRule .
         */
        private object PropValue = "";

        /**
         * Counter for command tracking. 
         */
        private int commandCount;

        /**
         * Where the recognized commands are stored until the main program is
         * ready to process them.
         */
        private Queue _buffer;

        /**
         * Initializes the Text to Speech and Speech to Text engines.
         * Finalize commands must be called before the Speech to Text engine will
         * work.
         */
        public Voice()
        {
            this.voice = new SpVoice();
    
            objRecoContext = new SpSharedRecoContext();
            objRecoContext.Recognition += new _ISpeechRecoContextEvents_RecognitionEventHandler(RecoEvent);
            grammar = objRecoContext.CreateGrammar(0);
            menuRule = grammar.Rules.Add("cogitoCommands",SpeechRuleAttributes.SRATopLevel|SpeechRuleAttributes.SRADynamic,1);
            this.commandCount = 1;

            this._buffer = new Queue();
        }

        /**
         * Adds a word or phrase to recognize to the menuRule's internal list.
         * 
         * @param command the word or phrase to be tested against when recognizing
         * commands
         */
        public void addCommand(String command)
        {
            menuRule.InitialState.AddWordTransition(null,command, " ", SpeechGrammarWordType.SGLexical,command,commandCount, ref PropValue, 1.0F);
            commandCount++;
        }

        /**
         * Finalizes the commands to be recognized.  This MUST BE CALLED BEFORE
         * USING SPEECH TO TEXT COMMANDS.
         */
        public void finalizeCommands()
        {
            grammar.Rules.Commit();
            grammar.CmdSetRuleState("cogitoCommands", SpeechRuleState.SGDSActive);
        }

        /**
         * Places a recognized commmand in the buffer.
         * 
         * @param StreamNumber
         * @param StreamPosition
         * @param RecongitionType
         * @param Result
         */
        private void RecoEvent(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
        {
            _buffer.Enqueue(Result.PhraseInfo.GetText(0, -1, true));
        }

        /**
         * Returns true if a command is found on the buffer.
         * If returns true, getCommand() should be called.
         * 
         * @return if a command is found in the buffer.
         */
        public bool availableCommand()
        {
            return(_buffer.Count > 0);
        }

        /**
         * Returns a recognized command from the list initialized in addCommand .
         * Before calling use availableCommand() to see if a command exists.
         * 
         * @return a recognized command
         */
        public String getCommand()
        {
            return (String)_buffer.Dequeue();
        }

        /**
         * Speaks the text using the default Text to Speech voice. 
         * 
         * @param text the String to be spoken
         */
        public void speak(string text)
        {
            voice.Speak(text,SpeechVoiceSpeakFlags.SVSFDefault);
        }
    }
}