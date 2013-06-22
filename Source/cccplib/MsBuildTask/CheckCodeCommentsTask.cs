using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using CCCPLib;
using ICSharpCode.NRefactory;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;

namespace CCCPMSBuildTask
{
    /// <summary>
    /// CheckCodeComments MSBuild task.
    /// </summary>
    public class CheckCodeCommentsTask : Task
    {
        private ITaskItem[] sources;
        private string language;
        private string reportFileName;
        private bool treatParserErrorsAsPolicyViolation;
        private CodeCommentCheckingElements elementsToCheck = CodeCommentCheckingElements.Methods;
        private CodeCommentCheckingVisibility visibilityToCheck = CodeCommentCheckingVisibility.Public;
        private CheckCodeComments checkCodeComments;
        
        public CheckCodeCommentsTask() 
        {
        }
        
        /// <summary>
        /// Gets or sets whether the parser errors should be treated as a
        /// policy violation.
        /// </summary>
        public bool TreatParserErrorsAsPolicyViolation 
        {
            get { return treatParserErrorsAsPolicyViolation; }
            set { treatParserErrorsAsPolicyViolation = value; }
        }
        
        /// <summary>
        /// Gets or sets the source files that will be compiled.
        /// </summary>
        public ITaskItem[] Sources 
        {
            get { return sources; }
            set { sources = value; }
        }
        
        /// <summary>
        /// Gets or sets the supported languages for all the files. Only
        /// one language is supported for all the files.
        /// </summary>
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        
        /// <summary>
        /// Gets or sets whether methods are checked for comments.
        /// </summary>
        public bool CheckMethods
        {
            get { return (elementsToCheck & CodeCommentCheckingElements.Methods) == CodeCommentCheckingElements.Methods; }
            set { SetElementToCheck(value, CodeCommentCheckingElements.Methods); }
        }
        
        /// <summary>
        /// Gets or sets whether properties are checked for comments.
        /// </summary>
        public bool CheckProperties
        {
            get { return (elementsToCheck & CodeCommentCheckingElements.Properties) == CodeCommentCheckingElements.Properties; }
            set { SetElementToCheck(value, CodeCommentCheckingElements.Properties); }
        }
        
        /// <summary>
        /// Gets or sets whether fields are checked for comments.
        /// </summary>
        public bool CheckFields
        {
            get { return (elementsToCheck & CodeCommentCheckingElements.Fields) == CodeCommentCheckingElements.Fields; }
            set { SetElementToCheck(value, CodeCommentCheckingElements.Fields); }
        }        
        
        /// <summary>
        /// Gets or sets whether classes are checked for comments.
        /// </summary>
        public bool CheckClasses
        {
            get { return (elementsToCheck & CodeCommentCheckingElements.Class) == CodeCommentCheckingElements.Class; }
            set { SetElementToCheck(value, CodeCommentCheckingElements.Class); }
        }        
        
        /// <summary>
        /// Gets or sets whether events are checked for comments.
        /// </summary>
        public bool CheckEvents
        {
            get { return (elementsToCheck & CodeCommentCheckingElements.Class) == CodeCommentCheckingElements.Class; }
            set { SetElementToCheck(value, CodeCommentCheckingElements.Events); }
        }
        
        /// <summary>
        /// Gets or sets whether public methods, classes, events and properties
        /// are checked for comments.
        /// </summary>
        public bool CheckPublic
        {
            get { return (visibilityToCheck & CodeCommentCheckingVisibility.Public) == CodeCommentCheckingVisibility.Public; }
            set { SetVisibilityToCheck(value, CodeCommentCheckingVisibility.Public); }
        }
        
        /// <summary>
        /// Gets or sets whether private methods, classes, events and properties
        /// are checked for comments.
        /// </summary>
        public bool CheckPrivate
        {
            get { return (visibilityToCheck & CodeCommentCheckingVisibility.Private) == CodeCommentCheckingVisibility.Private; }
            set { SetVisibilityToCheck(value, CodeCommentCheckingVisibility.Private); }
        }    
        
        /// <summary>
        /// Gets or sets whether protected methods, classes, events and properties
        /// are checked for comments.
        /// </summary>
        public bool CheckProtected
        {
            get { return (visibilityToCheck & CodeCommentCheckingVisibility.Protected) == CodeCommentCheckingVisibility.Protected; }
            set { SetVisibilityToCheck(value, CodeCommentCheckingVisibility.Protected); }
        }        
           
        /// <summary>
        /// Gets or sets the filename where the code comment results will be 
        /// saved.
        /// </summary>
        public string ReportFileName
        {
            get { return reportFileName; }
            set { reportFileName = value; }
        }
                
        /// <summary>
        /// Checks the comments on the source files.
        /// </summary>
        public override bool Execute()
        {
            CreateCheckCodeComments();
            
            using (XmlWriter reportWriter = CreateReportWriter())
            {
                reportWriter.WriteStartElement("report");
                WriteConfiguration(reportWriter);
                
                foreach (ITaskItem sourceFile in sources)
                {
                    SupportedLanguage language = GetSupportedLanguage();
                    string fileName = sourceFile.ItemSpec;
                    using (TextReader textReader = CreateTextReader(fileName)) 
                    {
                        Verify(textReader, language);
                        WriteResults(reportWriter, fileName);
                    }
                }
                
                WriteSummary(reportWriter);
                reportWriter.WriteEndElement();
            }
            return true;
        }
        
        /// <summary>
        /// Creates a text reader to read the specified file.
        /// </summary>
        protected virtual TextReader CreateTextReader(string fileName)
        {
            return new StreamReader(fileName);
        }
        
        /// <summary>
        /// Creates an xml writer to write the specified file.
        /// </summary>
        protected virtual XmlWriter CreateXmlWriter(string fileName)
        {
            return CreateXmlWriter(new StreamWriter(fileName));
        }
        
        /// <summary>
        /// Creates an xml writer that uses the specified text writer.
        /// </summary>
        protected XmlWriter CreateXmlWriter(TextWriter writer)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.IndentChars = "\t";

            return XmlWriter.Create(writer, settings);
        }
        
        /// <summary>
        /// Gets the CheckCodeComments object.
        /// </summary>
        protected CheckCodeComments GetCheckCodeComments()
        {
            return checkCodeComments;
        }
        
        /// <summary>
        /// Checks the code comments in the specified text reader.
        /// </summary>
        protected virtual bool Verify(TextReader textReader, SupportedLanguage language)
        {
            return checkCodeComments.Verify(textReader, language);
        }
        
        /// <summary>
        /// Gets the supported language as a SupportedLanguage enum.
        /// </summary>
        private SupportedLanguage GetSupportedLanguage()
        {
            if (language == "VB.NET")
            {
                return SupportedLanguage.VBNet;
            }
            return SupportedLanguage.CSharp;
        }
                
        /// <summary>
        /// Enables or disables checking for the specified element.
        /// </summary>
        private void SetElementToCheck(bool check, CodeCommentCheckingElements element)
        {
            if (check)
            {
                elementsToCheck |= element;
            }
            else 
            {
                elementsToCheck &= ~element;                    
            }            
        }
        
        /// <summary>
        /// Enables or disables checking for the specified visibility.
        /// </summary>
        private void SetVisibilityToCheck(bool check, CodeCommentCheckingVisibility visibility)
        {
            if (check)
            {
                visibilityToCheck |= visibility;
            }
            else 
            {
                visibilityToCheck &= ~visibility;                    
            }            
        }
                
        /// <summary>
        /// Writes the configuration element in the code comment report.
        /// </summary>
        private void WriteConfiguration(XmlWriter writer)
        {
            writer.WriteStartElement("configuration");
            
            // Elements checked.
            writer.WriteStartElement("elementsChecked");
            writer.WriteAttributeString("classes", CheckClasses.ToString());
            writer.WriteAttributeString("methods", CheckMethods.ToString());
            writer.WriteAttributeString("properties", CheckProperties.ToString());
            writer.WriteAttributeString("events", CheckEvents.ToString());
            writer.WriteAttributeString("fields", CheckFields.ToString());
            writer.WriteEndElement();
            
            // Visibility checked.
            writer.WriteStartElement("visibilityChecked");
            writer.WriteAttributeString("public", CheckPublic.ToString());
            writer.WriteAttributeString("protected", CheckProtected.ToString());
            writer.WriteAttributeString("private", CheckPrivate.ToString());
            writer.WriteEndElement();
            
            writer.WriteEndElement();
        }
    
        /// <summary>
        /// Creates the reportDetails element in the code comment results.
        /// </summary>
        private void WriteResults(XmlWriter writer, string fileName)
        {
            writer.WriteStartElement("reportDetails");
            
            writer.WriteStartElement("file");
            writer.WriteAttributeString("name", fileName);
            writer.WriteAttributeString("missingComments", checkCodeComments.CodeCommentErrors.Count.ToString());
            
            foreach (CodeCommentError error in checkCodeComments.CodeCommentErrors)
            {
                writer.WriteStartElement("commentFailure");
                writer.WriteAttributeString("class", error.ClassName);
                writer.WriteAttributeString("element", error.ElementName);
                writer.WriteAttributeString("line", error.Line.ToString());
                writer.WriteEndElement();
            }
            
            writer.WriteEndElement();
            
            writer.WriteEndElement();    
        }
        
        /// <summary>
        /// Creates the reportSummary element in the code comment results.
        /// </summary>
        private void WriteSummary(XmlWriter writer)
        {
            writer.WriteStartElement("reportSummary");
            
            writer.WriteStartElement("missing");
            foreach (CodeCommentCheckingElements codeCommentCheckingElement in checkCodeComments.CommentStatistics.MissingCommentsCount.Keys)
            {
                string element = codeCommentCheckingElement.ToString().ToLowerInvariant();
                writer.WriteStartElement(element);
                foreach (KeyValuePair<CodeCommentCheckingVisibility, int> pair in checkCodeComments.CommentStatistics.MissingCommentsCount[codeCommentCheckingElement])
                {
                    string attribute = pair.Key.ToString().ToLowerInvariant();
                    writer.WriteAttributeString(attribute, pair.Value.ToString());
                }
                writer.WriteEndElement();                
            }
            writer.WriteEndElement();
            
            writer.WriteEndElement();        
        }
        
        /// <summary>
        /// Creates the code comment report writer.
        /// </summary>
        private XmlWriter CreateReportWriter()
        {
            if (reportFileName == null)
            {
                return CreateXmlWriter(TextWriter.Null);
            }
            return CreateXmlWriter(reportFileName);
        }
        
        /// <summary>
        /// Creates a new instance of the CheckCodeComments class.
        /// </summary>
        private void CreateCheckCodeComments()
        {
            checkCodeComments = CheckCodeComments.CreateInstance(elementsToCheck, visibilityToCheck);
            checkCodeComments.AccumulateErrors = false;
            checkCodeComments.TrackStatistics = true;
            checkCodeComments.AccumulateStatistics = true;
            checkCodeComments.TreatParserErrorsAsPolicyViolation = treatParserErrorsAsPolicyViolation;
        }
    }
}
