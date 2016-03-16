using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mandatory1.ViewModels
{
    public class CipherModel
    {
        [Required]
        [Display(Name = "Text to use cipher on")]
       public string input { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string secret { get; set; }

        [Required]
        public string type { get; set; }
        public string Output { get { return output; } }
        private string output;
        public void setOutput(string output)
        {
            this.output = output;
        }

        public void process(string cipher)
        {
            string processedString = "";
            switch (cipher)
            {
                case "shift":
                    int shift = (int.Parse(secret)+ char.MaxValue)% char.MaxValue;
                    if (type == "dec")
                    {
                       shift = decimal.ToInt32(decimal.Negate(shift));
                    }                   

                    for (int i = 0; i < input.Length; i++)
                    {
                        processedString += (char)((input[i] + shift) % char.MaxValue);
                    }

                    break;
                case "vigenere":
                    int index = 0;
                    foreach(char currInput in input)
                    {
                        int secretAtIndex = secret[index];
                        if (type == "dec") { secretAtIndex = decimal.ToInt32(decimal.Negate(secretAtIndex)); }
                        processedString += (char)((currInput + secretAtIndex) % char.MaxValue);
                        index = (index < secret.Length - 1) ? index = index + 1 : index = 0;
                    }
                    break;
                case "gcd":
                    int r = -1;
                    int a = int.Parse(input);
                    int b = int.Parse(secret);
                    while (b > 0)
                    {
                        r =  a%b;
                        a = b;
                        b = r;
                    }
                    processedString = a.ToString();
                    break;
                case "extra":
                    Dictionary<char, char> substituteTable = new Dictionary<char, char>();
                    substituteTable.Add('?', 'w');
                    substituteTable.Add('.', 'h');
                    substituteTable.Add('1', 'e');
                    substituteTable.Add('(', 'n');
                    substituteTable.Add('v', ' ');
                    substituteTable.Add('-', 'i');
                    substituteTable.Add('\"', 't');
                    substituteTable.Add('3', 'c');
                    substituteTable.Add('\'', 'o');
                    substituteTable.Add('!', 'u');
                    substituteTable.Add('$', 'r');
                    substituteTable.Add('#', 's');
                    substituteTable.Add('0', 'f');
                    substituteTable.Add(')', 'm');
                    substituteTable.Add('5', 'a');
                    substituteTable.Add(' ', 'v');
                    substituteTable.Add('&', 'p');
                    substituteTable.Add('4', 'b');
                    substituteTable.Add('*', 'l');
                    substituteTable.Add('2', 'd');
                    substituteTable.Add('/', 'g');
                    substituteTable.Add('H', 'N');
                    substituteTable.Add('%', 'q');
                    substituteTable.Add('j', ',');
                    substituteTable.Add('+', 'k');
                    substituteTable.Add('J', 'L');
                    substituteTable.Add('o', '\'');
                    substituteTable.Add('O', 'G');
                    substituteTable.Add('h', '.');
                    substituteTable.Add('i', '-');
                    substituteTable.Add('S', 'C');
                    substituteTable.Add('B', 'T');
                    substituteTable.Add(',', 'j'); // switched characters between each other, shift by x?

                    foreach (char c in input)
                    {
                        if (substituteTable.ContainsKey(c))
                        {
                            processedString += substituteTable[c];
                        }
                        else
                        {
                           processedString += c+"?";
                        }
                    }
                    setOutput(processedString);
                    break;
                default:
                    processedString = "Incorrect cipher name!";
                    break;
            }
            setOutput(processedString);

        }

        
    }

 
}
