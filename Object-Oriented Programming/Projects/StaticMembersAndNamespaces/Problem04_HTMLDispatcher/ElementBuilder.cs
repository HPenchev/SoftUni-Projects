using System;
using System.Text.RegularExpressions;



    class ElementBuilder
    {
        private string elementsName;
        private string element;

        public string ElementsName
        {
            get
            {
                return this.elementsName;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Tag name can't be empty");
                elementsName = value;
            }
        }
        public string Element
        {
            get 
            {
               return this.element;
            }
            set 
            {
                element = value;
            }
        }
        public ElementBuilder(string elementName)
        {
            this.ElementsName = elementName;
            this.Element = "<" + elementName + "></" + elementName + ">";
        }
        public void AddAttribute(string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute)) throw new ArgumentNullException("attribute can't be empty");
            string addon = attribute + "=\"" + value + "\"";
            Match match = Regex.Match(this.Element, @"(<[^>]+)?(.+)");
            this.Element = match.Groups[1].Value + " " + addon + match.Groups[2].Value;
            this.Element = this.Element.Replace("  ", " ");
           
        }
        public void AddContent(string content)
        {
            
            Regex pattern = new Regex(@"<" + this.ElementsName + "[^>]*>.+</" + this.ElementsName + ">");
            Match match = pattern.Match(this.Element);
            if (match.Success)
            {
                throw new ArgumentException ("The element already has a content");
            }
            else
            {
                pattern = new Regex(@"(<" + this.ElementsName + "[^>]*>)(</" + this.ElementsName + ">)");
                match = pattern.Match(this.Element);
                this.Element = match.Groups[1].Value + content + match.Groups[2].Value;
                                
            }
        }
        public static string operator *(ElementBuilder element, uint multiplier)
        {
            string output = "";
            for (int i = 0; i < multiplier; i++)
            {
                output += element.Element;
            }
            return output;
        }

    }

