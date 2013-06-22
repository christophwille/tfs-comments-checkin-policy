using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using CCCPLib;
using CCCPMSBuildTask;
using ICSharpCode.NRefactory;

namespace CCCPMSBuildTaskTests
{
    /// <summary>
    /// Used when missing comments are to be added when the 
    /// CheckCodeComments Verify method is called.
    /// </summary>
    public struct MissingCommentInfo
    {
        public CodeCommentCheckingElements Elements;
        public CodeCommentCheckingVisibility Visibility;
        
        public MissingCommentInfo(CodeCommentCheckingElements elements, CodeCommentCheckingVisibility visibility)
        {
            Elements = elements;
            Visibility = visibility;
        }
    }
    
    /// <summary>
    /// Overrides the CreateTextReader method so the unit tests
    /// can run without requiring an actual file.
    /// </summary>
    public class DerivedCheckCodeCommentsTask : CheckCodeCommentsTask
    {
        private List<string> fileNames = new List<string>();
        private List<TextReader> textReadersCreated = new List<TextReader>();
        private string xmlWriterFileName;
        private XmlWriter resultsFileWriter;
        private StringBuilder resultsStringBuilder;
        private bool verifyCalled;
        private List<TextReader> textReaders = new List<TextReader>();
        private List<SupportedLanguage> supportedLanguages = new List<SupportedLanguage>();
        private List<CodeCommentError> codeCommentErrors = new List<CodeCommentError>();
        private List<MissingCommentInfo> missingComments = new List<MissingCommentInfo>();
        
        public DerivedCheckCodeCommentsTask()
        {
        }
        
        public void AddCodeCommentErrorDuringVerify(CodeCommentError error)
        {
            codeCommentErrors.Add(error);
        }
        
        public void AddMissingCommentDuringVerify(MissingCommentInfo missingComment)
        {
            missingComments.Add(missingComment);
        }
        
        /// <summary>
        /// Gets the filenames passed to the CreateTextReader method.
        /// </summary>
        public List<string> FileNames
        {
            get { return fileNames; }
        }
        
        /// <summary>
        /// Gets the text readers created by the CreateTextReader method.
        /// </summary>        
        public List<TextReader> TextReadersCreated
        {
            get { return textReadersCreated; }
        }
        
         /// <summary>
        /// Gets the text readers passed to the Verify method.
        /// </summary>
        public List<TextReader> TextReaders
        {
            get { return textReaders; }
        }
        
        /// <summary>
        /// Gets the supported languages passed to the verify method.
        /// </summary>
        public List<SupportedLanguage> SupportedLanguages
        {
            get { return supportedLanguages; }
        }       
        
        /// <summary>
        /// Gets or sets the filename passed to the CreateXmlWriter.
        /// </summary>
        public string XmlWriterFileName
        {
            get { return xmlWriterFileName; }
            set { xmlWriterFileName = value; }
        }
        
        public XmlWriter ResultsFileWriter
        {
            get { return resultsFileWriter; }
        }
        
        public string GetReportXml()
        {
            return resultsStringBuilder.ToString();
        }

        public bool IsVerifiedCalled 
        {
            get { return verifyCalled; }
        }
        
        /// <summary>
        /// Calls the base class's Verify method.
        /// </summary>
        public bool CallVerify(TextReader textReader, SupportedLanguage language)
        {
            return base.Verify(textReader, language);
        }
        
        public CheckCodeComments CheckCodeComments
        {
            get { return base.GetCheckCodeComments(); }
        }
                
        protected override XmlWriter CreateXmlWriter(string fileName)
        {
            xmlWriterFileName = fileName;
            resultsStringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(resultsStringBuilder);
            resultsFileWriter = base.CreateXmlWriter(stringWriter);
            return resultsFileWriter;
        }
        
        protected override TextReader CreateTextReader(string fileName)
        {
            fileNames.Add(fileName);
            StringReader stringReader = new StringReader(String.Empty);
            stringReader.Dispose();
            textReadersCreated.Add(stringReader);
            return stringReader;
        }
        
        protected override bool Verify(TextReader textReader, SupportedLanguage language)
        {
            verifyCalled = true;
            textReaders.Add(textReader);
            supportedLanguages.Add(language);
            
            // Add any dummy code comment errors.
            CheckCodeComments checkCodeComments = GetCheckCodeComments();
            foreach (CodeCommentError error in codeCommentErrors) 
            {
                checkCodeComments.CodeCommentErrors.Add(error);
            }
                  
            // Add any missing comment errors.
            foreach (MissingCommentInfo missingComment in missingComments)
            {
                checkCodeComments.CommentStatistics.IncMissingCommentCount(missingComment.Elements, missingComment.Visibility);
            }
            
            return true;
        }       
    }
}
