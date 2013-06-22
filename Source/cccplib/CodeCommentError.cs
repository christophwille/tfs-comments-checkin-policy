using System;

namespace CCCPLib
{
    public class CodeCommentError
    {
        private string className;
        private string elementName;
        private int line;
        private string errorMessage;

        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public string ElementName
        {
            get { return elementName; }
            set { elementName = value; }
        }


        public CodeCommentError(string offendingClass, string offendingElement, int offendingLine)
        {
            className = offendingClass;
            elementName = offendingElement;
            line = offendingLine;
            errorMessage = "";
        }

        public CodeCommentError(string offendingError)
        {
            errorMessage = offendingError;
        }

        public override string ToString()
        {
            if ("" != errorMessage) return errorMessage;

            return "No code comment for " + elementName + " in class " + className + " at line " + line.ToString();
        }
    }
}
